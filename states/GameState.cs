using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{

    public class GameState
    {

        public enum SceneType : byte
        {
            Teaser,
            Dreamveloper,
            SplashScreen,
            AutoSave,
            TemporaryRoom,
            EarlyPrototype,
            Intro,
            Intro2,
            Cinematic1,
            Cinematic2,
            Cinematic3,
            Cinematic4,
            CinematicPostFinalBoss,
            Game,
            TimelessRoom,
            TrainingSelect,
            TrainingLevel,
            Shop,
            LevelSelect,
            Menu,
            Password,
            ModifInput,
            Ending
        }

        protected MainGame mainGame;
        public Scene currentScene { get; set; }

        public SceneType CurrentSceneType;

        public GameState(MainGame mainGame)
        {
            this.mainGame = mainGame;
        }

        public void ChangeScene(SceneType sceneType, bool callLoadMethod = true)
        {
            if (currentScene != null)
            {
                currentScene.Unload();
                currentScene = null;
            }

            switch (sceneType)
            {

                case SceneType.Teaser:
                    currentScene = new SceneTeaser(mainGame);
                    break;

                case SceneType.Menu:
                    currentScene = new SceneMenu(mainGame);
                    break;

                case SceneType.Dreamveloper:
                    currentScene = new SceneDreamveloper(mainGame);
                    break;

                case SceneType.AutoSave:
                    currentScene = new SceneSaveAuto(mainGame);
                    break;

                case SceneType.EarlyPrototype:
                    currentScene = new SceneEarlyPrototype(mainGame);
                    break;

                case SceneType.Cinematic1:
                    currentScene = new SceneCinematic1(mainGame);
                    break;

                case SceneType.Cinematic2:
                    currentScene = new SceneCinematic2(mainGame);
                    break;

                case SceneType.Cinematic3:
                    currentScene = new SceneCinematic3(mainGame);
                    break;

                case SceneType.Cinematic4:
                    currentScene = new SceneCinematic4(mainGame);
                    break;

                case SceneType.CinematicPostFinalBoss:
                    currentScene = new SceneCinematicPostFinalBoss(mainGame);
                    break;

                case SceneType.TemporaryRoom:
                    currentScene = new SceneTemporary(mainGame);
                    break;

                case SceneType.SplashScreen:
                    currentScene = new SceneSplashScreen(mainGame);
                    break;

                case SceneType.Intro:
                    currentScene = new SceneIntro(mainGame);
                    break;

                case SceneType.Intro2:
                    currentScene = new SceneIntro2(mainGame);
                    break;

                case SceneType.Game:
                    currentScene = new SceneGame(mainGame);
                    break;

                case SceneType.TimelessRoom:
                    currentScene = new SceneTimelessRoom(mainGame);
                    break;

                case SceneType.TrainingSelect:
                    currentScene = new SceneTrainingSelect(mainGame);
                    break;

                case SceneType.TrainingLevel:
                    currentScene = new SceneTrainingLevel(mainGame);
                    break;

                case SceneType.Shop:
                    currentScene = new SceneShop(mainGame);
                    break;

                case SceneType.LevelSelect:
                    currentScene = new SceneLevelSelect(mainGame);
                    break;

                case SceneType.Password:
                    currentScene = new ScenePassword(mainGame);
                    break;

                case SceneType.ModifInput:
                    currentScene = new SceneModifInput(mainGame);
                    break;

                case SceneType.Ending:
                    currentScene = new SceneEnding(mainGame);
                    break;

                default:
                    break;
            }

            CurrentSceneType = sceneType;
            if (callLoadMethod)
                currentScene.Load();
        }

        public void ChangeScene(Scene newScene, bool callLoadMethod = true)
        {
            if (currentScene != null)
            {
                currentScene.Unload();
                currentScene = null;
            }

            currentScene = newScene;

            if (callLoadMethod)
                currentScene.Load();
        }
    }
}
