using System.Collections;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using ExampleGame.Boot;
//using ExampleGame.Module.ClickGame;
//using ExampleGame.Module.Sfx;
using ExampleGame.Module.QuizGame;
using ExampleGame.Module.Global;

namespace ExampleGame.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => "Gameplay";

        //private ClickGameController _clickGame;
        private QuizController _quizGame;
        private CountdownController _countdown;
        private DatabaseController _databaseController;
        private SaveDataController _saveData;
        private GameFlowController _gameFlow;
        private AnalyticController _analytic;

        public void QuitGame()
        {
            Application.Quit();
        }
        
        public void GoBack()
        {
            SceneLoader.Instance.LoadScene("QuizLevel");
        }

        public void BackToPack()
        {
            SceneLoader.Instance.LoadScene("QuizPack");
        }

        public void GoHome()
        {
            SceneLoader.Instance.LoadScene("Home");
        }

        public void ResetScene()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }
        protected override IConnector[] GetSceneConnectors()
        {
            //return null;
            return new IConnector[]
            {
                new GameplayConnector()
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            //return null;
            return new IController[]
            {
                //new ClickGameController(),
                //new SfxController(),
                new SaveDataController(),
                new QuizController(),
                new CountdownController(),
                new DatabaseController(),
                new AnalyticController(),
                new GameFlowController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            yield return null;
            //_clickGame.SetView(_view.ClickGameView);
            _view.SetCallBacks(GoBack, ResetScene);
            _databaseController.SetPackFromPath(_saveData.Pack);
            _quizGame.SetLevel(_databaseController.GetLevelData(_saveData.Level));
            _quizGame.SetView(_view.QuizView);
            _quizGame.SetActions(BackToPack, GoBack, ResetScene, ()=>_view.ShowPopup(true));
            _countdown.SetView(_view.CountdownView);
            _countdown.SetTimeOutAction(GoBack);
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}
