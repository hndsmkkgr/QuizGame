using Agate.MVC.Base;
using UnityEngine;
using System.Collections.Generic;

namespace ExampleGame.Module.Global
{
    public class SaveDataModel : BaseModel, ISaveDataModel
    {
        public int Coin { get; set;}
        public string CurrentPack { get; private set; }
        public string CurrentLevel { get; private set; }
        public List<string> UnlockedPacks { get; private set; }
        public List<string> CompletedPacks { get; private set; }
        public List<string> CompletedLevels { get; private set; }

        public void SetCoinData(int coin)
        {
            Coin = coin;
            SetDataAsDirty();
        }

        public void SetUnlockedPack(List<string> packs)
        {
            UnlockedPacks = packs;
            SetDataAsDirty();
        }

        public void AddUnlockedPack(string pack)
        {
            if (UnlockedPacks == null)
            {
                UnlockedPacks = new List<string>();
            }
            UnlockedPacks.Add(pack);
            SetDataAsDirty();
        }

        public void SetCompletedPack(List<string> packs)
        {
            CompletedPacks = packs;
            SetDataAsDirty();
        }

        public void AddCompletedPack(string pack)
        {
            if (CompletedPacks == null)
            {
                CompletedPacks = new List<string>();
            }
            CompletedPacks.Add(pack);
            SetDataAsDirty();
        }

        public void SetCompletedLevel(List<string> levels)
        {
            CompletedLevels = levels;
            SetDataAsDirty();
        }

        public void AddCompletedLevel(string level)
        {
            if(CompletedLevels == null)
            {
                CompletedLevels = new List<string>();
            }
            CompletedLevels.Add(level);
            SetDataAsDirty();
        }

        public void SetCurrentPack(string pack)
        {
            CurrentPack = pack;
            SetDataAsDirty();
        }

        public void SetCurrentLevel(string level)
        {
            CurrentLevel = level;
            SetDataAsDirty();
        }
    }
}