using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using ExampleGame.Module.Global;

namespace ExampleGame.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        protected override IConnector[] GetConnectors()
        {
            return null;
        }

        protected override IController[] GetDependencies()
        {
            //return null;
            return new IController[]{
                new SaveDataController()
            };
        }

        protected override IEnumerator StartInit()
        {
            yield return null;
        }
    }
}