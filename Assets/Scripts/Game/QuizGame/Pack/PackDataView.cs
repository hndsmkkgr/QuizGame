using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Agate.MVC.Base;

namespace ExampleGame.Module.Pack
{
    public class PackDataView : ObjectView<IPackDataModel>
    {
        private List<PackButton> _packDatas = new List<PackButton>();
        [SerializeField] private GameObject _packPrefab;
        [SerializeField] private GameObject _scrollContent;
        [SerializeField] private TMPro.TextMeshProUGUI _coin;

        public void InstantiateButtons(string pack, int cost, bool isUnlocked)
        {
            GameObject packPrefab = Instantiate(_packPrefab, _scrollContent.transform);
            PackButton packButton = packPrefab.GetComponent<PackButton>();
            packButton.PackId.text = pack;
            packButton.PackCost.text = cost.ToString();

            if (!isUnlocked)
            {
                packButton.SelectButton.interactable = false;
                packButton.UnlockButton.gameObject.SetActive(true);
            }

            _packDatas.Add(packButton);
        }

        public void SetCallBacks(UnityAction<string> onSelectPack, UnityAction<string> onUnlockPack)
        {
            foreach(PackButton pack in _packDatas)
            {
                pack.SelectButton.onClick.RemoveAllListeners();
                pack.UnlockButton.onClick.RemoveAllListeners();
                pack.SelectButton.onClick.AddListener(() => onSelectPack(pack.PackId.text));
                pack.UnlockButton.onClick.AddListener(() => onUnlockPack(pack.PackId.text));
            }
        }

        public void EnableButtons(string pack, bool isUnlocked)
        {
            foreach(PackButton pb in _packDatas)
            {
                if(pb.PackId.text == pack)
                {
                    pb.SelectButton.interactable = isUnlocked;
                    pb.UnlockButton.gameObject.SetActive(!isUnlocked);
                    return;
                }
            }
        }

        public void ShowCompleted(int packIndex)
        {
            _packDatas[packIndex].CompletedImage.gameObject.SetActive(true);
        }

        protected override void InitRenderModel(IPackDataModel model)
        {
            return;
        }

        protected override void UpdateRenderModel(IPackDataModel model)
        {
            return;
        }
        
        public void SetCoinText(string coin)
        {
            _coin.text = "Coin: " + coin;
        }
    }
}