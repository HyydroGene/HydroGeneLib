using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{

    /// <summary>
    /// All the Easing the tween can take.
    /// </summary>
    public enum Ease : byte
    {
        LINEAR,

        SINE_IN,
        SINE_OUT,
        SINE_IN_OUT,

        QUAD_IN,
        QUAD_OUT,
        QUAD_IN_OUT,

        QUINT_IN,
        QUINT_OUT,
        QUINT_IN_OUT,

        CIRC_IN,
        CIRC_OUT,
        CIRC_IN_OUT,

        ELASTIC_IN,
        ELASTIC_OUT,
        ELASTIC_IN_OUT
    };

    class Tween
    {
        /// <summary>
        /// The time of the tween.
        /// </summary>
        public double Time;

        /// <summary>
        /// The base value of the tween. Represent the first value he will get.
        /// </summary>
        public double Value;

        /// <summary>
        /// The distance the tween have to do.
        /// </summary>
        public float Distance;

        /// <summary>
        /// The duration of the tween.
        /// </summary>
        public double Duration;

        /// <summary>
        /// The Easing type your want for the tween. By default it will use the Linear one.
        /// </summary>
        public Ease Ease = Ease.LINEAR;

        /// <summary>
        /// The new value of the Tween. Apply this attribute to your variable to see the movement.
        /// </summary>
        public float Target;

        /// <summary>
        /// Indicate if a tween has finished or not.
        /// </summary>
        public bool IsFinished { get; private set; } = false;
        public bool ToRemove = false;
        public bool ContinueIfPaused { get; set; } = true;

        /// <summary>
        /// Amplitude of an Elastic Easing. This will have no effect on other Easing functions.
        /// </summary>
        public float Amplitude = 0.2f;

        /// <summary>
        ///  Period of an Elastic Easing. This will have no effect on other Easing functions.
        /// </summary>
        public float Period = 1.0f;

        /// <summary>
        /// Add your own method when a tween is completed.
        /// </summary>
        public OnComplete OnComplete {get; set;}

        /// <summary>
        /// The tweening will stop moving if this variable is put to true when the game is paused. 
        /// By default, every tweening go on even if the game is paused.
        /// </summary>
        public bool StopWhenPause { get; set; } = false;

        /// <summary>
        /// Create a new Tween.
        /// </summary>
        /// <param name="target"> The target of the tween. Insert here the value you want to tween. </param>
        /// <param name="distance"> The distance the tween have to do. This is not the final destination of your tween, be careful. </param>
        /// <param name="duration"> The duration the tween will last. </param>
        /// <param name="ease"> The Easing you want for the tween. By default it is set to Linear. </param>
        public Tween(float target, float distance, double duration, Ease ease = Ease.LINEAR)
        {
            this.Time = 0;
            this.Value = target;
            this.Distance = distance;
            this.Duration = duration;
            this.Ease = ease;
            this.Target = target;

            Tweening.list_tweens.Add(this);
        }

        /// <summary>
        /// Create a new Tween.
        /// </summary>
        /// <param name="target"> The target of the tween. Insert here the value you want to tween. </param>
        /// <param name="ease"> The Easing you want for the tween. By default it is set to Linear. </param>
        public Tween(float target, Ease ease = Ease.LINEAR)
        {
            this.Time = 0;
            this.Value = target;
            this.Distance = 0;
            this.Duration = 0.01f;
            this.Ease = ease;
            this.Target = target;

            Tweening.list_tweens.Add(this);
        }

        /// <summary>
        /// Change the value of the tween.
        /// </summary>
        /// <param name="distance"> The new distance. </param>
        /// <param name="duration"> The new duration.</param>
        /// <param name="ease"> The new Easing method.</param>
        public void ChangeValue(float distance, double duration, Ease ease)
        {
            this.Value = Target;
            this.Time = 0;
            this.Distance = distance;
            this.Duration = duration;
            this.Ease = ease;
        }

        /// <summary>
        /// Change the value of the tween. This method will keep the same Easing as before.
        /// </summary>
        /// <param name="distance"> The new distance.</param>
        /// <param name="duration"> The new duration.</param>
        public void ChangeValue(float distance, double duration)
        {
            this.Value = Target;
            this.Time = 0;
            this.Distance = distance;
            this.Duration = duration;
        }

        /// <summary>
        /// See what happened to the variable.
        /// </summary>
        /// <param name="tween"> The tween you want to see the evolution. </param>
        private void PrintTrace(Tween tween)
        {
            Console.Write("EASE = " + tween.Ease + " | ");
            Console.Write("TARGET = " + tween.Target + " | ");
            Console.Write("TIME = " + tween.Time + " | ");
            Console.WriteLine("VALUE = " + tween.Value);
        }

        
        public void Update(GameTime gameTime)
        {

            if (this.Time < this.Duration)
            {

                if (StopWhenPause && (MainGame.IS_PAUSED || MainGame.Instance.Screen.Effect != null))
                {

                }

                else
                {
                    this.Time += gameTime.ElapsedGameTime.TotalSeconds;
                    IsFinished = false;
                }

            }
            else
            {
                this.IsFinished = true;

                if (OnComplete != null) OnComplete();
            }

            #region All Easing
            switch (this.Ease)
            {
                case Ease.LINEAR:
                    this.Target = Easing.Linear(this.Time, this.Value, this.Distance, this.Duration);
                    break;

                case Ease.SINE_IN:
                    this.Target = Easing.SineIn(this.Time, this.Value, this.Distance, this.Duration);
                    break;

                case Ease.SINE_OUT:
                    this.Target = Easing.SineOut(this.Time, this.Value, this.Distance, this.Duration);
                    break;

                case Ease.SINE_IN_OUT:
                    this.Target = Easing.SineInOut(this.Time, this.Value, this.Distance, this.Duration);
                    break;

                case Ease.QUAD_IN:
                    this.Target = Easing.QuadIn(this.Time, this.Value, this.Distance, this.Duration);
                    break;

                case Ease.QUAD_OUT:
                    this.Target = Easing.QuadOut(this.Time, this.Value, this.Distance, this.Duration);
                    break;

                case Ease.QUAD_IN_OUT:
                    this.Target = Easing.QuadInOut(this.Time, this.Value, this.Distance, this.Duration);
                    break;

                case Ease.QUINT_IN:
                    this.Target = Easing.QuintIn(this.Time, this.Value, this.Distance, this.Duration);
                    break;

                case Ease.QUINT_OUT:
                    this.Target = Easing.QuintOut(this.Time, this.Value, this.Distance, this.Duration);
                    break;

                case Ease.QUINT_IN_OUT:
                    this.Target = Easing.QuintInOut(this.Time, this.Value, this.Distance, this.Duration);
                    break;

                case Ease.CIRC_IN:
                    this.Target = Easing.CircIn(this.Time, this.Value, this.Distance, this.Duration);
                    break;

                case Ease.CIRC_OUT:
                    this.Target = Easing.CircOut(this.Time, this.Value, this.Distance, this.Duration);
                    break;

                case Ease.CIRC_IN_OUT:
                    this.Target = Easing.CircInOut(this.Time, this.Value, this.Distance, this.Duration);
                    break;

                case Ease.ELASTIC_OUT:
                    this.Target = Easing.ElasticOut((float)this.Time, (float)this.Value, this.Distance, (float)this.Duration, Amplitude, Period);
                    break;
            }

            #endregion

            

            //PrintTrace(this);
        }
    }


    class Easing
    {
        #region Linear  
        public static float Linear(double t, double b, float c, double d)
        {
            return (float)(c * t / d + b);
        }

        #endregion

        #region Sinus

        public static float SineIn(double t, double b, float c, double d)
        {
            return (float)(-c * Math.Cos(t / d * (Math.PI / 2)) + c + b);
        }

        public static float SineOut(double t, double b, float c, double d)
        {
            return (float)(c * Math.Sin(t / d * (Math.PI / 2)) + b);
        }

        public static float SineInOut(double t, double b, float c, double d)
        {
            if ((t /= d / 2) < 1) return (float)(c / 2 * (Math.Sin(Math.PI * t / 2)) + b);

            return (float)(-c / 2 * (Math.Cos(Math.PI * --t / 2) - 2) + b);
        }

        #endregion

        #region Quadratic
        public static float QuadIn(double t, double b, float c, double d)
        {
            t /= d;

            return (float)(c * t * t + b);
        }

        public static float QuadOut(double t, double b, float c, double d)
        {
            t /= d;

            return (float)(-c * t * (t - 2) + b);
        }

        public static float QuadInOut(double t, double b, float c, double d)
        {
            t /= d / 2;
            if (t < 1) return (float)(c / 2 * t * t + b);

            t -= 1;
            return (float)(-c / 2 * (t * (t - 2) - 1) + b);
        }
        #endregion

        #region Quintic
        public static float QuintIn(double t, double b, float c, double d)
        {
            t /= d;

            return (float)(c * t * t * t * t * t + b);
        }
        public static float QuintOut(double t, double b, float c, double d)
        {
            t /= d;

            t -= 1;

            return (float)(c * (t * t * t * t * t + 1) + b);
        }

        public static float QuintInOut(double t, double b, float c, double d)
        {
            t /= d / 2;

            if (t < 1) return (float)(c / 2 * t * t * t * t * t + b);

            t -= 2;

            return (float)(c / 2 * (t * t * t * t * t + 2) + b);
        }
        #endregion

        #region Circular
        public static float CircIn(double t, double b, float c, double d)
        {
            t /= d;

            return (float)(-c * (Math.Sqrt(1 - t * t) - 1) + b);
        }

        public static float CircOut(double t, double b, float c, double d)
        {
            t /= d;
            t -= 1;

            return (float)(c * Math.Sqrt(1 - t * t) + b);
        }

        public static float CircInOut(double t, double b, float c, double d)
        {
            t /= d / 2;
            if (t < 1) return (float)(-c / 2 * (Math.Sqrt(1 - t * t) - 1) + b);

            t -= 2;
            return (float)(c / 2 * (Math.Sqrt(1 - t * t) + 1) + b);
        }


        #endregion

        #region Elastic
        public static float ElasticIn(float t, float b, float c, float d, float a, float p)
        {
            if (t == 0) return b;
            t /= d;
            if (t == 1) return b + c;
            if (p == 0) p = d * 0.3f;

            float s;
            if (a == 0 || a < Math.Abs(c))
            {
                a = c;
                s = p / 4;
            }
            else
            {
                s = (float)(p / (2 * Math.PI) * Math.Asin(c / a));
            }
            t--;
            return (float)(-(a * Math.Pow(2, 10 * t) * Math.Sin((t * d - s) * (2 * Math.PI) / p)) + b);
        }

        public static float ElasticOut(float t, float b, float c, float d, float a, float p)
        {
            if (t == 0)
                return b;
            t /= d;
            if (t == 1)
                return b + c;
            if (p == 0)
                p = d * 0.3f;
            float s;

            if (a == 0 || a < Math.Abs(c))
            {
                a = c;
                s = p / 4;
            }
            else
            {
                s = (float)(p / (2 * Math.PI) * Math.Asin(c / a));
            }
            return (float)(a * Math.Pow(2, -10 * t) * Math.Sin((t * d - s) * (2 * Math.PI) / p) + c + b);
        }
        #endregion

    }

    static class Tweening
    {
        public static List<Tween> list_tweens = new List<Tween>();

        public static void Update(GameTime gameTime)
        {
            foreach (Tween tweening in list_tweens)
            {
                Tween tween = (Tween)tweening;

                tween.Update(gameTime);
            }
            
        }


        public static void Unload()
        {
            foreach (Tween tweening in list_tweens)
            {
                Tween tween = (Tween)tweening;

                tween.ToRemove = true;
            }

            list_tweens.RemoveAll(item => item.ToRemove = true);
        }
    }
}
