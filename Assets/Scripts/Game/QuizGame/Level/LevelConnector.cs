using Agate.MVC.Base;
using ExampleGame.Module.Global;
using ExampleGame.Message;

namespace ExampleGame.Module.Level
{
    public class LevelConnector : BaseConnector
    {
        private SaveDataController _saveData;

        protected override void Connect()
        {
            Subscribe<UpdateLevelSelection>(OnUpdateLevelSelection);
        }
        
        public void OnUpdateLevelSelection(UpdateLevelSelection message)
        {
            _saveData.OnUpdateLevelSelection(message.Level);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateLevelSelection>(OnUpdateLevelSelection);
        }
    }
}
