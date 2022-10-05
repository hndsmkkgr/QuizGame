using System.Collections;
using ExampleGame.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine;
using System.Collections.Generic;
using ExampleGame.Module.Global;

namespace ExampleGame.Module.Pack
{
    public class PackLauncher : SceneLauncher<PackLauncher, PackView>
    {
        [SerializeField] private List<QuizPackSO> _quizPacks;
        public override string SceneName => "QuizPack";
        private PackDataController _packDataController;
        private DatabaseController _dataBase;
        private PackUnlockController _packUnlock;
        private SaveDataController _saveData;
        private AnalyticController _analytic;
        
        private void GoBack()
        {
            SceneLoader.Instance.LoadScene("Home");
        }

        private void SelectPack()
        {
            SceneLoader.Instance.LoadScene("QuizLevel");
        }
        
        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new PackConnector()
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new SaveDataController(),
                new PackDataController(),
                new DatabaseController(),
                new AnalyticController(),
                new PackUnlockController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            yield return null;
            _view.SetCallBacks(GoBack);
            _dataBase.SetQuizPacks(_quizPacks);
            _packUnlock.InitUnlockedPack();
            _packDataController.SetActions(SelectPack, ()=>_view.ShowPopup(true));
            _packDataController.SetView(_view.PackDataView);
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

    }
}
