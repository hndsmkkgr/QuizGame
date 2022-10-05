using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Agate.MVC.Base;

namespace ExampleGame.Module.ClickGame
{
    public class ClickGameView : ObjectView<IClickGameModel>
    {
        [SerializeField] private TMPro.TextMeshProUGUI _coinText;
        [SerializeField] private Button _earnCoinButton;
        [SerializeField] private Button _spendCoinButton;
        [SerializeField] private Button _backButton;

        protected override void InitRenderModel(IClickGameModel model)
        {
            _coinText.text = $"COIN: {model.Coin.ToString()}";
        }

        protected override void UpdateRenderModel(IClickGameModel model)
        {
            _coinText.text = $"COIN: {model.Coin.ToString()}";
        }

        public void SetCallbacks(UnityAction onClickEarnCoin, UnityAction onClickSpendCoin, UnityAction onClickBack)
        {
            _earnCoinButton.onClick.RemoveAllListeners();
            _spendCoinButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
            _earnCoinButton.onClick.AddListener(onClickEarnCoin);
            _spendCoinButton.onClick.AddListener(onClickSpendCoin);
            _backButton.onClick.AddListener(onClickBack);
        }
    }
}
