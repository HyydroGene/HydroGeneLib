using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{
    public interface IActor
    {
        Vector2 Position { get; }
        Rectangle BoundingBox { get; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void TouchedBy(IActor By);
        bool ToRemove { get; set; }
        bool IsOnScreen();
        bool IsActive { get; set; }
        bool IsVisible { get; set; }
    }
}
