using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{
   
    static class GamePadInput
    {
        private const short MIN_THUMBSTICK_VALUE = -1;
        private const short MAX_THUMBSTICK_VALUE = 1;
        
        public static GamePadCapabilities capabilities;
        public static GamePadState newGPState;
        public static GamePadState oldGPState;

        public static Vector2 oldLeftThumbStick = Vector2.Zero;
        public static Vector2 oldRightThumbStick = Vector2.Zero;

        public static Timer TimerVibration = new Timer(0);

        public static Vector2 LeftThumbstickValue()
        {
            return newGPState.ThumbSticks.Left;
        }

        public static Vector2 RightThumbstickValue()
        {
            return newGPState.ThumbSticks.Right;
        }

        public static bool JustMoveLeftThumbstick(Util.Direction axe, float value)
        {
            value = MathHelper.Clamp(value, MIN_THUMBSTICK_VALUE, MAX_THUMBSTICK_VALUE);

            switch(axe)
            {
                case Util.Direction.Top:
                    return (Pressed(Buttons.LeftThumbstickUp) && (LeftThumbstickValue().Y >= Math.Abs(value) && oldLeftThumbStick.Y < Math.Abs(value)));

                case Util.Direction.Bottom:
                    return (Pressed(Buttons.LeftThumbstickDown) && (LeftThumbstickValue().Y <= -Math.Abs(value) && oldLeftThumbStick.Y > -Math.Abs(value)));

                case Util.Direction.Right:
                    return (Pressed(Buttons.LeftThumbstickRight) && (LeftThumbstickValue().X >= Math.Abs(value) && oldLeftThumbStick.X < Math.Abs(value)));

                case Util.Direction.Left:
                    return (Pressed(Buttons.LeftThumbstickLeft) && (LeftThumbstickValue().X <= -Math.Abs(value) && oldLeftThumbStick.X > -Math.Abs(value)));

                default:
                    Console.WriteLine("-- ERROR -- : The direction " + axe + " does not exist with the Gamepad Thumbstick.");
                    return false;
            }
        }

        /// <summary>
        /// Check if a button has just been pressed once.
        /// </summary>
        /// <param name="button"> Indicate which button you want to check </param>
        /// <returns></returns>
        public static bool JustPressed(Buttons button)
        {
            return (newGPState.IsButtonDown(button) && !oldGPState.IsButtonDown(button));
        }

        /// <summary>
        /// Check if a button has just been released once.
        /// </summary>
        /// <param name="button"> Indicate which button you want to check </param>
        /// <returns></returns>
        public static bool JustReleased(Buttons button)
        {
            return (!newGPState.IsButtonDown(button) && oldGPState.IsButtonDown(button));
        }

        /// <summary>
        /// Check if a button is pressed 
        /// </summary>
        /// <param name="button"> Indicate which button you want to check </param>
        /// <returns></returns>
        public static bool Pressed(Buttons button)
        {
            return (newGPState.IsButtonDown(button));
        }

        /// <summary>
        /// Check if a button is released
        /// </summary>
        /// <param name="button"> Indicate which button you want to check </param>
        /// <returns></returns>
        public static bool Released(Buttons button)
        {
            return (newGPState.IsButtonUp(button));
        }

        /// <summary>
        /// Create vibration on a XBox360 Controller. Don't forget to call StopVibration if you use it continually in a loop to Stop it vibrating.
        /// </summary>
        /// <param name="intensityLeft"> The intensity of the vibration of the left motor. </param>
        /// <param name="intensityRight"> The intensity of the vibration of the right motor. </param>
        /// <param name="player"> The player index of the controller. By default it's set to One. </param>
        public static void Vibrate(float intensityLeft, float intensityRight, PlayerIndex player = PlayerIndex.One)
        {
            if (capabilities.IsConnected)
            {
                intensityLeft = Util.GivePercentageFromValue(Accessibility.GAMEPAD_VIBRATION_INTENSITY, intensityLeft);
                intensityRight = Util.GivePercentageFromValue(Accessibility.GAMEPAD_VIBRATION_INTENSITY, intensityRight);
                GamePad.SetVibration(player, intensityLeft, intensityRight);
            }
        }

        /// <summary>
        /// Create vibration on a XBox360 Controller. It will stop vibrate after the time you chose.
        /// </summary>
        /// <param name="intensityLeft"> The intensity of the vibration of the left motor. </param>
        /// <param name="intensityRight"> The intensity of the vibration of the right motor. </param>
        /// <param name="player"> The player index of the controller. By default it's set to One. </param>
        public static void Vibrate(float intensityLeft, float intensityRight, float timeVibration, PlayerIndex player = PlayerIndex.One)
        {
            if (capabilities.IsConnected)
            {
                TimerVibration.ChangeTimerValue(timeVibration);
                intensityLeft = Util.GivePercentageFromValue(Accessibility.GAMEPAD_VIBRATION_INTENSITY, intensityLeft);
                intensityRight = Util.GivePercentageFromValue(Accessibility.GAMEPAD_VIBRATION_INTENSITY, intensityRight);
                GamePad.SetVibration(player, intensityLeft, intensityRight);
            }
        }

        /// <summary>
        /// Stop the vibration of a Xbox360 Controller.
        /// </summary>
        /// <param name="player"> The player you want the vibration to stop. By default it's Player One who will be stopped. </param>
        public static void StopVibration(PlayerIndex player = PlayerIndex.One)
        {
            if (capabilities.IsConnected)
                GamePad.SetVibration(player, 0, 0);
        }
    }
}
