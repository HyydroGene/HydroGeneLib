using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{
    class PostProcessingEffect
    {
        protected GraphicsDevice graphicsDevice;
        protected SpriteBatch spriteBatch;

        public PostProcessingEffect(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            this.graphicsDevice = graphicsDevice;
            this.spriteBatch = spriteBatch;
        }

        public virtual Texture2D Apply(Texture2D input, GameTime gameTime)
        {
            return input;
        }
    }
}
