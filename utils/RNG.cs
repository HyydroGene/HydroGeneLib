using System;

namespace HydroGene
{
    public static class RNG
    {
        private static Random rng;

        public static void Init(int pSeed = 0)
        {
            if (pSeed == 0)
            {
                rng = new Random();
            }
            else
            {
                rng = new Random(pSeed);
            }
        }

        public static void SetSeed(int pSeed)
        {
            
            rng = new Random(pSeed);
        }

        public static int GetInt(int min, int max)
        {
            return rng.Next(min, max + 1);
        }

        public static float GetFloat(float range)
        {
            return (float)rng.NextDouble() * range;
        }

        public static float GetFloat(float min, float max)
        {
            return ((float)rng.NextDouble() * (max - min)) + min;
        }
    }
}
