using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Agate.MVC.Base;

namespace ExampleGame.Module.Pack {
    public class PackView : BaseSceneView
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _closePopup;
        [SerializeField] private GameObject _popup;
        [SerializeField] public PackDataView PackDataView;
        
        public void SetCallBacks(UnityAction onBackButtonClick)
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(onBackButtonClick);
            _closePopup.onClick.RemoveAllListeners();
            _closePopup.onClick.AddListener(()=>ShowPopup(false));
        }

        public void ShowPopup(bool isShow)
        {
            _popup.SetActive(isShow);
        }
    }
}