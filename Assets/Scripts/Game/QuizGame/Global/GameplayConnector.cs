using Agate.MVC.Base;
using ExampleGame.Module.Global;
//using ExampleGame.Module.Sfx;
using ExampleGame.Message;

namespace ExampleGame.Module.QuizGame
{
    public class GameplayConnector : BaseConnector
    {
        private SaveDataController _saveData;
        //private SfxController _soundfx;

        protected override void Connect()
        {
            Subscribe<UpdateCoinMessage>(OnUpdateCoin);
            Subscribe<UpdateLevelSelection>(OnUpdateLevelSelection);
            Subscribe<UpdateLevelComplete>(OnUpdateLevelComplete);
            Subscribe<UpdatePackComplete>(OnUpdatePackComplete);
        }

        public void OnUpdateCoin(UpdateCoinMessage message)
        {
            _saveData.OnUpdateCoin(message.Coin);
            //_soundfx.OnUpdateCoin();
        }

        public void OnUpdateLevelSelection(UpdateLevelSelection message)
        {
            _saveData.OnUpdateLevelSelection(message.Level);
        }

        public void OnUpdateLevelComplete(UpdateLevelComplete message)
        {
            _saveData.OnUpdateLevelComplete(message.Level);
        }

        public void OnUpdatePackComplete(UpdatePackComplete message)
        {
            _saveData.OnUpdatePackComplete(message.Pack);
        }
        
        protected override void Disconnect()
        {
            Unsubscribe<UpdateCoinMessage>(OnUpdateCoin);
            Unsubscribe<UpdateLevelSelection>(OnUpdateLevelSelection);
            Unsubscribe<UpdatePackComplete>(OnUpdatePackComplete);
            Unsubscribe<UpdateLevelComplete>(OnUpdateLevelComplete);
        }
    }
}
