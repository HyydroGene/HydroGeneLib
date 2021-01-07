using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{

    class Dialogue : Text
    {

        private string[] FullText { get; set; }
        private int CurrentTextPosition { get; set; }

        private string EndTextSymbol = "->";
        private Text EndText;

        /// <summary>
        /// Force the dialogue to enter in his final state. ToRemove is pass to true.
        /// </summary>
        public bool ForceTextToFinish { get; set; } = false;

        private const float InterruptSpeedApparition = 0.001f;
        private float BaseSpeedApparition;

        /// <summary>
        /// List of keyboard input that authorized the player to switch text. By default you can press Enter, Space or X keys.
        /// </summary>
        public List<Keys> KeyToSwitch = new List<Keys>();

        /// <summary>
        /// List of button of gamepad that authorized the player to switch text. By default you can press A,B or X.
        /// </summary>
        public List<Buttons> ButtonToSwitch = new List<Buttons>();

        /// <summary>
        /// Add your own function if you want to do something when the full text is appeared.
        /// </summary>
        public OnComplete OnComplete = delegate () { };

        /// <summary>
        /// Is true when the current string is completely appeared.
        /// </summary>
        public bool IsCurrentStringAppear { get; set; }

        /// <summary>
        /// Create a new Dialogue. It's like the Text class, but with multiple strings.
        /// </summary>
        /// <param name="pFont"> The Font of the dialogue </param>
        /// <param name="pString"> The array of string that the dialogue is composed. </param>
        /// <param name="pos"> The position of your dialogue. You can use Align attribute, to center it automatically. </param>
        /// <param name="pColor"> The color of your dialogue </param>
        /// <param name="tMode"> The mode of your dialogue. By default the letter appears one at a time.</param>
        /// <param name="pWidth"> The width field of your dialogue Put some \n automatically. Let this to 0 if you don't need it. </param>
        /// <param name="pAlpha"> The alpha of your dialogue. By default it is fully visibile, so it's alpha is 1.0f</param>
        public Dialogue(SpriteFont pFont, string[] pString, Vector2 pos, Color pColor, Text.TextMode tMode = TextMode.LETTER_APPARITION, int pWidth = 0, float pAlpha = 1.0f) : base(pFont, pString[0], pos, pColor, tMode, pWidth, pAlpha)
        {
            FullText = pString;
            CurrentTextPosition = 0;

            KeyToSwitch.Add(Keys.Enter); KeyToSwitch.Add(Keys.X); KeyToSwitch.Add(Keys.Space);
            ButtonToSwitch.Add(Buttons.A); ButtonToSwitch.Add(Buttons.B); ButtonToSwitch.Add(Buttons.X);

            EndText = new Text(Font, EndTextSymbol, new Vector2(pos.X + this.Width, pos.Y + this.Height + 10), this.Color);
            EndText.CanBlink = true;
            EndText.timerVisible = 0.25f;
            EndText.BlinkFrequency = 0.25f;
            EndText.IsActive = false;

            BaseSpeedApparition = SpeedApparition;

        }


        public void Reset()
        {
            CurrentTextPosition = 0;
            EndText.IsActive = false;

            CurrentString = "";
            MidString = "";
            currentString_position = 0;

            this.FullString = FullText[0];
            IsFullStringAppear = false;

            IsCurrentStringAppear = false;

            BaseSpeedApparition = SpeedApparition;
        }

        public void Reset(string[] NewText)
        {
            CurrentTextPosition = 0;
            EndText.IsActive = false;

            CurrentString = "";
            MidString = "";
            currentString_position = 0;

            IsCurrentStringAppear = false;

            this.FullText = NewText;
            this.FullString = FullText[0];
            IsFullStringAppear = false;

            BaseSpeedApparition = SpeedApparition;
        }

        public override void Update(GameTime gameTime)
        {
            this.Width = Font.MeasureString(CurrentString).X * Scale.X;
            this.Height = Font.MeasureString(CurrentString).Y * Scale.Y;

            if (SpeedApparition != InterruptSpeedApparition) BaseSpeedApparition = SpeedApparition;

            EndText.Position = new Vector2(Position.X + this.Width, Position.Y + this.Height + 10);

            switch (Align)
            {
                case Util.Alignement.CENTER_X:
                    this.Position = new Vector2(Camera.Position.X + (Camera.VisibleArea.Width / 2 - this.Width / 2), this.Position.Y);
                    break;

                case Util.Alignement.CENTER_Y:
                    this.Position = new Vector2(this.Position.X, Camera.Position.Y + (Camera.VisibleArea.Height / 2 - this.Height / 2));
                    break;

                case Util.Alignement.CENTER_X | Util.Alignement.CENTER_Y:
                    this.Position = new Vector2(Camera.Position.X + (Camera.VisibleArea.Width / 2 - this.Width / 2), this.Position.Y);
                    this.Position = new Vector2(this.Position.X, Camera.Position.Y + (Camera.VisibleArea.Height / 2 - this.Height / 2));
                    break;
            }

            if (IsActive)
            {
                #region Letter Apparition
                if (Mode == TextMode.LETTER_APPARITION)
                {
                    currentTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds; //0.01f;

                    if (currentString_position < FullText[CurrentTextPosition].Length)
                    {
                        EndText.IsActive = false;
                        currentTimer -= 0.01f;

                        if (currentTimer < 0)
                        {
                            if (FieldWidth != 0 && Font.MeasureString(MidString).X >= FieldWidth)
                            {

                                List<Char> listChars = new List<char>();
                                int pos = currentString_position-1;
                                while(CurrentString[pos] != ' ')
                                {
                                    listChars.Add(CurrentString[pos]);
                                    pos--;
                                    CurrentString = CurrentString.Remove(CurrentString.Length-1);

                                }
                                CurrentString += "\n";

                                for (int i = listChars.Count-1; i >= 0; i--)
                                    CurrentString += listChars[i];

                                MidString = "";
                            }

                            if (canAddNextLetter)
                            {
                                CurrentString += FullString[currentString_position];
                                MidString += FullString[currentString_position];
                            }

                            else canAddNextLetter = true;

                            //Console.WriteLine(currentString_position);

                            if (FullString[currentString_position] != ' ' && Sound != null) Sound.Play(MainGame.VOLUME_SFX, TextSoundPitch, 0);


                            currentString_position++;
                            currentTimer = SpeedApparition;
                        }

                        /* 
                            Comme le texte n'est pas entièrement arrivé, si on appuie sur la touche pour changer 
                            de texte, ça va juste faire apparaitre très rapidement le texte courrant.
                         */
                        if (SpeedApparition != InterruptSpeedApparition)
                        {
                            foreach (Keys k in KeyToSwitch)
                                if (KBInput.JustPressed(k)) SpeedApparition = InterruptSpeedApparition;

                            foreach (Buttons b in ButtonToSwitch)
                                if (GamePadInput.JustPressed(b)) SpeedApparition = InterruptSpeedApparition;
                        }

                        IsCurrentStringAppear = false;
                    }


                    else
                    {
                        EndText.IsActive = true;

                        IsCurrentStringAppear = true;

                        // Si l'intégralité des textes n'est pas encore terminé
                        #region Print All Text Super Quickly
                        if (CurrentTextPosition != FullText.Length - 1)
                        {
                            foreach (Keys k in KeyToSwitch)
                            {
                                if (KBInput.JustPressed(k))
                                {
                                    CurrentTextPosition++;

                                    MidString = "";
                                    CurrentString = "";
                                    if (CurrentTextPosition > FullText.Length-1)
                                        CurrentTextPosition = FullText.Length - 1;
                                    FullString = FullText[CurrentTextPosition];
                                    currentString_position = 0;

                                    SpeedApparition = BaseSpeedApparition;
                                }
                            }

                            foreach (Buttons b in ButtonToSwitch)
                            {
                                if (GamePadInput.JustPressed(b))
                                {
                                    CurrentTextPosition++;

                                    MidString = "";
                                    CurrentString = "";

                                    if (CurrentTextPosition > FullText.Length - 1)
                                        CurrentTextPosition = FullText.Length - 1;
                                    FullString = FullText[CurrentTextPosition];
                                    currentString_position = 0;

                                    SpeedApparition = BaseSpeedApparition;
                                }
                            }

                            #endregion

                        }
                        else
                        {
                            foreach (Keys k in KeyToSwitch)
                                if (KBInput.JustPressed(k)) IsFullStringAppear = true;

                            foreach (Buttons b in ButtonToSwitch)
                                if (GamePadInput.JustPressed(b)) IsFullStringAppear = true;

                            if (OnComplete != null) OnComplete();

                            if (IsFullStringAppear) ToRemove = true;
                        }
                    }

                }

                if (ForceTextToFinish)
                {
                    IsFullStringAppear = true;
                    IsActive = false;
                    ToRemove = true;
                }


                #endregion

                #region Blink
                if (CanBlink)
                {
                    timerVisible -= (float)gameTime.ElapsedGameTime.TotalSeconds; //0.01f;

                    if (timerVisible < 0)
                    {
                        if (this.IsVisible)
                            timerVisible = BlinkFrequency / 2f;

                        else timerVisible = BlinkFrequency;

                        this.IsVisible = !this.IsVisible;
                    }
                }

                #endregion

            }

            EndText.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            if (IsActive && IsVisible)
            {

                // Traitement du flip
                flipEffect = SpriteEffects.None;
                if (Flip.X) flipEffect = SpriteEffects.FlipHorizontally;
                if (Flip.Y) flipEffect = SpriteEffects.FlipVertically;
                if (Flip.X && Flip.Y) flipEffect = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;


                spriteBatch.DrawString(this.Font,
                                       this.CurrentString,
                                       this.Position,
                                       this.Color * this.Alpha,
                                       MathHelper.ToRadians(this.Angle + Camera.Angle),
                                       this.Origin,
                                       this.Scale,
                                       this.flipEffect,
                                       0f);

                EndText.Draw(spriteBatch);
            }
        }

    }
}
