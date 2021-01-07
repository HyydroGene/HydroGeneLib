using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HydroGene
{

    public static class KBInput
    {

        public static KeyboardState oldKBState;
        public static KeyboardState newKBState;

        public static Keys? GetLastKeyJustPressed()
        {
           if(JustPressed(newKBState.GetPressedKeys()[0]))
           {
                return newKBState.GetPressedKeys()[0];
           }

            return null;
        }

        public static Keys[] GetAllKeyPressed()
        {
            return newKBState.GetPressedKeys();
        }

        /// <summary>
        /// Check if a key has just been pressed once.
        /// </summary>
        /// <param name="key"> Indicate which key you want to check </param>
        /// <returns></returns>
        public static bool JustPressed(Keys key)
        {
            return (newKBState.IsKeyDown(key) && !oldKBState.IsKeyDown(key));  
        }

        /// <summary>
        /// Check if a key has just been released.
        /// </summary>
        /// <param name="key"> Indicate which key you want to check </param>
        /// <returns></returns>
        public static bool JustReleased(Keys key)
        {
            return (newKBState.IsKeyUp(key) && !oldKBState.IsKeyUp(key));
        }

        /// <summary>
        /// Check if a key is pressed.
        /// </summary>
        /// <param name="key"> Indicate which key you want to check </param>
        /// <returns></returns>
        public static bool Pressed(Keys key)
        {
            return (newKBState.IsKeyDown(key));
        }

        /// <summary>
        /// Check if a key is released.
        /// </summary>
        /// <param name="key"> Indicate which key you want to check </param>
        /// <returns></returns>
        public static bool Released(Keys key)
        {
            return (newKBState.IsKeyUp(key));
        }
    }
}
