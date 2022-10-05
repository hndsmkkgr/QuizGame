using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Agate.MVC.Base;

namespace ExampleGame.Home
{
    public class HomeView : BaseSceneView
    {
        [SerializeField] Button _playButton;

        public void SetCallBacks(UnityAction onClickPlayButton)
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(onClickPlayButton);
        }
    }
}
