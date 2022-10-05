using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Agate.MVC.Base;
//using ExampleGame.Module.ClickGame;
using ExampleGame.Module.QuizGame;

namespace ExampleGame.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        //[SerializeField] public ClickGameView ClickGameView;
        [SerializeField] public QuizView QuizView;
        [SerializeField] public CountdownView CountdownView;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _retryButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private GameObject _popup;

        public void SetCallBacks(UnityAction onBackClick, UnityAction onRetryClick)
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(onBackClick);
            _retryButton.onClick.RemoveAllListeners();
            _retryButton.onClick.AddListener(onRetryClick);
            _quitButton.onClick.RemoveAllListeners();
            _quitButton.onClick.AddListener(onBackClick);
        }
        
        public void ShowPopup(bool isShow)
        {
            _popup.SetActive(isShow);
        }
    }

}
