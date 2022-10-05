using UnityEngine;
using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;

namespace ExampleGame.Boot
{
    public abstract class SceneLauncher<TLauncher, TView> : BaseLauncher<TLauncher, TView>
        where TLauncher : SceneLauncher<TLauncher, TView>
        where TView : BaseSceneView
    {
        protected override ILoad GetLoader()
        {
            return SceneLoader.Instance;
        }

        protected override IMain GetMain()
        {
            //tdnya gamelauncher
            return GameMain.Instance;
        }

        protected override ISplash GetSplash()
        {
            return SplashScreen.Instance;
        }
    }
}
