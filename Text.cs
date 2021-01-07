using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework.Audio;

namespace HydroGene
{
    class Text : IActor
    {
        public enum TextMode : byte
        {
            NORMAL,
            LETTER_APPARITION
        }

        // ITextActor : 
        public Vector2 Position { get; set; }

        public bool ToRemove { get; set; }

        public SpriteFont Font { get; private set; }
        public float Width { get; protected set; }
        public float Height { get; protected set; }
        public Util.Alignement Align { get;  set; }

        public SoundEffect Sound { get; set; }
        public float TextSoundPitch { get; set; } = 0;

        public string FullString { get; set; }
        public string CurrentString { get; set; }
        protected string MidString = "";
        public int FieldWidth { get; set; }
        public Color Color { get; set; }
        public float Alpha { get; set; }

        /// <summary>
        /// Indicate if you want the actor to be Visible. If this variable is put to false, it will stop drawing it. The Draw() function of this sprite will not be called anymore.
        /// </summary>
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// Indicate if you want the actor to be Active. If this variable is put to false, it will stop Update and Drawing it.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Apply a bold effect to the text : 
        /// </summary>
        public bool EffectBold { get; set; } = false;

        /// <summary>
        /// Apply an effect of Fake3D. Use ColorFake3D to define a custom color.
        /// </summary>
        public bool EffectFake3D { get; set; } = false;

        /// <summary>
        /// Define a custom Color for the Fake3D. By default it's Color.White
        /// </summary>
        public Color ColorFake3D { get; set; } = Color.White;

        public Rectangle BoundingBox { get; set; }

        // Variable of this class : 
        public Vector2 Origin, Scale;
        public float Angle = 0;
        public Flip Flip;
        protected SpriteEffects flipEffect;

        public TextMode Mode { get; private set; }

        // Variable for letter apparition mode : 
        public float SpeedApparition = 0.1f;
        protected float currentTimer;
        protected int currentString_position = 0;

        // Variable for blink : 
        public float timerVisible = 0.5f;

        /// <summary>
        /// The frequency the text will blink. By default it's 0.5f.
        /// </summary>
        public float BlinkFrequency = 0.5f;
        public bool CanBlink = false;

        public bool IsFullStringAppear = false;

        // Others : 
        protected bool canAddNextLetter = true;

        public Text(SpriteFont pFont, string pString, Vector2 pos, Color pColor,TextMode tMode = TextMode.NORMAL, int pWidth = 0, float pAlpha = 1.0f)
        {
            this.CurrentString = "";
            this.FullString = pString;
            this.Position = pos;
            this.Color = pColor;
            this.Font = pFont;
            this.Alpha = pAlpha;

            this.Mode = tMode;

            this.FieldWidth = pWidth;

            if (Mode == TextMode.NORMAL)
            {
                this.CurrentString = this.FullString;
                this.IsFullStringAppear = true;
            }

            currentTimer = SpeedApparition;

            Flip.X = false; Flip.Y = false;

            Scale = Vector2.One;
            Origin = Vector2.Zero;

            this.Width = Font.MeasureString(FullString).X * Scale.X;
            this.Height = Font.MeasureString(FullString).Y * Scale.Y;

            Align = Util.Alignement.NONE;
        }

        /// <summary>
        ///  Function to write if you want to do something when this Actor collide with an other actor
        /// </summary>
        /// <param name="By"> Represent the IActor who touch this sprite </param>
        public virtual void TouchedBy(IActor By)
        {

        }

        /// <summary>
        /// Check if the current sprite is visible on the screen.
        /// </summary>
        /// <returns></returns>
        public bool IsOnScreen()
        {
            if (Util.Overlaps(this, Camera.VisibleArea)) return true;
            return false;
        }

        public void Reset(string newString, TextMode? newMode = null)
        {
            FullString = newString;

            if (newMode == null)
                CurrentString = (Mode == TextMode.LETTER_APPARITION) ? "" : FullString;

            else
                CurrentString = (newMode == TextMode.LETTER_APPARITION) ? "" : FullString;

            currentString_position = 0;
            MidString = "";
            IsFullStringAppear = false;
        }

