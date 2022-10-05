using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Agate.MVC.Base;

namespace ExampleGame.Module.Level
{
    public class LevelView : BaseSceneView
    {
        [SerializeField] private Button _backButton;
        [SerializeField] public LevelDataView LevelDataView;

        public void SetCallBacks(UnityAction onBackButtonClick)
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(onBackButtonClick);
        }
    }
}