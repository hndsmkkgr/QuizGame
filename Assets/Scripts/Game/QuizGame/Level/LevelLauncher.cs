using System.Collections;
using Agate.MVC.Base;
using ExampleGame.Boot;
using Agate.MVC.Core;
using ExampleGame.Module.Global;

namespace ExampleGame.Module.Level
{
    public class LevelLauncher : SceneLauncher<LevelLauncher, LevelView>
    {
        public override string SceneName => "QuizLevel";
        private LevelDataController _levelData;
        private SaveDataController _saveData;
        private DatabaseController _dataBase;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new LevelConnector()
            };
        }

        public void GoBack()
        {
            SceneLoader.Instance.LoadScene("QuizPack");
        }

        public void SelectLevel()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new LevelDataController(),
                new SaveDataController(),
                new DatabaseController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            yield return null;
            _view.SetCallBacks(GoBack);
            _dataBase.SetPackFromPath(_saveData.Pack);
            _levelData.SetLevelAction(SelectLevel);
            _levelData.SetView(_view.LevelDataView);
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}