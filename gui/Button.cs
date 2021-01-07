using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{
    public delegate void OnClick(Button Sender);

    public class Button : Sprite
    {

        public bool isHover { get; private set; }
        private MouseState oldMouseState;

        public OnClick onClick { get; set; }

        public Button(Texture2D Texture) : base(Texture)
        {

        }

        public override void Update(GameTime gameTime)
        {
            MouseState newMouseState = Mouse.GetState();
            Point MousePos = newMouseState.Position;

            if(BoundingBox.Contains(MousePos))
            {
                if(!isHover)
                {
                    isHover = true;
                    Debug.WriteLine("On vient d'arriver sur le bouton");
                }

            }

            else
            {

                if(isHover)
                {
                    Debug.WriteLine("On vient de quitter le bouton");
                }

                isHover = false;
            }



            if (isHover)
            {
                if(newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {
                    Debug.WriteLine("On clic sur le bouton !");

                    if (onClick != null) onClick(this);
                }
            }


            oldMouseState = newMouseState;

            base.Update(gameTime);
        }
    }
}
