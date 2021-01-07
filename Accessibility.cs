using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{
    static class Accessibility
    {

        private static int _gamepadVibrationIntensity = 100;
        private static int _cameraShakeIntensity = 100;
        private static int _cameraFlashIntensity = 100;

        /// <summary>
        /// Express the maximum intensity the gamepad can vibrate. (Value is a % between 0 and 100).
        /// </summary>
        public static int GAMEPAD_VIBRATION_INTENSITY
        {
            get => _gamepadVibrationIntensity;
            set => _gamepadVibrationIntensity = MathHelper.Clamp(value, 0, 100);
        }

        /// <summary>
        /// Express the maximum intensity the camera can shake. (Value is a % between 0 and 100).
        /// </summary>
        public static int CAMERA_SHAKE_INTENSITY
        {
            get => _cameraShakeIntensity;
            set => _cameraShakeIntensity = MathHelper.Clamp(value, 0, 100);
        }

        /// <summary>
        /// Express the maximum intensity the camera can flash. (Value is a % between 0 and 100).
        /// </summary>
        public static int CAMERA_FLASH_INTENSITY
        {
            get => _cameraFlashIntensity;
            set => _cameraFlashIntensity = MathHelper.Clamp(value, 0, 100);
        }
    }
}
