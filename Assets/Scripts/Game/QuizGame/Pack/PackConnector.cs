using Agate.MVC.Base;
using ExampleGame.Module.Global;
using ExampleGame.Message;

namespace ExampleGame.Module.Pack
{
    public class PackConnector : BaseConnector
    {
        private SaveDataController _saveData;

        protected override void Connect()
        {
            Subscribe<UpdateCoinMessage>(OnUpdateCoin);
            Subscribe<UpdatePackUnlock>(OnUpdatePackUnlock);
            Subscribe<UpdatePackSelection>(OnUpdatePackSelection);
        }

        public void OnUpdateCoin(UpdateCoinMessage message)
        {
            _saveData.OnUpdateCoin(message.Coin);
        }

        public void OnUpdatePackSelection(UpdatePackSelection message)
        {
            _saveData.OnUpdatePackSelection(message.Pack);
        }

        public void OnUpdatePackUnlock(UpdatePackUnlock message)
        {
            _saveData.OnUpdatePackUnlock(message.Pack);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateCoinMessage>(OnUpdateCoin);
            Unsubscribe<UpdatePackUnlock>(OnUpdatePackUnlock);
            Unsubscribe<UpdatePackSelection>(OnUpdatePackSelection);
        }
    }
}
