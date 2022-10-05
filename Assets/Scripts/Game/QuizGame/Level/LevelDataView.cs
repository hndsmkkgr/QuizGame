using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Agate.MVC.Base;

namespace ExampleGame.Module.Level
{
    public class LevelDataView : ObjectView<ILevelDataModel>
    {
        private List<LevelButton> _levelDatas = new List<LevelButton>();
        [SerializeField] private GameObject _levelPrefab;
        [SerializeField] private GameObject _scrollContent;

        protected override void InitRenderModel(ILevelDataModel model)
        {
            return;
        }

        protected override void UpdateRenderModel(ILevelDataModel model)
        {
            return;
        }

        public void InstantiateButtons(string pack, string level)
        {
            GameObject levelPrefab = Instantiate(_levelPrefab, _scrollContent.transform);
            LevelButton levelButton = levelPrefab.GetComponent<LevelButton>();
            levelButton.LevelText.text = pack + "-" + level;
            levelButton.LevelId = level;

            _levelDatas.Add(levelButton);
        }

        public void SetCallBacks(UnityAction<string> onSelectLevel)
        {
            foreach (LevelButton level in _levelDatas)
            {
                level.SelectButton.onClick.RemoveAllListeners();
                level.SelectButton.onClick.AddListener(() => onSelectLevel(level.LevelId));
            }
        }
        
        public void ShowCompleted(int level)
        {
            LevelButton lb = _levelDatas[level - 1];
            lb.CompletedImage.gameObject.SetActive(true);
        }
    }

}