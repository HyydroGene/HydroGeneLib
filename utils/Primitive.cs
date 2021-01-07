using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{
    static class Primitive
    {

        /// <summary>
        /// The Style of Drawing you want for the Primitives.
        /// </summary>
        public enum PrimitiveStyle : byte
        {
            LINE,
            FILL
        } 

        public static Texture2D pixel { get; private set; }

        private static void CreatePixel(SpriteBatch spriteBatch)
        {
            pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });
        }

        /// <summary>
        /// Create a texture with a 1 pixel consistency.
        /// </summary>
        /// <returns></returns>
        public static Texture2D CreatePixel()
        {
            pixel = new Texture2D(MainGame.Instance.spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });

            return pixel;
        }

        /// <summary>
        /// Draw a line on the screen.
        /// </summary>
        /// <param name="spriteBatch"> You have to pass a spritebatch in order to draw it.</param>
        /// <param name="startPoint"> The first coordinate which represent the beginning of the line. </param>
        /// <param name="endPoint"> The second coordinate which represente the end of the line. </param>
        /// <param name="color"> The color of the line.</param>
        /// <param name="thickness"> The thickness of the line. By default it is set to 1. </param>
        public static void DrawLine(SpriteBatch spriteBatch, Vector2 startPoint, Vector2 endPoint,Color color, int thickness = 1)
        {
            if (pixel == null) CreatePixel(spriteBatch);

            Vector2 edge = endPoint - startPoint;
            float angle = (float)Math.Atan2(edge.Y, edge.X);

            spriteBatch.Draw(pixel,new Rectangle((int)startPoint.X,(int)startPoint.Y,(int)edge.Length(), thickness), //width of line, change this to make thicker line
                            null,
                            color, 
                            angle,     
                            new Vector2(0, 0),
                            SpriteEffects.None,
                            0);

        }

        private static void DrawLine(SpriteBatch spriteBatch, Vector2 position, Vector2 destination, Color color, float thickness = 1, float angle = 0)
        {
            if (pixel == null) CreatePixel(spriteBatch);

            spriteBatch.Draw(pixel, position, null, color, angle, Vector2.Zero, destination,
                             SpriteEffects.None,
                             0);
        }

        /// <summary>
        /// Draw a rectangle on the screen.
        /// </summary>
        /// <param name="style"> The style of draw you want. Fill or Line. </param>
        /// <param name="spriteBatch"> You have to pass a spritebatch in order to draw it on the screen. </param>
        /// <param name="posX"> The X position of the rectangle </param>
        /// <param name="posY"> The Y position of the rectangle </param>
        /// <param name="width"> The width of the rectangle </param>
        /// <param name="height"> The height of the rectangle </param>
        /// <param name="color"> The color of the rectangle </param>
        /// <param name="thickness"> the thickness of the rectangle</param>
        /// <param name="angle"> The angle of th rectangle. </param>

        #region Draw Rectangle
        public static void DrawRectangle(PrimitiveStyle style, SpriteBatch spriteBatch,float posX,float posY, int width, int height, Color color,float thickness = 0, float angle = 0)
        {
            if (pixel == null) CreatePixel(spriteBatch);


            switch(style)
            {
                case PrimitiveStyle.FILL:
                    DrawLine(spriteBatch, new Vector2(posX, posY), new Vector2(width, height), color,thickness); // Fill mode !
                    break;
                    
                case PrimitiveStyle.LINE:
                    DrawLine(spriteBatch, new Vector2(posX, posY), new Vector2(width + thickness, 1 + thickness), color,1.0f); // Top side
                    DrawLine(spriteBatch, new Vector2(posX + width, posY), new Vector2(1 + thickness, height + thickness), color,1.0f); // Right Side
                    DrawLine(spriteBatch, new Vector2(posX, posY + height), new Vector2(width + thickness, 1 + thickness), color,1.0f); // Bottom Side
                    DrawLine(spriteBatch, new Vector2(posX, posY), new Vector2(1 + thickness, height + thickness), color,1.0f); // Left Side
                    break;
                    

                default:
                    break;
            }

        }

        public static void DrawRectangle(PrimitiveStyle style, SpriteBatch spriteBatch,Rectangle Rectangle, Color color, float thickness = 0, float angle = 0)
        {
            if (pixel == null) CreatePixel(spriteBatch);


            switch (style)
            {
                case PrimitiveStyle.FILL:
                    DrawLine(spriteBatch, new Vector2(Rectangle.X, Rectangle.Y), new Vector2(Rectangle.Width, Rectangle.Height), color, thickness); // Fill mode !
                    break;

                case PrimitiveStyle.LINE:
                    DrawLine(spriteBatch, new Vector2(Rectangle.X, Rectangle.Y), new Vector2(Rectangle.Width + thickness, 1 + thickness), color, 1.0f); // Top side
                    DrawLine(spriteBatch, new Vector2(Rectangle.X + Rectangle.Width, Rectangle.Y), new Vector2(1 + thickness, Rectangle.Height + thickness), color, 1.0f); // Right Side
                    DrawLine(spriteBatch, new Vector2(Rectangle.X, Rectangle.Y + Rectangle.Height), new Vector2(Rectangle.Width + thickness, 1 + thickness), color, 1.0f); // Bottom Side
                    DrawLine(spriteBatch, new Vector2(Rectangle.X, Rectangle.Y), new Vector2(1 + thickness, Rectangle.Height + thickness), color, 1.0f); // Left Side
                    break;


                default:
                    break;
            }

        }

        public static void DrawRectangle(PrimitiveStyle style, SpriteBatch spriteBatch, Vector2 Position, Vector2 Size, Color color, float thickness = 0, float angle = 0)
        {
            if (pixel == null) CreatePixel(spriteBatch);


            switch (style)
            {
                case PrimitiveStyle.FILL:
                    DrawLine(spriteBatch, new Vector2(Position.X, Position.Y), new Vector2(Size.X, Size.Y), color, thickness); // Fill mode !
                    break;

                case PrimitiveStyle.LINE:
                    DrawLine(spriteBatch, new Vector2(Position.X, Position.Y), new Vector2(Size.X + thickness, 1 + thickness), color, 1.0f); // Top side
                    DrawLine(spriteBatch, new Vector2(Position.X + Size.X, Position.Y), new Vector2(1 + thickness, Size.Y + thickness), color, 1.0f); // Right Side
                    DrawLine(spriteBatch, new Vector2(Position.X, Position.Y + Size.Y), new Vector2(Size.X + thickness, 1 + thickness), color, 1.0f); // Bottom Side
                    DrawLine(spriteBatch, new Vector2(Position.X, Position.Y), new Vector2(1 + thickness, Size.Y + thickness), color, 1.0f); // Left Side
                    break;


                default:
                    break;
            }

        }

        public static void DrawRectangle(PrimitiveStyle style, SpriteBatch spriteBatch, Vector2 Position, int width, int height, Color color, float thickness = 0, float angle = 0)
        {
            if (pixel == null) CreatePixel(spriteBatch);


            switch (style)
            {
                case PrimitiveStyle.FILL:
                    DrawLine(spriteBatch, new Vector2(Position.X, Position.Y), new Vector2(width, height), color, thickness); // Fill mode !
                    break;

                case PrimitiveStyle.LINE:
                    DrawLine(spriteBatch, new Vector2(Position.X, Position.Y), new Vector2(width + thickness, 1 + thickness), color, 1.0f); // Top side
                    DrawLine(spriteBatch, new Vector2(Position.X + width, Position.Y), new Vector2(1 + thickness, height + thickness), color, 1.0f); // Right Side
                    DrawLine(spriteBatch, new Vector2(Position.X, Position.Y + height), new Vector2(width + thickness, 1 + thickness), color, 1.0f); // Bottom Side
                    DrawLine(spriteBatch, new Vector2(Position.X, Position.Y), new Vector2(1 + thickness, height + thickness), color, 1.0f); // Left Side
                    break;


                default:
                    break;
            }

        }

        #endregion

        /// <summary>
        /// Draw a circle on the screen.
        /// </summary>
        /// <param name="style"> The style of drawing you want to apply. </param>
        /// <param name="spriteBatch"> You have to pass a spritebatch in order to put it on the screen. </param>
        /// <param name="position"> The Position of the center of the circle. </param>
        /// <param name="pRadius"> The Radius of the circle. </param>
        /// <param name="color"> The color of the circle. </param>
        /// <param name="ratio"> The ratio of the circle. </param>
        public static void DrawCircle(PrimitiveStyle style, SpriteBatch spriteBatch, Vector2 position, float pRadius, Color color, float ratio = 0.01f)
        {
            if (pixel == null) CreatePixel(spriteBatch);

            float xOffset = position.X;
            float yOffset = position.Y;
            float Rayon = pRadius;

            for(float angle = 0; angle < 2*Math.PI ; angle += ratio)
            {
                float posX = xOffset + (float)Math.Cos(angle) * Rayon;
                float posY = yOffset + (float)Math.Sin(angle) * Rayon;

                DrawRectangle(PrimitiveStyle.FILL, spriteBatch, posX, posY, 1, 1, color);

                if (style == PrimitiveStyle.FILL) DrawLine(spriteBatch, new Vector2(posX, posY), position, color,(int)Rayon);
            }

        }

    }
}
