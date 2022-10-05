using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using ExampleGame.Boot;

namespace ExampleGame.Home
{
    public class HomeLauncher : SceneLauncher<HomeLauncher, HomeView>
    {
        public override string SceneName => "Home";

        private void OnClickPlayButton()
        {
            //SceneLoader.Instance.LoadScene("Gameplay");
            SceneLoader.Instance.LoadScene("QuizPack");
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return null;
        }

        protected override IController[] GetSceneDependencies()
        {
            return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            yield return null;
            _view.SetCallBacks(OnClickPlayButton);
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}