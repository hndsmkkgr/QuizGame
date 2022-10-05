using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;
using ExampleGame.Module.Global;
using ExampleGame.Message;

namespace ExampleGame.Module.Pack
{
    public class PackDataController : ObjectController<PackDataController, PackDataModel, IPackDataModel, PackDataView>
    {
        private SaveDataController _saveData;
        private DatabaseController _dataBase;
        private PackUnlockController _unlockPackController;
        private UnityAction _openLevelSelection;
        private UnityAction _showPopup;

        public override void SetView(PackDataView view)
        {
            base.SetView(view);
            LoadPackList();
            view.SetCallBacks(OnSelectPack, OnUnlockPack);
            view.SetCoinText(_saveData.Coin.ToString());
        }
        
        public void SetActions(UnityAction levelSelect, UnityAction showPopup)
        {
            _openLevelSelection = levelSelect;
            _showPopup = showPopup;
        }

        public void OnSelectPack(string pack)
        {
            Publish<UpdatePackSelection>(new UpdatePackSelection(pack));
            _model.SelectPack(pack);
            _openLevelSelection();
        }

        private void ShowCheckmark()
        {
            if (_saveData.CompletedPacks != null)
            {
                for(int x = 0; x < _saveData.CompletedPacks.Count; x++)
                {
                    for(int y = 0; y < _dataBase.GetPackList().Count; y++)
                    {
                        if(_saveData.CompletedPacks[x] == _dataBase.GetPackList()[y])
                        {
                            _view.ShowCompleted(y);
                        }
                    }
                }
            }
        }

        private void OnUnlockPack(string pack)
        {
            _model.SetCost(_unlockPackController.GetPackCost(pack));
            if(_saveData.Coin < _model.Cost)
            {
                _showPopup();
            }
            else
            {
                int coin = _saveData.Coin;
                coin -= _model.Cost;
                _view.SetCoinText(coin.ToString());
                _view.EnableButtons(pack, true);
                _unlockPackController.UnlockPack(pack);
                Publish<UpdateCoinMessage>(new UpdateCoinMessage(coin));
            }
        }

        public PackDataModel[] GetPackList()
        {
            return null;
        }

        private void LoadPackList()
        {
            List<string> packs = _dataBase.GetPackList();
            for (int x = 0; x < _dataBase.GetPackList().Count; x++)
            {
                bool isUnlocked = _unlockPackController.GetLockStatus(packs[x]);
                _view.InstantiateButtons(packs[x], _dataBase.GetPackContents()[x].Cost, isUnlocked);
            }
            ShowCheckmark();
        }
    }
}