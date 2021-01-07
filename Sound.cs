using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{
    class Sound
    {
        public SoundEffect SoundEffect { get; private set; }

        /// <summary>
        /// The Instance of the SoundEffect
        /// </summary>
        public SoundEffectInstance Instance { get; set; }

        /// <summary>
        /// Create a new Sound/Sfx.
        /// </summary>
        /// <param name="pSF"> The SoundEffect </param>
        /// <param name="pVolume"> The Volume of this Sound. By default it's set to the maximum. </param>
        /// <param name="pPan"> The Pan of this Sound. By default it's set to the normal pan. </param>
        public Sound(SoundEffect pSF, float pVolume = 1.0f, float pPan = 0f)
        {
            this.SoundEffect = pSF;
            this.Instance = this.SoundEffect.CreateInstance();

            this.Instance.Volume = pVolume;
            this.Instance.Pan = pPan;
        }

        /// <summary>
        /// Give the good panning based on a main sprite.
        /// </summary>
        /// <param name="spriteToFollow">The Sprite where the panning have to be apply</param>
        /// <param name="offsetVisibleArea">Offset to the max limit</param>
        /// <returns> Return the appropriate panning</returns>
        public float GetPanning(Sprite spriteToFollow, float offsetVisibleArea = 1.5f)
        {
            float max = Camera.VisibleArea.Width * offsetVisibleArea;
            float px = spriteToFollow.Position.X - spriteToFollow.Origin.X - Camera.Position.X;

            float panning = ((px * 2f) / max) - 1f;

            if (panning < -1f) panning = -1f;
            if (panning > 1f) panning = 1f;

            return panning;
        }
    }
}
