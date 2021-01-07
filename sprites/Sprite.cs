using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HydroGene
{
    /// <summary>
    /// Represent a Flip Effect. It's like a Vector2, but this one contain Boolean.
    /// </summary>
    public struct Flip
    {
        public bool X;
        public bool Y;

        public Flip(bool x = false, bool y = false)
        {
            X = x;
            Y = y;
        }
    }

    public class Sprite : IActor
    {

        // IActor

        /// <summary>
        /// Position of the Sprite on the Screen. If you don't set anything, this value will be Vector2.Zero
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// The Origin of the Sprite. By default it's set to the upper left corner, so the value is Vector2.Zero.
        /// </summary>
        public Vector2 Origin { get; set; }

        /// <summary>
        /// Give a name to the sprite. It's optionnal, this can make your sprite unique.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Width of the Sprite. It's faster to call it from here.
        /// </summary>
        public int Width { get; protected set; }

        /// <summary>
        /// The Height of the Sprite. It's faster to call it from here.
        /// </summary>
        public int Height { get; protected set; }

        /// <summary>
        /// Represent a kind of Speed Variable so you don't need to create one to put it on your Velocity or Acceleration.
        /// </summary>
        public Vector2 Drag { get; set; } // Variable that can be used like a "speed" variable to move object. We usually apply it on Velocity.

        /// <summary>
        /// Represent the Hitbox of the current Sprite. By default it as bigger as the sprite Size multiply by his Scale.
        /// </summary>
        public Rectangle BoundingBox { get; set; }

        /// <summary>
        /// Authorized to print the Bounding Box on the screen. You can change his color by using BoundingBoxColor.
        /// </summary>
        public bool DrawBoundingBox { get; set; } = false;

        /// <summary>
        /// The Color of the Bounding Box. By default it's Red.
        /// </summary>
        public Color BoundingBoxColor { get; set; } = Color.Red;

        /// <summary>
        /// The Velocity of the Sprite
        /// </summary>
        public Vector2 Velocity;

        /// <summary>
        /// The Friction of the Sprite. By default it is set to 0.
        /// </summary>
        public Vector2 Friction = Vector2.Zero;

        /// <summary>
        ///  The Angle/Rotation of the sprite. You don't need to convert it, it's will be done directly.
        /// </summary>
        public float Angle;

        /// <summary>
        /// The Color of the sprite. By default it's White.
        /// </summary>
        public Color Color;

        /// <summary>
        /// The Alpha/Transparency of the sprite. If the value goes upper than 1.0f or lower than 0f, it will be blocked to these value automatically, so you don't need to do it.
        /// </summary>
        public float Alpha;

        /// <summary>
        /// The Scale of the Sprite for X and Y axis. By default it's a Vector2.One
        /// </summary>
        public Vector2 Scale;

        /// <summary>
        ///  Apply a flip Effect on the sprite. By default Flip.x and Flip.y is equal to false. Just change the boolean to apply the effect.
        /// </summary>
        public Flip Flip;

        /// <summary>
        /// Pass this variable to true to remove it to the listActor of you scene, and remove it from the screen. Don't forget to call Clean() function in your Update() function of your Scene or it will do nothing.
        /// </summary>
        public bool ToRemove { get; set; }

        

        // Sprite

        /// <summary>
        /// The Texture of the Sprite. Can be change manually.
        /// </summary>
        public Texture2D Texture { get; set; } 

        private SpriteEffects flipEffect;

        /// <summary>
        /// Indicate if you want the actor to be Visible. If this variable is put to false, it will stop drawing it. The Draw() function of this sprite will not be called anymore.
        /// </summary>
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// Indicate if you want the actor to be Active. If this variable is put to false, it will stop Update and Drawing it.
        /// </summary>
        public bool IsActive { get; set; } = true;

        // Blink Effect
        public bool EffectBlink = false;
        public float timerVisible = 0.5f;
        public float BlinkFrequency = 0.5f;

        private Util.Alignement Align { get; set; }

        // Trail Effects
        protected internal List<Vector2> listTrailPosition;
        protected internal bool ActiveEffectTrail = false;
        protected internal List<float> listAngle = new List<float>();

        /// <summary>
        /// Number of frame for TrailEffect. Do not use it directly. Use EffectTrail() instead
        /// </summary>
        protected internal int MaxPosition;
        private Timer TrailUpdateTimer = new Timer(0.1f);

        /// <summary>
        /// Create a new Sprite. Don't forget to add it to the listActor of your scene to see it on screen.
        /// </summary>
        /// <param name="texture"> The Texture of the sprite </param>
        public Sprite(Texture2D texture)
        {
           Texture = texture;

            Angle = 0.0f;
            Alpha = 1.0f;
            Color = Color.White;
            Scale = new Vector2(1.0f, 1.0f);

            Flip = new Flip();

            Velocity = new Vector2(0,0);

            Origin = Vector2.Zero;

            ToRemove = false;

            Width = Texture.Width;
            Height = Texture.Height;

            flipEffect = SpriteEffects.None;

            // Effects : 
            listTrailPosition = new List<Vector2>();

            Align = Util.Alignement.NONE;

        }

        /// <summary>
        ///  Function to write if you want to do something when this sprite collide with an other actor
        /// </summary>
        /// <param name="By"> Represent the IActor who touch this sprite </param>
        public virtual void TouchedBy(IActor By)
        {

        }

        /// <summary>
        /// Move the sprite and apply friction to it. By default you don't need to call this function.
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        public void Move(float posX, float posY)
        {
            Position = new Vector2(Position.X + posX, Position.Y + posY);

            // Gestion Friction
            if (this.Velocity.X < 0)
            {
                this.Velocity.X += this.Friction.X;
                if (this.Velocity.X > 0)
                {
                    this.Velocity.X = 0;
                }
            }

            if (this.Velocity.X > 0)
            {
                this.Velocity.X -= this.Friction.X;
                if (this.Velocity.X < 0)
                {
                    this.Velocity.X = 0;
                }
            }

            if (this.Velocity.Y < 0)
            {
                this.Velocity.Y += this.Friction.Y;
                if (this.Velocity.Y > 0)
                {
                    this.Velocity.Y = 0;
                }
            }

            if (this.Velocity.Y > 0)
            {
                this.Velocity.Y -= this.Friction.Y;
                if (this.Velocity.Y < 0)
                {
                    this.Velocity.Y = 0;
                }
            }
        }

        /// <summary>
        /// Check if the current sprite is visible on the screen.
        /// </summary>
        /// <returns></returns>
        public bool IsOnScreen()
        {
            if (Util.Overlaps(this, Camera.VisibleArea)) return true;
            return false;
        }

        protected void RefreshTexture(Texture2D newTexture)
        {
            Texture = newTexture;
            Width = Texture.Width;
            Height = Texture.Height;
        }

        protected void RefreshTexture(Texture2D newTexture, Vector2 newScale)
        {
            Texture = newTexture;
            Width = Texture.Width;
            Height = Texture.Height;
            Scale = newScale;
        }


        #region Trail Effect

        /// <summary>
        /// Add a Trail Effect on the sprite
        /// </summary>
        /// <param name="frameUpdate"> Add a new sprite every "x" seconds. By default it's 0.01f </param>
        /// <param name="nbMaxPosition"> Length of the trail effect. By default it's 25  </param>
        public void EffectTrail(float frameUpdate = 0.01f, int nbMaxPosition = 25)
        {
            if (!ActiveEffectTrail)
            {
                if (TrailUpdateTimer == null) TrailUpdateTimer = new Timer(frameUpdate);
                else TrailUpdateTimer.ChangeTimerValue(frameUpdate);

                ActiveEffectTrail = true;
            }

            MaxPosition = nbMaxPosition;

        }

        /// <summary>
        /// Stop the Trail Effect
        /// </summary>
        public void StopEffectTrail()
        {
            ActiveEffectTrail = false;

            listTrailPosition.RemoveAll(item => item != Vector2.Zero);
            
            //listTrailPosition.RemoveRange(0, listTrailPosition.Count);
        }

        #endregion

        public virtual void Update(GameTime gameTime)
        {
        
            if (!MainGame.IS_PAUSED && IsActive)
            {
                Move(Velocity.X, Velocity.Y);
                BoundingBox = new Rectangle((int)Position.X,
                                            (int)Position.Y,
                                            (int)(Texture.Width * Scale.X), // Texture.Width
                                            (int)(Texture.Height * Scale.Y)); // Texture.Height

                // Traitement des débordements de l'alpha : 
                if (Alpha >= 1.0f) Alpha = 1.0f;
                else if (Alpha <= 0f) Alpha = 0f;

                #region Trail Effect
                if (ActiveEffectTrail)
                {
                    TrailUpdateTimer.Update(gameTime);
                    TrailUpdateTimer.OnComplete = delegate () { listTrailPosition.Add(this.Position); listAngle.Add(this.Angle); };

                    if (listTrailPosition.Count > MaxPosition)
                    {
                        listTrailPosition.RemoveAt(0);
                        listAngle.RemoveAt(0);
                    }
                }
                #endregion

                #region Align
                switch (Align)
                {
                    case Util.Alignement.CENTER_X:
                        this.Position = new Vector2(Camera.Position.X + (Camera.VisibleArea.Width / 2 - this.Width / 2), this.Position.Y);
                        break;

                    case Util.Alignement.CENTER_Y:
                        this.Position = new Vector2(this.Position.X, Camera.Position.Y + (Camera.VisibleArea.Height / 2 - this.Height / 2));
                        break;

                    case Util.Alignement.CENTER_X | Util.Alignement.CENTER_Y:
                        this.Position = new Vector2(Camera.Position.X + (Camera.VisibleArea.Width / 2 - this.Width / 2), this.Position.Y);
                        this.Position = new Vector2(this.Position.X, Camera.Position.Y + (Camera.VisibleArea.Height / 2 - this.Height / 2));
                        break;
                }
                #endregion

                #region Blink
                if (EffectBlink)
                {
                    timerVisible -= 0.01f;

                    if (timerVisible < 0)
                    {
                        if (this.IsVisible)
                            timerVisible = BlinkFrequency / 2f;

                        else timerVisible = BlinkFrequency;

                        this.IsVisible = !this.IsVisible;
                    }
                }

                #endregion

            }

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            // Traitement du flip
            flipEffect = SpriteEffects.None;
            if (Flip.X) flipEffect = SpriteEffects.FlipHorizontally;
            if (Flip.Y) flipEffect = SpriteEffects.FlipVertically;
            if (Flip.X && Flip.Y) flipEffect = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;


            if (IsActive && IsVisible)
            {

                if (ActiveEffectTrail)
                {
                    foreach (Vector2 trailPosition in listTrailPosition)
                    {
                        spriteBatch.Draw(this.Texture,
                                 trailPosition,
                                 null,
                                 this.Color * (listTrailPosition.IndexOf(trailPosition) / 100f),
                                 MathHelper.ToRadians((float)Angle),
                                 this.Origin,
                                 this.Scale,
                                 flipEffect,
                                 0
                                 );
                    }
                }


                if (Texture != null)
                    spriteBatch.Draw(Texture,
                                     Position,
                                     null,
                                     Color * Alpha,
                                     MathHelper.ToRadians((float)Angle),
                                     Origin,
                                     Scale,
                                     flipEffect,
                                     0
                                     );

                if (DrawBoundingBox)
                    Primitive.DrawRectangle(Primitive.PrimitiveStyle.FILL, spriteBatch, BoundingBox.X, BoundingBox.Y, BoundingBox.Width, BoundingBox.Height, BoundingBoxColor * 0.5f);
            }

        }

    }
}
