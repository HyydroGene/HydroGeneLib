using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{
    public delegate void OnComplete();

    class Timer
    {
        public float CurrentTimer { get; private set; } = 0;
        public float TotalTimer { get; private set; } = 0;

        bool IsLaunched;

        /// <summary>
        /// Indicate the number of turn this timer have already done.
        /// </summary>
        public int Turn { get; private set; } = 0;

        /// <summary>
        /// Indicate if the timer is finished or not.
        /// </summary>
        public bool IsFinished { get; private set; } = false;

        /// <summary>
        /// Say if the timer is looped or not.
        /// </summary>
        public bool IsLooped { get; set; }

        /// <summary>
        /// Do something (Call your own function) when the timer is finished.
        /// </summary>
        public OnComplete OnComplete;

        /// <summary>
        /// Create a new timer.
        /// </summary>
        /// <param name="initialValue"> The value of the Timer. </param>
        /// <param name="loop"> Indicate if the timer have to be loop or not.</param>
        /// <param name="launched"> Indicate if you want to launch the timer now or not. If you put this to false, you need to put it to true somewhere later. </param>
        public Timer(float initialValue, bool loop = true, bool launched = true)
        {
            TotalTimer = initialValue;
            CurrentTimer = TotalTimer;
            IsLaunched = launched;
            IsLooped = loop;
        }


        public void Reset(bool removeDelegateOnComplete = true)
        {
            CurrentTimer = TotalTimer;
            IsFinished = false;
            Turn = 0;

            if (removeDelegateOnComplete)
                OnComplete = null;
        }

        /// <summary>
        /// Force the current value of the timer at the new value given.
        /// </summary>
        /// <param name="newValue"> The new value you want the current value to take </param>
        public void ChangeCurrentTimerOnly(float newValue)
        {
            CurrentTimer = newValue;
        }

        /// <summary>
        /// Change the current value of the timer.
        /// </summary>
        /// <param name="newValue"> Indicate the new value for the timer. </param>
        public void ChangeTimerValue(float newValue)
        {
            TotalTimer = newValue;
            CurrentTimer = newValue;
        }

        /// <summary>
        /// Put this on your Update() function to apply the timer.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            if (IsLaunched && !IsFinished)
            {
                if (!MainGame.IS_PAUSED)
                    CurrentTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds; //0.01f;

                if (CurrentTimer < 0)
                {
                    IsFinished = true;

                    if (IsLooped)
                    {
                        Turn++;
                        if (OnComplete != null) OnComplete();

                        CurrentTimer = TotalTimer;
                        IsFinished = false;
                    }
                }

            }
        }
    }
}
