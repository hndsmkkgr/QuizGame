using Agate.MVC.Base;
using ExampleGame.Module.Global;
using ExampleGame.Message;

namespace ExampleGame.Module.Pack
{
    public class PackUnlockController : BaseController<PackUnlockController>
    {
        private SaveDataController _saveData;
        private DatabaseController _dataBase;
        private AnalyticController _analytic;

        public void UnlockPack(string packId)
        {
            Publish<UpdatePackUnlock>(new UpdatePackUnlock(packId));
            _analytic.SendPackUnlockAnalytic(packId);
        }

        public bool GetLockStatus(string pack)
        {
            if (_saveData.UnlockedPacks.Contains(pack)) return true;
            else return false;
        }

        public void InitUnlockedPack()
        {
            if(_saveData.UnlockedPacks == null)
            {
                UnlockPack(_dataBase.GetPackList()[0]);
            }
        }

        public int GetPackCost(string pack)
        {
            foreach(QuizPackSO q in _dataBase.GetPackContents())
            {
                if (q.PackId == pack) return q.Cost;
            }
            return 0;
        }
    }
}