using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{
    public abstract class Scene
    {
        protected MainGame mainGame;

        /// <summary>
        /// Represent every IActor on the scene. Insert all Sprites here.
        /// </summary>
        public List<IActor> listActors;

        public Scene(MainGame mainGame)
        {
            this.mainGame = mainGame;
            this.listActors = new List<IActor>();
        }

        public void Clean()
        {
            listActors.RemoveAll(item => item.ToRemove == true);
        }
        

        public virtual void Load()
        {

        }

        public virtual void Unload()
        {
            Camera.Unload();
            Tweening.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {

            foreach (IActor actor in listActors)
            {
                if (!MainGame.IS_PAUSED && !MainGame.IS_LEVELING_UP)
                {
                    if (actor.IsActive)
                    {
                        if (actor is Hero)
                        {
                            Hero h = (Hero)actor;

                            h.Update(gameTime);
                        }

                        else if (actor is MovingPlatform)
                        {

                            MovingPlatform p = (MovingPlatform)actor;
                            p.Update(gameTime);
                        }

                        else
                        {

                            if (mainGame.Screen.Effect != AssetManager.EffectNegative)
                                actor.Update(gameTime);

                            else
                            {
                                if (actor is Sprite)
                                {
                                    Sprite sprite = (Sprite)actor;

                                    if (sprite.Name == "SPECIAL")
                                    {
                                        sprite.Update(gameTime);
                                    }
                                }
                            }
                        }

                    }
                }
                
            }

            Tweening.Update(gameTime);

        }

        public virtual void Draw(GameTime gameTime)
        {
            foreach (IActor actor in listActors)
            {
                if (actor.IsActive && actor.IsVisible)
                    actor.Draw(mainGame.spriteBatch);
            }

        }
    }
}
