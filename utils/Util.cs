using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{
    class Util
    {

        // Useful Enum
        /// <summary>
        /// Indicate an alignement for an IActor
        /// </summary>
        public enum Alignement : byte
        {
            NONE,
            CENTER_X,
            CENTER_Y
        }

        /// <summary>
        /// Indicate a direction.
        /// </summary>
        public enum Direction : Byte
        {
            None,
            Left,
            Right,
            Top,
            Bottom
        }

        #region -------------------  Random -------------------

        static Random RandomGenerator = new Random();

        /// <summary>
        /// Set a seed for the random generator.
        /// </summary>
        /// <param name="Seed"></param>
        public static void SetRandomSeed(int Seed)
        {
            RandomGenerator = new Random(Seed);
        }

        /// <summary>
        /// Generate a random number integer between the min and max value (included). If min > max, it will automatically swap them to avoid error.
        /// </summary>
        /// <param name="min"> The Minimum value </param>
        /// <param name="max"> The maximum value. (The random can take this value, so don't need to add +1)</param>
        /// <param name="excludeNumbers"> Array of value you don't want the random to take.</param>
        /// <returns></returns>
        public static int RandomInt(int min, int max, int[] excludeNumbers = null )
        {
            if (min > max)
            {
                int temp = min;
                min = max;
                max = temp;
            }

            int result = RandomGenerator.Next(min, max + 1);

            if (excludeNumbers != null)
            {
                for (int i = 0; i < excludeNumbers.Length; i++)
                {
                    do
                    {
                        result = RandomGenerator.Next(min, max + 1);
                    } while (result == excludeNumbers[i]);
                }
            }

            return result;
        }

        /// <summary>
        /// Generate a random number float between the min and max value (included). If min > max, it will automatically swap them to avoid error.
        /// </summary>
        /// <param name="min"> The Minimum value </param>
        /// <param name="max"> The maximum value. (The random can take this value, so don't need to add +1)</param>
        /// <param name="excludeNumbers"> Array of value you don't want the random to take. </param>c
        /// <returns></returns>
        public static float RandomFloat(float min, float max, float[] excludeNumbers = null)
        {
            min *= 100;
            max *= 100;

            if (min > max)
            {
                float temp = min;
                min = max;
                max = temp;
            }

            float result = (float)RandomGenerator.Next((int)min, (int)max) / 100;

            if (excludeNumbers != null)
            {
                for (int i = 0; i < excludeNumbers.Length; i++)
                {
                    do
                    {
                        result = (float)RandomGenerator.Next((int)min, (int)max) / 100;
                    } while (result == excludeNumbers[i]);
                }
            }

            return result;
        }

        /// <summary>
        /// Generate a random number double between the min and max value (included). If min > max, it will automatically swap them to avoid error.
        /// </summary>
        /// <param name="min"> The Minimum value </param>
        /// <param name="max"> The maximum value. (The random can take this value, so don't need to add +1)</param>
        /// <param name="excludeNumbers"> Array of value you don't want the random to take. </param>c
        /// <returns></returns>
        public static double RandomDouble(double min, double max, double[] excludeNumbers = null)
        {
            min *= 100;
            max *= 100;

            if (min > max)
            {
                double temp = min;
                min = max;
                max = temp;
            }

            double result = RandomGenerator.Next((int)min, (int)max) / 100;

            if (excludeNumbers != null)
            {
                for (int i = 0; i < excludeNumbers.Length; i++)
                {
                    do
                    {
                        result = RandomGenerator.Next((int)min, (int)max) / 100;
                    } while (result == excludeNumbers[i]);
                }
            }

            return result;
        }

        /// <summary>
        /// Generate a random integer which will take one of the two values given.
        /// </summary>
        /// <param name="number1"> The first number </param>
        /// <param name="number2"> The second number </param>
        /// <returns></returns>
        public static int RandomIntBetween2Numbers(int number1, int number2)
        {
            int choose = Util.RandomInt(1, 2);

            if (choose == 1)
                return number1;

            return number2;

        }

        #endregion

        #region ------------------- Checking colllisions -------------------

        #region Directional Collision (Left / Right / Top / Bottom)
        /// <summary>
        /// Check if the main entity is touching a second entity on its left
        /// </summary>
        /// <param name="mainActor"> The actor this function will look on his left</param>
        /// <param name="actorToCheck"> The actor which is supposed to be touched on his right by the main actor</param>
        /// <returns>Return true if the mainActor collide by his left on the actorToCheck</returns>
        public static bool CollideLeft(Sprite mainActor, Sprite actorToCheck, float leftOffsetPrecision = 1f)
        {
            return (mainActor.Position.X -mainActor.Origin.X - leftOffsetPrecision >= actorToCheck.Position.X -actorToCheck.Origin.X && 
                    mainActor.Position.X -mainActor.Origin.X - leftOffsetPrecision <= actorToCheck.Position.X -actorToCheck.Origin.X + (actorToCheck.Width*actorToCheck.Scale.X) && 
                    mainActor.Position.Y -mainActor.Origin.Y + (mainActor.Height/2*mainActor.Scale.Y) >= actorToCheck.Position.Y -actorToCheck.Origin.Y && 
                    mainActor.Position.Y -mainActor.Origin.Y + (mainActor.Height/2*mainActor.Scale.Y) <= actorToCheck.Position.Y -actorToCheck.Origin.Y + (actorToCheck.Height*actorToCheck.Scale.Y));
        }

        /// <summary>
        /// Check if the main entity is touching a second entity on its right
        /// </summary>
        /// <param name="mainActor"> The actor this function will look on his right</param>
        /// <param name="actorToCheck"> The actor which is supposed to be touched on its left by the main actor</param>
        /// <returns>Return true if the mainActor collide by his right on the actorToCheck</returns>
        public static bool CollideRight(Sprite mainActor, Sprite actorToCheck, float rightOffsetPrecision = 1f)
        {
            return (mainActor.Position.X -mainActor.Origin.X + (mainActor.Width*mainActor.Scale.X) + rightOffsetPrecision >= actorToCheck.Position.X -actorToCheck.Origin.X && 
                    mainActor.Position.X -mainActor.Origin.X + (mainActor.Width*mainActor.Scale.X) + rightOffsetPrecision <= actorToCheck.Position.X -actorToCheck.Origin.X + (actorToCheck.Width*actorToCheck.Scale.X) && 
                    mainActor.Position.Y -mainActor.Origin.Y + (mainActor.Height/2*mainActor.Scale.Y) >= actorToCheck.Position.Y -actorToCheck.Origin.Y && 
                    mainActor.Position.Y -mainActor.Origin.Y + (mainActor.Height/2*mainActor.Scale.Y) <= actorToCheck.Position.Y -actorToCheck.Origin.Y + (actorToCheck.Height*actorToCheck.Scale.Y));

        }

        /// <summary>
        /// Check if the main entity is touching a second entity above it
        /// </summary>
        /// <param name="mainActor"> The actor this function will look above it</param>
        /// <param name="actorToCheck"> The actor which is supposed to be touched on its bottom by the main actor</param>
        /// <returns>Return true if the mainActor collide by its top on the actorToCheck</returns>
        public static bool CollideAbove(Sprite mainActor, Sprite actorToCheck, float upOffsetPrecision = 1f)
        {
            return (mainActor.Position.X -mainActor.Origin.X + (mainActor.Width/2*mainActor.Scale.X) >= actorToCheck.Position.X -actorToCheck.Origin.X && 
                    mainActor.Position.X -mainActor.Origin.X + (mainActor.Width/2*mainActor.Scale.X) <= actorToCheck.Position.X -actorToCheck.Origin.X + (actorToCheck.Width*actorToCheck.Scale.X) && 
                    mainActor.Position.Y -mainActor.Origin.Y - upOffsetPrecision >= actorToCheck.Position.Y -actorToCheck.Origin.Y && 
                    mainActor.Position.Y -mainActor.Origin.Y - upOffsetPrecision <= actorToCheck.Position.Y -actorToCheck.Origin.Y + (actorToCheck.Height*actorToCheck.Scale.Y));
        }

        /// <summary>
        /// Check if the main entity is touching a second entity above it
        /// </summary>
        /// <param name="mainActor"> The actor this function will look below it</param>
        /// <param name="actorToCheck"> The actor which is supposed to be touched on its top by the main actor</param>
        /// <returns> Return true if the mainActor collide by its bottom on the actorToCheck</returns>
        public static bool CollideBelow(Sprite mainActor, Sprite actorToCheck, float downOffsetPrecision = 1f)
        {
            return (mainActor.Position.X -mainActor.Origin.X + (mainActor.Width/2*mainActor.Scale.X) >= actorToCheck.Position.X -actorToCheck.Origin.X && 
                    mainActor.Position.X -mainActor.Origin.X + (mainActor.Width/2*mainActor.Scale.X) <= actorToCheck.Position.X -actorToCheck.Origin.X + (actorToCheck.Width*actorToCheck.Scale.X) && 
                    mainActor.Position.Y -mainActor.Origin.Y + (mainActor.Height*mainActor.Scale.Y) + downOffsetPrecision >= actorToCheck.Position.Y -actorToCheck.Origin.Y && 
                    mainActor.Position.Y -mainActor.Origin.Y + (mainActor.Height*mainActor.Scale.Y) + downOffsetPrecision <= actorToCheck.Position.Y -actorToCheck.Origin.Y + (actorToCheck.Height*actorToCheck.Scale.Y));
        }

        #endregion

        /// <summary>
        /// Check if 2 IActor overlaps between them
        /// </summary>
        /// <param name="actor1"> The First IActor to check </param>
        /// <param name="actor2"> The Second IActor to check</param>
        /// <returns></returns>
        public static bool Overlaps(IActor actor1, IActor actor2)
        {
            return actor1.BoundingBox.Intersects(actor2.BoundingBox);
        }

        /// <summary>
        /// Check if 1 IActor and 1 Rectangle overlaps between them
        /// </summary>
        /// <param name="actor1"> The First IActor to check </param>
        /// <param name="box"> The Rectangle to check</param>
        /// <returns></returns>
        public static bool Overlaps(IActor actor1, Rectangle box)
        {
            return actor1.BoundingBox.Intersects(box);
        }

        /// <summary>
        /// Check if 2 Rectangle overlaps between them
        /// </summary>
        /// <param name="r1"> The First Rectangle to check </param>
        /// <param name="r2"> The Second Rectangle to check</param>
        /// <returns></returns>
        public static bool Overlaps(Rectangle r1, Rectangle r2)
        {
            return r1.Intersects(r2);
        }

        /// <summary>
        /// Check the distance between two IActor.
        /// </summary>
        /// <param name="actor1"> The First IActor </param>
        /// <param name="actor2"> The Second IActor</param>
        /// <returns></returns>
        public static double DistanceBetween(IActor actor1, IActor actor2)
        {
            return (Math.Pow(Math.Pow((actor2.Position.X - actor1.Position.X), 2) + Math.Pow((actor2.Position.Y - actor1.Position.Y), 2), 0.5));
        }

        /// <summary>
        /// Check the distance between two Vector2
        /// </summary>
        /// <param name="object1"> The First Vector2  </param>
        /// <param name="object2"> The Second Vector2 </param>
        /// <returns></returns>
        public static double DistanceBetween(Vector2 object1, Vector2 object2)
        {
            double valueX = Math.Pow((object2.X - object1.X), 2);
            double valueY = Math.Pow((object2.Y - object1.Y), 2);

            double totalValue = Math.Pow(valueX + valueY, 0.5);

            return totalValue;
        }

        #endregion

        #region ------------ Others ----------------

        /// <summary>
        /// Obtain the percentage based on a value and the percentage you want to obtain from that value.
        /// </summary>
        /// <param name="percentYouWant">How many percentage you want to have</param>
        /// <param name="baseValue">From which initial value you will take the percentage</param>
        /// <returns></returns>
        public static float GivePercentageFromValue(float percentYouWant, float baseValue)
        {
            return ((baseValue * percentYouWant) / 100);
        }

        public static float GetAngleBetween(Sprite sprite1, Sprite sprite2)
        {



            return MathHelper.ToDegrees((float)Math.Atan2((sprite2.Position.Y - sprite2.Origin.Y) - (sprite1.Position.Y - sprite1.Origin.Y), (sprite2.Position.X - sprite2.Origin.X) - (sprite1.Position.X -sprite1.Origin.X)));
        }
        #endregion

    }

}
