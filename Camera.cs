using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{

    /// <summary>
    /// Type of following you want to apply to the Camera
    /// </summary>
    public enum FollowingType : byte
    {
        NOTHING, 
        LOCKON, 
        ALWAYS_ON_LEFT, 
        ALWAYS_ON_RIGHT, 
        FIGHTER 
    };


    /// <summary>
    /// Represent an Axe (X,Y or both).
    /// </summary>
    public enum Axe : byte
    {
        HORIZONTAL,
        VERTICAL,
        HORIZONTAL_AND_VERTICAL,
        ANGLE
    }

    public static class Camera
    {

        /// <summary>
        /// The Position of the Camera. It is automatically changed if you use the Follow() Method.
        /// </summary>
        public static Vector2 Position { get; set; } = Vector2.Zero;

        /// <summary>
        /// The current Zoom of the Camera. By default it's set to 1.0f.
        /// </summary>
        public static float Zoom { get; set; } = 1.0f;

        /// <summary>
        /// The current Offset of the Camera. By default it's set to the upper left corner, so it's Vector2.Zero.
        /// </summary>
        public static Vector2 Offset { get; set; } = Vector2.Zero;

        /// <summary>
        /// The current Origin of the Camera. By default it's set to the upper left corner, so it's Vector2.Zero. This variable is not used yet, use Offset instead.
        /// </summary>
        public static Vector2 Origin { get; set; } = Vector2.Zero;

        /// <summary>
        /// The Angle of the Camera. It's automatically converted to Radian so you don't need to apply the conversion.
        /// </summary>
        public static float Angle { get; set; } = 0f;

        /// <summary>
        /// Set the World Bounds. Represent the limit of movement your Camera can do to avoid black screen if you are moving too much to the left/right/up/down.
        /// </summary>
        public static Rectangle WorldBounds { get; set; }


        /// <summary>
        /// Default value of the zoom of the camera
        /// </summary>
        public static readonly float DEFAULT_ZOOM_VALUE = 1.0f;

        private static Vector2 InitialPosition = Vector2.Zero;

        public static IActor FollowingActor = null;
        public static float FollowLerp = 1.0f;

        public static FollowingType FollowingType = FollowingType.LOCKON;

        public static Rectangle VisibleArea = new Rectangle(0, 0, MainGame.WIDTH, MainGame.HEIGHT);
        private static Texture2D CameraDebugArea;

        // Shake Effect : 
        private static Vector2 BaseShakePosition;
        private static Vector2 OldShakeIntensity;

        private static float currentShakeIntensity = 0.0f;
        private static float currentShakeDuration = 0.0f;
        private static Axe currentShakeAxe = Axe.HORIZONTAL_AND_VERTICAL;
        private static bool canShake = false;
        public static bool ShakeIsFinished { get; private set; } = false;

        // Flash Effect : 
        private static bool canFlash = false;
        private static float currentFlashDuration = 0.0f;
        private static Texture2D flashRectangle;
        private static Color flashColor = Color.White;
        private static float alphaFlash = 1.0f;
        public static bool FlashIsFinished { get; private set; } = false;

        // Fade Effect : 
        private static bool canFade = false;
        private static float currentFadeDuration = 0.0f;
        private static Texture2D fadeRectangle;
        public static Color fadeColor { get; private set; } = Color.White;
        private static float alphaFade = 0.0f;
        public static bool FadeIsFinished { get; private set; } = false;
        private static bool StayFaded = false;

        public static OnComplete OnCompleteFade;
        public static OnComplete OnCompleteFlash;

        // Debug tools : enable (put to true) or disable (put to false) what you need
        private static bool DEBUG_IS_ON = false;
        private static bool AUTHORIZED_FORCED_ZOOM = false; // Put this to true to enable zoom with PageUp/PageDown keys.

        private static float captureAngleValue = 0;

        //private static int oldDataLength = 0; // But don't touch to this one.

        /// <summary>
        /// Use this into your spritebatch.
        /// </summary>
        public static Matrix Transformation
        {
            get
            {
                
                return 
                  Matrix.CreateTranslation(-Position.X, -Position.Y, 0)               // Position
                * Matrix.CreateScale((float)Zoom, (float)Zoom, 1f)                    // Zoom
                * Matrix.CreateRotationZ(MathHelper.ToRadians(Angle))                 // Angle
                * Matrix.CreateTranslation(Origin.X, Origin.Y, 0);                    // Origin

            }
        }

        private static float Lerp(float start, float end, float pLerp) { return (float)Math.Round((decimal)(start + pLerp * (end - start))); }

        public static float GetLerpCurrentValueX = 0;
        public static float GetLerpCurrentValueY = 0;

        /// <summary>
        /// Allow the Camera to Follow a Sprite
        /// </summary>
        /// <param name="actor"> The Sprite or AnimatedSprite you want the Camera to follow </param>
        /// <param name="followType"> The Type of Follow : LOCKON put the Camera on the center of the Following Sprite </param>
        /// <param name="lerp"> Smooth effect it have to be a small value, more it lower, more the camera will move slowly and smoother </param>
        public static void Follow(Sprite actor = null, FollowingType followType = FollowingType.LOCKON, float lerp = 1.0f)
        {
            FollowLerp = lerp;
            FollowingType = followType;

            if (actor == null) FollowingType = FollowingType.NOTHING;

            switch(FollowingType)
            {
                case FollowingType.NOTHING:
                    Position = Vector2.Zero;
                    break;

                case FollowingType.ALWAYS_ON_LEFT:
                    Position = new Vector2(Lerp(Position.X, actor.Position.X + Offset.X, lerp), 
                                           Lerp(Position.Y, actor.Position.Y + Offset.Y, lerp));
                    break;

                case FollowingType.LOCKON:
                    Position = new Vector2(Lerp(Position.X, (actor.Position.X - (VisibleArea.Width / 2 - (actor.Width * actor.Scale.X) / 2) + Offset.X), lerp),
                                           Lerp(Position.Y, (actor.Position.Y - (VisibleArea.Height / 2 - (actor.Height * actor.Scale.Y) / 2) + Offset.Y), lerp));

                    break;

                case FollowingType.ALWAYS_ON_RIGHT:
                    Position = new Vector2(actor.Position.X - (MainGame.WIDTH - (actor.Width * actor.Scale.X)), 
                                           actor.Position.Y - (MainGame.HEIGHT - (actor.Height * actor.Scale.Y)));
                    break;
            }

            if (WorldBounds != null)
            {
                if (Position.X <= WorldBounds.X)
                    Position = new Vector2(WorldBounds.X,Position.Y);
                
                if (Position.X + (VisibleArea.Width) >= WorldBounds.Width)
                    Position = new Vector2(WorldBounds.Width - (VisibleArea.Width),Position.Y);
                
                if (Position.Y <= WorldBounds.Y)
                    Position = new Vector2(Position.X, WorldBounds.Y);

                if (Position.Y + (VisibleArea.Height) >= WorldBounds.Height)
                    Position = new Vector2(Position.X, WorldBounds.Height - (VisibleArea.Height));
            }

            if (FollowingType != FollowingType.NOTHING && FollowingActor == null)
            {
                FollowingActor = actor;
                InitialPosition = Position;
            }

            Camera.FollowingActor = actor;
        }

        // ==================== EFFECTS ====================

        /// <summary>
        /// Apply a shake screen effect
        /// </summary>
        /// <param name="intensity"> Represent the intensity of the movement </param>
        /// <param name="duration"> Represent the time the effect it will last </param>
        /// <param name="axe"> The Axis to apply the effect, by default it screen on X and Y axis </param>
        public static void Shake(float intensity, float duration, Axe axe = Axe.HORIZONTAL_AND_VERTICAL)
        {
            intensity = Util.GivePercentageFromValue(Accessibility.CAMERA_SHAKE_INTENSITY,intensity);

            if (!canShake && currentShakeDuration == 0)
            {
                ShakeIsFinished = false;
                currentShakeIntensity = intensity;
                currentShakeDuration = duration;

                if (FollowingActor == null)
                    BaseShakePosition = Vector2.Zero;
                else
                    BaseShakePosition = Position;

                captureAngleValue = Angle;

                currentShakeAxe = axe;

                canShake = true;
            }
            

        }

        /// <summary>
        /// Apply a Flash screen effect
        /// </summary>
        /// <param name="duration"> Represent the amount of time the effect will be on screen </param>
        /// <param name="color"> Represent the color of the flash screen </param>
        public static void Flash(float duration,Color color)
        {
            if (!canFlash && currentFlashDuration == 0)
            {
                FlashIsFinished = false;
                currentFlashDuration = duration;
                alphaFlash = 1.0f;

                flashColor = color * Util.GivePercentageFromValue(Accessibility.CAMERA_FLASH_INTENSITY,1f);
                flashRectangle = new Texture2D(MainGame.Instance.GraphicsDevice, 1, 1);
                flashRectangle.SetData(new Color[] { flashColor });

                canFlash = true;
            }

        }

        /// <summary>
        /// Apply a Fade screen effect 
        /// </summary>
        /// <param name="duration"> Represent the amount of time the effect will be on screen </param>
        /// <param name="color"> Represent the color of the flash screen </param>
        /// <param name="stayFaded"> Say if at the end of the effect you want the screen to keep faded </param>
        public static void Fade(float duration, Color color, bool stayFaded = false)
        {
            StayFaded = stayFaded;

            if (!canFade && currentFadeDuration == 0)
            {
                FadeIsFinished = false;
                currentFadeDuration = duration;
                alphaFade = 0.0f;

                fadeColor = color;
                fadeRectangle = new Texture2D(MainGame.Instance.GraphicsDevice, 1, 1);
                fadeRectangle.SetData(new Color[] { fadeColor });

                canFade = true;
            }

        }


        private static void Debug()
        {
            if (DEBUG_IS_ON)
            {
                CameraDebugArea = new Texture2D(MainGame.Instance.GraphicsDevice, 1, 1);
                CameraDebugArea.SetData(new Color[] { Color.White });
            }

            // Console.WriteLine("WORLDS BOUNDS : " + WorldBounds.X + " | " + WorldBounds.Width);
            // Console.WriteLine("Position X : " + Position.X + " | " + Position.Y);
        }
        

        /// <summary>
        /// Reinitialize the Camera
        /// </summary>
        public static void Unload()
        {
            Angle = 0f;
            Follow();
            StayFaded = false;
            FadeIsFinished = false;
            FlashIsFinished = false;
            ShakeIsFinished = false;
            canFade = false;

            currentFadeDuration = 0;
            OnCompleteFade = OnCompleteFlash = null;
            FadeIsFinished = true;
            alphaFade = 0;
            Position = Vector2.Zero;
            Offset = Vector2.Zero;
            Origin = Vector2.Zero;

            Zoom = 1.0f;

        }

        public static void Update(GameTime gameTime)
        {
            if (DEBUG_IS_ON) Debug();

            // Shake Effect
            #region
            if (canShake && !MainGame.IS_PAUSED)
            {
                currentShakeDuration -= (float)gameTime.ElapsedGameTime.TotalSeconds; //0.01f;

                if (currentShakeAxe != Axe.ANGLE)
                {
                    float shakeX = Util.RandomFloat(-currentShakeIntensity, currentShakeIntensity);
                    float shakeY = Util.RandomFloat(-currentShakeIntensity, currentShakeIntensity);

                    if (OldShakeIntensity != null)
                    {
                        if (shakeX < 0 && OldShakeIntensity.X < 0) shakeX = Math.Abs(shakeX);
                        if (shakeY < 0 && OldShakeIntensity.Y < 0) shakeY = Math.Abs(shakeY);

                        if (shakeX > 0 && OldShakeIntensity.X > 0) shakeX = -Math.Abs(shakeX);
                        if (shakeY > 0 && OldShakeIntensity.Y > 0) shakeY = -Math.Abs(shakeY);
                    }

                    switch (currentShakeAxe)
                    {
                        case Axe.HORIZONTAL_AND_VERTICAL:
                            Position = new Vector2(Position.X + shakeX, Position.Y + shakeY);
                            OldShakeIntensity = new Vector2(shakeX, shakeY);

                            break;

                        case Axe.HORIZONTAL:
                            Position = new Vector2(Position.X + shakeX,  Position.Y);

                            break;

                        case Axe.VERTICAL:
                            Position = new Vector2(Position.X, Position.Y + shakeY);
                            break;


                    }
                }

                else
                {
                    float newAngle = Util.RandomFloat(-currentShakeIntensity, currentShakeIntensity);
                    Angle = newAngle;
                }

            }

            if (currentShakeDuration < 0)
            {
                ShakeIsFinished = true;
                currentShakeDuration = 0;
                canShake = false;

                if (FollowingActor == null)
                    Camera.Position = Vector2.Zero;

                Angle = captureAngleValue;
                
            }

            #endregion

            // Flash Effect
            #region
            if (canFlash) alphaFlash -= (float)gameTime.ElapsedGameTime.TotalSeconds / currentFlashDuration;

            if (alphaFlash < 0)
            {
                
                currentFlashDuration = 0.0f;
                canFlash = false;

                if (OnCompleteFlash != null) OnCompleteFlash();
                FlashIsFinished = true;

                alphaFlash = 1.0f;
            }
            #endregion

            // Fade Effect
            #region
            if (canFade) alphaFade += (float)gameTime.ElapsedGameTime.TotalSeconds / currentFadeDuration;

            if (alphaFade > 1.0)
            {
                if (!StayFaded)
                {
                    currentFadeDuration = 0.0f;
                    canFade = false;
                }

                if (OnCompleteFade != null) OnCompleteFade();

                FadeIsFinished = true;
                alphaFade = 0;
                
            }

            #endregion

            if (Camera.Angle >= 360) Camera.Angle -= 360;
            if (Camera.Angle == 180) Camera.Origin = new Vector2(Camera.VisibleArea.Width, Camera.VisibleArea.Height);
            if (Camera.Angle == 0) Camera.Origin = Vector2.Zero;

            VisibleArea.X = (int)(Position.X );
            VisibleArea.Y = (int)(Position.Y );
            VisibleArea.Width = (int)(MainGame.WIDTH / Zoom);
            VisibleArea.Height = (int)(MainGame.HEIGHT / Zoom);

            if (AUTHORIZED_FORCED_ZOOM)
            {
                if (KBInput.JustPressed(Keys.PageUp)) Camera.Zoom += 0.1f;
                if (KBInput.JustPressed(Keys.PageDown)) Camera.Zoom -= 0.1f;
            }
        }


        public static void Draw()
        {
            if (DEBUG_IS_ON)
                MainGame.Instance.spriteBatch.Draw(CameraDebugArea, new Vector2(VisibleArea.X, VisibleArea.Y), Color.White *0.4f);

            if (canFlash) //MainGame.Instance.spriteBatch.Draw(flashRectangle,VisibleArea, Color.White * alphaFlash);
                Primitive.DrawRectangle(Primitive.PrimitiveStyle.FILL, MainGame.Instance.spriteBatch, VisibleArea.X - 4*VisibleArea.Width, VisibleArea.Y - 4*VisibleArea.Height, 10*VisibleArea.Width, 10*VisibleArea.Height, flashColor * alphaFlash);

            if (canFade)
                Primitive.DrawRectangle(Primitive.PrimitiveStyle.FILL, MainGame.Instance.spriteBatch, VisibleArea.X - 4 * VisibleArea.Width, VisibleArea.Y - 4 * VisibleArea.Height, 10 * VisibleArea.Width, 10 * VisibleArea.Height, fadeColor * alphaFade);


            // Primitive.DrawLine(MainGame.Instance.spriteBatch, new Vector2(InitialPosition.X + 200,Position.Y), new Vector2(InitialPosition.X + 200, VisibleArea.Y + VisibleArea.Height), Color.White,4);
        }

        // ==================== ADDITIONNAL ====================

        public static Vector2 ScreenToWorld(Vector2 pos)
        {
            return Vector2.Transform(pos, Matrix.Invert(Transformation));
        }

        public static Vector2 WorldToScreen(Vector2 pos)
        {
            return Vector2.Transform(pos, Transformation);
        }
    }
}
