using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace HydroGene
{
    class AnimatedSprite : Sprite
    {

        // Globals : 
        public int nbColumns { get; private set; }
        public int nbLines { get; private set; }

        /// <summary>
        /// Get the Width of the entire Sprite Sheet. To get the Width of 1 sprite, just use Width.
        /// </summary>
        public int SpritesheetWidth { get; private set; }

        /// <summary>
        /// Get the Height of the entire Sprite Sheet. To get the Height of 1 sprite, just use Height.
        /// </summary>
        public int SpritesheetHeight { get; private set; }

        private SpriteEffects flipEffect;

        private bool animationIsStopped { get; set; }
        public bool HasAnimationFinishedOnce { get; set; } = false;

        // Animations : 

        /// <summary>
        /// Represent the current frame who is playing. Can be change manually but it is not recommended.
        /// </summary>
        public int CurrentFrame;

        private Dictionary<string, int[]> ListAnimations;

        private int[] CurrentAnimation;

        /// <summary>
        /// Get the Name of the current animation
        /// </summary>
        public string CurrentAnimationName { get; private set; }

        private float globalSpeedAnimation = .2f;
        private double timeElapsed = 0;

        public bool IsAnimationFinish { get; set; }
        public bool IsAnimationLooped { get; set; }

        /// <summary>
        /// Create a new Animated Sprite.
        /// </summary>
        /// <param name="texture"> The Texture of the Animated Sprite. Here he should be a Sprite Sheet. </param>
        /// <param name="pos"> The Position of the Animated Sprite on the screen. </param>
        /// <param name="tileWidth"> The width of 1 sprite of the Sprite Sheet </param>
        /// <param name="tileHeight"> The height of 1 sprite of the Sprite Sheet </param>
        public AnimatedSprite(Texture2D texture, Vector2 pos, int tileWidth, int tileHeight) : base(texture)
        {
            this.Position = pos;

            // Nombre de colonne et de lignes de la spritesheet :
            this.nbColumns = texture.Width / tileWidth;
            this.nbLines = texture.Height / tileHeight;

            this.SpritesheetWidth = texture.Width;
            this.SpritesheetHeight = texture.Height;

            this.Width = tileWidth;
            this.Height = tileHeight;

            // Frame courrante (la 1ere frame est 0) :
            this.CurrentFrame = 0;
            CurrentAnimationName = null;

            this.ListAnimations = new Dictionary<string, int[]>();

            CurrentFrame = 0;
        }

        /// <summary>
        /// Create a new Animated Sprite
        /// </summary>
        /// <param name="texture"> The Texture of the Animated Sprite. Here he should be a Sprite Sheet. </param>
        /// <param name="tileWidth"> The width of 1 sprite of the Sprite Sheet </param>
        /// <param name="tileHeight"> The height of 1 sprite of the Sprite Sheet </param>
        public AnimatedSprite(Texture2D texture, int tileWidth, int tileHeight) : base(texture)
        {
            this.Position = Vector2.Zero;

            // Nombre de colonne et de lignes de la spritesheet :
            this.nbColumns = texture.Width / tileWidth;
            this.nbLines = texture.Height / tileHeight;

            this.SpritesheetWidth = texture.Width;
            this.SpritesheetHeight = texture.Height;

            this.Width = tileWidth;
            this.Height = tileHeight;

            // Frame courrante (la 1ere frame est 0) :
            this.CurrentFrame = 0;
            CurrentAnimationName = null;

            this.ListAnimations = new Dictionary<string, int[]>();

            CurrentFrame = 0;
        }

        public void RefreshTexture(Texture2D newTexture, ushort tileWidth, ushort tileHeight)
        {
            this.Texture = newTexture;

            // Nombre de colonne et de lignes de la spritesheet :
            this.nbColumns = Texture.Width / tileWidth;
            this.nbLines = Texture.Height / tileHeight;

            // Taille de la spritesheet entière : 
            this.SpritesheetWidth = Texture.Width;
            this.SpritesheetHeight = Texture.Height;

            // Taille d'1 tuile de la spritesheet : 
            this.Width = tileWidth;
            this.Height = tileHeight;
        }

        /// <summary>
        /// Add a new animation to this Animated Sprite.
        /// </summary>
        /// <param name="pName"> Give a name to this animation. </param>
        /// <param name="pFrames"> Give an array of all of frames this animation have. </param>
        public void AddAnimation(string pName, int[] pFrames)
        {
            ListAnimations.Add(pName, pFrames);
        }

        /// <summary>
        /// Delete an animation to this Animated Sprite. It will delete nothing if the name does not exist.
        /// </summary>
        /// <param name="pName">The name of the animation to delete</param>
        public void DeleteAnimation(string pName)
        {
            if (ListAnimations.ContainsKey(pName))
                ListAnimations.Remove(pName);
            else
                Debug.WriteLine("The animation named : " + pName + "does not exists.");
        }

        /// <summary>
        /// Force the restart of an animation to his initial state (Delete and Add the animation).
        /// </summary>
        /// <param name="pName">The name of the animation which need to be restarted.</param>
        public void RestartAnimation(string pName, int currentFrame = 0)
        {

            if (!ListAnimations.ContainsKey(pName))
                Debug.WriteLine("The animation named : " + pName + "does not exists.");
            else
            {
                int[] pFrames = ListAnimations[pName];
                DeleteAnimation(pName);

                AddAnimation(pName, pFrames);

                CurrentFrame = currentFrame;
                CurrentAnimation = ListAnimations[pName];
                CurrentAnimationName = pName;

                IsAnimationFinish = false;
                timeElapsed = 0;

                HasAnimationFinishedOnce = false;
            }
        }

        /// <summary>
        /// Play an animation.
        /// </summary>
        /// <param name="pName"> The name of the animation you want to play. </param>
        /// <param name="pSpeed"> The speed of the animation. By default it's set to 0.1f </param>
        public void PlayAnimation(string pName, float pSpeed = 0.1f, bool isLooped = true)
        {
            globalSpeedAnimation = pSpeed;

            if (CurrentAnimationName == null || CurrentAnimationName != pName || (IsAnimationFinish && isLooped))
            {
                CurrentFrame = 0;
                CurrentAnimation = ListAnimations[pName];
                CurrentAnimationName = pName;

                IsAnimationLooped = isLooped;
                IsAnimationFinish = false;
                timeElapsed = 0;

                HasAnimationFinishedOnce = false;
            }

            if (timeElapsed >= globalSpeedAnimation)
            {
                timeElapsed -= globalSpeedAnimation;
                CurrentFrame++;

            }

            if (CurrentFrame >= CurrentAnimation.Length)
            {
                HasAnimationFinishedOnce = true;
                // IsAnimationFinish = !IsAnimationLooped;
                IsAnimationFinish = true;

                CurrentFrame = IsAnimationLooped ? 0 : CurrentAnimation.Length - 1;

            }
        }

        /// <summary>
        /// Stop the current Animation.
        /// </summary>
        public void StopAnimation()
        {
            animationIsStopped = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (!MainGame.IS_PAUSED && IsActive)
            {
                base.Update(gameTime);

                if (CurrentAnimationName != null)
                {
                    timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
                    PlayAnimation(CurrentAnimationName, globalSpeedAnimation, IsAnimationLooped);
                }

                if ((int)Math.Abs(Angle) == 90)
                    this.BoundingBox = new Rectangle((int)(this.Position.X - (this.Width * Scale.X) / 2),
                                                     (int)(this.Position.Y - (this.Height * Scale.Y) / 2),
                                                     (int)(this.Height * Scale.Y),
                                                     (int)(this.Width * Scale.X));

                else
                    this.BoundingBox = new Rectangle((int)this.Position.X,
                                                     (int)this.Position.Y,
                                                     (int)(this.Width * Scale.X),
                                                     (int)(this.Height * Scale.Y));

            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // Traitement du flip
            flipEffect = SpriteEffects.None;
            if (Flip.X) flipEffect = SpriteEffects.FlipHorizontally;
            if (Flip.Y) flipEffect = SpriteEffects.FlipVertically;
            if (Flip.X && Flip.Y) flipEffect = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

            int tilesetColumn = 0; int tilesetLine = 0;
            if (CurrentAnimation != null)
            {
                tilesetColumn = CurrentAnimation[CurrentFrame] % (nbColumns);
                tilesetLine = (int)(CurrentAnimation[CurrentFrame] / (nbColumns));
            }

            Rectangle tilesetRec = new Rectangle(Width * tilesetColumn, Height * tilesetLine, Width, Height);

            if (IsVisible && IsActive)
            {
                // Effects : 
                if (ActiveEffectTrail)
                {
                    foreach (Vector2 trailPosition in listTrailPosition)
                    {
                        spriteBatch.Draw(this.Texture,
                                 trailPosition,
                                 tilesetRec,
                                 this.Color * (listTrailPosition.IndexOf(trailPosition) / 100f),
                                 MathHelper.ToRadians(this.Angle),
                                 this.Origin,
                                 this.Scale,
                                 flipEffect,
                                 0
                                 );
                    }
                }


                spriteBatch.Draw(this.Texture,
                                 this.Position,
                                 tilesetRec,
                                 this.Color * this.Alpha,
                                 MathHelper.ToRadians(this.Angle),
                                 this.Origin,
                                 this.Scale,
                                 flipEffect,
                                 0
                                 );

                if (DrawBoundingBox)
                    Primitive.DrawRectangle(Primitive.PrimitiveStyle.FILL, spriteBatch, BoundingBox.X, BoundingBox.Y, BoundingBox.Width, BoundingBox.Height, BoundingBoxColor * 0.5f);

            }

        }

    }

}
