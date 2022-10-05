using Agate.MVC.Base;
using System.Collections.Generic;

namespace ExampleGame.Module.Global
{
    public interface ISaveDataModel : IBaseModel
    {
        int Coin { get; }
        List<string> UnlockedPacks { get; }
        List<string> CompletedPacks { get; }
        List<string> CompletedLevels { get; }
        string CurrentPack { get; }
        string CurrentLevel { get; }
    }
}
