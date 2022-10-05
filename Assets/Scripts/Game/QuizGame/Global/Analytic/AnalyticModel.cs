using Agate.MVC.Base;

namespace ExampleGame.Module.Global
{
    public class AnalyticModel : BaseModel, IAnalyticModel
    {
        public string LevelFinished { get; private set; }
        public string PackUnlock { get; private set; }

        public void SetLevelFinished(string level)
        {
            LevelFinished = "Level " + level + " is finished";
        }

        public void SetPackUnlocked(string pack)
        {
            PackUnlock = "Level " + pack + " is unlocked";
        }
    }
}