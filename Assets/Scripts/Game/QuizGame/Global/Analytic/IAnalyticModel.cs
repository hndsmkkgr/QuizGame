using Agate.MVC.Base;

namespace ExampleGame.Module.Global
{
    public interface IAnalyticModel : IBaseModel
    {
        string LevelFinished { get; }
        string PackUnlock { get; }
    }
}