using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace HydroGene
{
    public class Screen
    {
        public Color ClearColor = Color.Black;
        public SamplerState SamplerState = SamplerState.PointClamp;
        public Vector2 Offset = Vector2.Zero;
        public Vector2 OffsetAdd = Vector2.Zero;
        private float scale = 1f;
        private float OrigScale = 1f;
        public Rectangle DrawRect;
        public Effect Effect;
        public float PadOffset;
        public Matrix Matrix;
        private Viewport viewport;
        private Rectangle screenRect;
        private int width;
        private int height;
        private MainGame mainGame;

        public GraphicsDeviceManager Graphics
        {
            get
            {
                return mainGame?.graphics;
            }
        }

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                return mainGame?.GraphicsDevice;
            }
        }

        public RenderTarget2D RenderTarget { get; private set; }

        public Screen(MainGame game, int width, int height, float scale)
        {
            mainGame = game;
            screenRect = this.DrawRect = new Rectangle(0, 0, width, height);
            viewport = new Viewport();
            this.width = width;
            this.height = height;
            this.scale = OrigScale = scale;
            DrawRect.Width = this.viewport.Width = (int)((double)this.screenRect.Width * (double)scale);
            DrawRect.Height = this.viewport.Height = (int)((double)this.screenRect.Height * (double)scale);
            SetWindowSize(this.DrawRect.Width, this.DrawRect.Height);

            
        }

        public void Initialize()
        {
            Dispose();
            
            RenderTarget = new RenderTarget2D(GraphicsDevice, this.screenRect.Width, this.screenRect.Height);

           // Effect = AssetManager.EffectSepia;
        }

        public void Dispose()
        {
            if (RenderTarget == null)
                return;
            RenderTarget.Dispose();
        }

        public void Resize(int width, int height, float scale)
        {
            this.screenRect = this.DrawRect = new Rectangle(0, 0, width, height);
            this.viewport = new Viewport();
            this.width = width;
            this.height = height;
            this.scale = scale;
            this.DrawRect.Width = this.viewport.Width = (int)((double)this.screenRect.Width * (double)scale);
            this.DrawRect.Height = this.viewport.Height = (int)((double)this.screenRect.Height * (double)scale);
            if (this.IsFullscreen)
            {
                this.Scale = Math.Min((float)this.GraphicsDevice.DisplayMode.Width / (float)this.screenRect.Width, (float)this.GraphicsDevice.DisplayMode.Height / (float)this.screenRect.Height);
                this.HandleFullscreenViewport();
            }
            else
                this.SetWindowSize(this.DrawRect.Width, this.DrawRect.Height);
            this.Initialize();
        }

        public void Render()
        {
            this.GraphicsDevice.Viewport = this.viewport;
            mainGame.spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Opaque, this.SamplerState, DepthStencilState.None, RasterizerState.CullNone, Effect);

            if (Effect != null)
                Effect.CurrentTechnique.Passes[0].Apply();

            Vector2 vector2 = Offset + OffsetAdd;
            if (vector2 == Vector2.Zero)
            {
                mainGame.spriteBatch.Draw((Texture2D)this.RenderTarget, this.DrawRect, new Rectangle?(this.screenRect), Color.White);
            }
            else
            {
                vector2.X = (float)(((double)vector2.X + 320.0) % 320.0);
                vector2.Y = (float)(((double)vector2.Y + 240.0) % 240.0);
                if ((double)vector2.X == 0.0)
                {
                    int num = (int)Math.Round((double)vector2.Y * (double)this.Scale, MidpointRounding.AwayFromZero);
                    mainGame.spriteBatch.Draw((Texture2D)this.RenderTarget, new Rectangle(this.DrawRect.X, this.DrawRect.Y + num, this.DrawRect.Width, this.DrawRect.Height), new Rectangle?(this.screenRect), Color.White);
                    mainGame.spriteBatch.Draw((Texture2D)this.RenderTarget, new Rectangle(this.DrawRect.X, this.DrawRect.Y + (num >= 0 ? num - (int)((double)this.Height * (double)this.Scale) : num + (int)((double)this.Height * (double)this.Scale)), this.DrawRect.Width, this.DrawRect.Height), new Rectangle?(this.screenRect), Color.White);
                }
                else if ((double)vector2.Y == 0.0)
                {
                    int num = (int)Math.Round((double)vector2.X * (double)this.Scale, MidpointRounding.AwayFromZero);
                    mainGame.spriteBatch.Draw((Texture2D)this.RenderTarget, new Rectangle(this.DrawRect.X + num, this.DrawRect.Y, this.DrawRect.Width, this.DrawRect.Height), new Rectangle?(this.screenRect), Color.White);
                    mainGame.spriteBatch.Draw((Texture2D)this.RenderTarget, new Rectangle(this.DrawRect.X + (num >= 0 ? num - (int)((double)this.Width * (double)this.Scale) : num + (int)((double)this.Width * (double)this.Scale)), this.DrawRect.Y, this.DrawRect.Width, this.DrawRect.Height), new Rectangle?(this.screenRect), Color.White);
                }
                else
                {
                    int num1 = (int)Math.Round((double)vector2.X * (double)this.Scale, MidpointRounding.AwayFromZero);
                    int num2 = (int)Math.Round((double)vector2.Y * (double)this.Scale, MidpointRounding.AwayFromZero);
                    int num3 = num1 < 0 ? num1 + (int)((double)this.Width * (double)this.Scale) : num1 - (int)((double)this.Width * (double)this.Scale);
                    int num4 = num2 < 0 ? num2 + (int)((double)this.Height * (double)this.Scale) : num2 - (int)((double)this.Height * (double)this.Scale);
                    mainGame.spriteBatch.Draw((Texture2D)this.RenderTarget, new Rectangle(this.DrawRect.X + num1, this.DrawRect.Y + num2, this.DrawRect.Width, this.DrawRect.Height), new Rectangle?(this.screenRect), Color.White);
                    mainGame.spriteBatch.Draw((Texture2D)this.RenderTarget, new Rectangle(this.DrawRect.X + num1, this.DrawRect.Y + num4, this.DrawRect.Width, this.DrawRect.Height), new Rectangle?(this.screenRect), Color.White);
                    mainGame.spriteBatch.Draw((Texture2D)this.RenderTarget, new Rectangle(this.DrawRect.X + num3, this.DrawRect.Y + num2, this.DrawRect.Width, this.DrawRect.Height), new Rectangle?(this.screenRect), Color.White);
                    mainGame.spriteBatch.Draw((Texture2D)this.RenderTarget, new Rectangle(this.DrawRect.X + num3, this.DrawRect.Y + num4, this.DrawRect.Width, this.DrawRect.Height), new Rectangle?(this.screenRect), Color.White);
                }
            }
            mainGame.spriteBatch.End();
        }

        public float Scale
        {
            get
            {
                return this.scale;
            }
            set
            {
                if ((double)this.scale == (double)value)
                    return;
                this.scale = value;
                this.DrawRect.Width = this.viewport.Width = (int)((double)this.screenRect.Width * (double)this.scale);
                this.DrawRect.Height = this.viewport.Height = (int)((double)this.screenRect.Height * (double)this.scale);
                if (this.IsFullscreen)
                    this.HandleFullscreenViewport();
                else
                    this.SetWindowSize(this.ScaledWidth, this.ScaledHeight);
            }
        }

        private void SetWindowSize(int width, int height)
        {
            this.Graphics.IsFullScreen = false;
            this.Graphics.PreferredBackBufferWidth = width;
            this.Graphics.PreferredBackBufferHeight = height;
            this.Graphics.ApplyChanges();
            this.viewport.Width = width;
            this.viewport.Height = this.ScaledHeight;
            this.viewport.X = 0;
            this.viewport.Y = (height - this.ScaledHeight) / 2;
            this.DrawRect.X = width / 2 - this.ScaledWidth / 2;
            this.Matrix = Matrix.CreateScale(this.scale) * Matrix.CreateTranslation((float)this.DrawRect.X, 0.0f, 0.0f);
        }

        public void HandleFullscreenViewport()
        {
            this.viewport.Width = this.GraphicsDevice.DisplayMode.Width;
            this.viewport.Height = this.ScaledHeight;
            this.viewport.X = 0;
            this.viewport.Y = (this.GraphicsDevice.DisplayMode.Height - this.ScaledHeight) / 2;
            this.DrawRect.X = this.viewport.Width / 2 - this.ScaledWidth / 2;
            this.Matrix = Matrix.CreateScale(this.scale) * Matrix.CreateTranslation((float)this.DrawRect.X, 0.0f, 0.0f);
        }

        public void EnableFullscreen(Screen.FullscreenMode mode = Screen.FullscreenMode.LargestScale)
        {
            this.Graphics.IsFullScreen = true;
            this.Graphics.PreferredBackBufferWidth = this.GraphicsDevice.DisplayMode.Width;
            this.Graphics.PreferredBackBufferHeight = this.GraphicsDevice.DisplayMode.Height;
            this.Graphics.ApplyChanges();
            switch (mode)
            {
                case Screen.FullscreenMode.LargestScale:
                    this.Scale = Math.Min((float)this.GraphicsDevice.DisplayMode.Width / (float)this.screenRect.Width, (float)this.GraphicsDevice.DisplayMode.Height / (float)this.screenRect.Height);
                    break;
                case Screen.FullscreenMode.LargestIntegerScale:
                    this.Scale = (float)Math.Floor((double)Math.Min((float)this.GraphicsDevice.DisplayMode.Width / (float)this.screenRect.Width, (float)this.GraphicsDevice.DisplayMode.Height / (float)this.screenRect.Height));
                    break;
            }
            this.HandleFullscreenViewport();
        }

        public void DisableFullscreen(float newScale)
        {
            Graphics.IsFullScreen = false;
            Graphics.ApplyChanges();
            scale = newScale;
            DrawRect.Width = this.viewport.Width = (int)((double)this.screenRect.Width * (double)this.scale);
            DrawRect.Height = this.viewport.Height = (int)((double)this.screenRect.Height * (double)this.scale);
            SetWindowSize(this.ScaledWidth, this.ScaledHeight);
        }

        public void DisableFullscreen()
        {
            DisableFullscreen(OrigScale);
        }

        public int ScaledWidth
        {
            get
            {
                return (int)((double)width * (double)scale);
            }
        }

        public int ScaledHeight
        {
            get
            {
                return (int)((double)height * (double)scale);
            }
        }

        public bool IsFullscreen
        {
            get
            {
                return Graphics.IsFullScreen;
            }
        }

        public Vector2 Size
        {
            get
            {
                return new Vector2((float)Width, (float)Height);
            }
        }

        public int Width
        {
            get
            {
                return RenderTarget.Width;
            }
        }

        public int Height
        {
            get
            {
                return RenderTarget.Height;
            }
        }

        public Vector2 Center
        {
            get
            {
                return Size * 0.5f;
            }
        }

        public enum FullscreenMode
        {
            KeepScale,
            LargestScale,
            LargestIntegerScale,
        }
    }
}
