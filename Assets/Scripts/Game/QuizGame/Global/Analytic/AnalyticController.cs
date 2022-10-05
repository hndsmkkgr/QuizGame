using UnityEngine;
using Agate.MVC.Base;

namespace ExampleGame.Module.Global
{
    public class AnalyticController : DataController<AnalyticController, AnalyticModel, IAnalyticModel>
    {
        public void SendPackUnlockAnalytic(string pack)
        {
            _model.SetPackUnlocked(pack);
            Debug.Log(_model.PackUnlock);
        }

        public void SendLevelCompleteAnalytic(string level)
        {
            _model.SetLevelFinished(level);
            Debug.Log(_model.LevelFinished);
        }
    }
}