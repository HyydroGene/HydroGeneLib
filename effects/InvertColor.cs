using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HydroGene
{
    class InvertColors : PostProcessingEffect
    {
        private RenderTarget2D buffer;
        private BlendState blendState;

        public InvertColors(GraphicsDevice device, SpriteBatch spriteBatch) : base(device, spriteBatch)
        {

            // Final Color = -(SourceColor * One) + (DestinationColor * One)
            // If Destination Color is white, to have inversion!
            blendState = new BlendState();
            blendState.ColorBlendFunction = BlendFunction.ReverseSubtract;
            blendState.AlphaBlendFunction = BlendFunction.ReverseSubtract;
            blendState.AlphaSourceBlend = blendState.ColorSourceBlend = Blend.One;
            blendState.AlphaDestinationBlend = blendState.ColorDestinationBlend = Blend.One;

            buffer = new RenderTarget2D(graphicsDevice, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
        }

        public override Texture2D Apply(Texture2D input, GameTime gameTime)
        {
            graphicsDevice.SetRenderTarget(MainGame.Instance.Screen.RenderTarget);

            // Make sure we have white in the target
            graphicsDevice.Clear(Color.White);
            // Draw the image with the above defined blendState, to obtain the inverted color
            spriteBatch.Begin(SpriteSortMode.Deferred, blendState);
            spriteBatch.Draw(input, Camera.Position, Color.White);
            spriteBatch.End();

            graphicsDevice.SetRenderTarget(null);
            return buffer;
        }
    }
}