        public virtual void Update(GameTime gameTime)
        {
            this.Width = Font.MeasureString(FullString).X * Scale.X; 
            this.Height = Font.MeasureString(FullString).Y * Scale.Y;

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

                    if (currentString_position < FullString.Length) // On vérifie juste si on ne va pas déborder sur la taille total du texte !
                    {
                        currentTimer -= 0.01f; // On décrémente le timer 


                        if (currentTimer < 0) // Si le timer < 0, tout se produit, on ajoute une nouvelle lettre : 
                        {
                            /*
                                Si jamais l'utilisateur à demander à avoir une longueur maximale avant un retour à la ligne
                                et que le texte courant dépasse
                                la longueur qu'il a spécifié, on glisse un petit "\n" dans le texte courant pour créer un retour à la ligne forcé
                            */

                            if (FieldWidth != 0 && Font.MeasureString(MidString).X >= FieldWidth)
                            {

                                List<Char> listChars = new List<char>();
                                int pos = currentString_position - 1;
                                while (CurrentString[pos] != ' ')
                                {
                                    listChars.Add(CurrentString[pos]);
                                    pos--;
                                    CurrentString = CurrentString.Remove(CurrentString.Length - 1);

                                }
                                CurrentString += "\n";

                                for (int i = listChars.Count - 1; i >= 0; i--)
                                    CurrentString += listChars[i];

                                MidString = "";
                            }

                            //On ajoute la nouvelle lettre du text complet dans le texte courant
                            if (canAddNextLetter)
                            {
                                CurrentString += FullString[currentString_position];
                                MidString += FullString[currentString_position];
                            }

                            // On peut aussi jouer un son lors de l'apparition d'une nouvelle lettre à ce moment si on le souhaite. 
                            // (pour donner une voix au personnage)
                            // On ne le fais pas si la lettre qui est lu est un espace.
                            if (FullString[currentString_position] != ' ' && Sound != null) Sound.Play(MainGame.VOLUME_SFX, TextSoundPitch, 0);

                            // A la fin, on oublie pas d'augmanter la position de notre curseur pour lire la lettre suivante
                            currentString_position++;

                            // Et on reset le timer pour pouvoir "patienter" un minimum entre l'apparition d'une nouvelle lettre.
                            currentTimer = SpeedApparition;
                        }
                    }

                    else
                    {

                        IsFullStringAppear = true;
                    }
                }

                else
                {
                    this.FullString = this.CurrentString;
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

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive && IsVisible)
            {

                // Traitement du flip
                flipEffect = SpriteEffects.None;
                if (Flip.X) flipEffect = SpriteEffects.FlipHorizontally;
                if (Flip.Y) flipEffect = SpriteEffects.FlipVertically;
                if (Flip.X && Flip.Y) flipEffect = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;

                if (EffectFake3D)
                {
                    spriteBatch.DrawString(this.Font,
                                           this.CurrentString,
                                           new Vector2(Position.X - Scale.X-1, Position.Y - Scale.Y-1),
                                           ColorFake3D * this.Alpha,
                                           MathHelper.ToRadians(this.Angle),
                                           this.Origin,
                                           this.Scale,
                                           this.flipEffect,
                                           0f);
                }

                spriteBatch.DrawString(this.Font,
                                       this.CurrentString,
                                       this.Position,
                                       this.Color * this.Alpha,
                                       MathHelper.ToRadians(this.Angle),
                                       this.Origin,
                                       this.Scale,
                                       this.flipEffect,
                                       0f);

                if (EffectBold)
                {
                    spriteBatch.DrawString(this.Font,
                                           this.CurrentString,
                                           new Vector2(Position.X + Scale.X, Position.Y),
                                           this.Color * this.Alpha,
                                           MathHelper.ToRadians(this.Angle),
                                           this.Origin,
                                           this.Scale,
                                           this.flipEffect,
                                           0f);
                }

               
            }

            
        }
    }
}
