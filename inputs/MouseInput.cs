using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HydroGene
{
    class MouseInput
    {
        public static MouseState newMouseState, oldMouseState;

        #region Left Button
        /// <summary>
        /// Check if the Left Click has just been pressed once
        /// </summary>
        /// <returns></returns>
        public static bool JustLeftClicked()
        {
            return (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton != ButtonState.Pressed);
        }

        /// <summary>
        /// Check if the Left Click has just been released once
        /// </summary>
        /// <returns></returns>
        public static bool JustLeftReleased()
        {
            return (newMouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton != ButtonState.Released);
        }

        /// <summary>
        /// Check if the Left Click is pressed.
        /// </summary>
        /// <returns></returns>
        public static bool LeftClicked()
        {
            return (newMouseState.LeftButton == ButtonState.Pressed);
        }

        #endregion

        #region Right Button

        /// <summary>
        /// Check if the Right Click has just been pressed once.
        /// </summary>
        /// <returns></returns>
        public static bool JustRightClicked()
        {
            return (newMouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton != ButtonState.Pressed);
        }


        /// <summary>
        /// Check if the Right Click has just been released once.
        /// </summary>
        /// <returns></returns>
        public static bool JustRightReleased()
        {
            return (newMouseState.RightButton == ButtonState.Released && oldMouseState.RightButton != ButtonState.Released);
        }

        /// <summary>
        /// Check if the Right Click is pressed.
        /// </summary>
        /// <returns></returns>
        public static bool RightClicked()
        {
            return (newMouseState.RightButton == ButtonState.Pressed);
        }

        #endregion


        /// <summary>
        /// Get the position of the mouse.
        /// </summary>
        /// <returns> Return the position of the mouse in a Vector2 </returns>
        public static Vector2 GetPosition()
        {
            return Mouse.GetState().Position.ToVector2();
        }
    }
}
