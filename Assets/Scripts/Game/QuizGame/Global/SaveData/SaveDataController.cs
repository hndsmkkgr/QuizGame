using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Newtonsoft.Json;

namespace ExampleGame.Module.Global
{
    public class SaveDataController : DataController<SaveDataController, SaveDataModel, ISaveDataModel>
    {
        public int Coin => _model.Coin;
        public string Pack => _model.CurrentPack;
        public string Level => _model.CurrentLevel;
        public List<string> CompletedPacks => _model.CompletedPacks;
        public List<string> CompletedLevels => _model.CompletedLevels;
        public List<string> UnlockedPacks => _model.UnlockedPacks;
        
        private void SaveData()
        {
            PlayerPrefs.SetInt("Coin", _model.Coin);
            PlayerPrefs.SetString("CurrentPack", _model.CurrentPack);
            PlayerPrefs.SetString("CurrentLevel", _model.CurrentLevel);

            string jsonPack = JsonConvert.SerializeObject(CompletedPacks);
            PlayerPrefs.SetString("CompletedPacks", jsonPack);
            string jsonLevel = JsonConvert.SerializeObject(CompletedLevels);
            PlayerPrefs.SetString("CompletedLevels", jsonLevel);
            string jsonUnlock = JsonConvert.SerializeObject(UnlockedPacks);
            PlayerPrefs.SetString("UnlockedPacks", jsonUnlock);

            PlayerPrefs.Save();
        }

        private void LoadData()
        {
            int coin = PlayerPrefs.GetInt("Coin");
            string currentPack = PlayerPrefs.GetString("CurrentPack");
            string currentLevel = PlayerPrefs.GetString("CurrentLevel");
            List<string> completedPacks = JsonConvert.DeserializeObject<List<string>>(PlayerPrefs.GetString("CompletedPacks"));
            List<string> completedLevels = JsonConvert.DeserializeObject<List<string>>(PlayerPrefs.GetString("CompletedLevels"));
            List<string> unlockedPacks = JsonConvert.DeserializeObject<List<string>>(PlayerPrefs.GetString("UnlockedPacks"));
            _model.SetCoinData(coin);
            _model.SetCurrentPack(currentPack);
            _model.SetCurrentLevel(currentLevel);
            _model.SetCompletedLevel(completedLevels);
            _model.SetCompletedPack(completedPacks);
            _model.SetUnlockedPack(unlockedPacks);
        }

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            LoadData();
        }

        public void OnUpdateCoin(int coin)
        {
            _model.SetCoinData(coin);
            SaveData();
        }

        public void OnUpdatePackSelection(string pack)
        {
            _model.SetCurrentPack(pack);
            SaveData();
        }

        public void OnUpdateLevelSelection(string level)
        {
            _model.SetCurrentLevel(level);
            SaveData();
        }

        public void OnUpdateLevelComplete(string level)
        {
            _model.AddCompletedLevel(level);
            SaveData();
        }
        
        public void OnUpdatePackComplete(string pack)
        {
            _model.AddCompletedPack(pack);
            SaveData();
        }

        public void OnUpdatePackUnlock(string pack)
        {
            _model.AddUnlockedPack(pack);
            SaveData();
        }

    }
}
