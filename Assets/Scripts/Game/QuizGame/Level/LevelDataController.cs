using System.Collections.Generic;
using UnityEngine.Events;
using Agate.MVC.Base;
using ExampleGame.Module.Global;
using ExampleGame.Message;

namespace ExampleGame.Module.Level
{
    public class LevelDataController : ObjectController<LevelDataController, LevelDataModel, ILevelDataModel, LevelDataView>
    {
        private SaveDataController _saveData;
        private DatabaseController _dataBase;
        private UnityAction _openGameplay;

        public override void SetView(LevelDataView view)
        {
            base.SetView(view);
            LoadLevelList();
            view.SetCallBacks(OnSelectLevel);
        }

        public void SetLevelAction(UnityAction action)
        {
            _openGameplay = action;
        }

        private void ShowCheckmark()
        {
            if(_saveData.CompletedLevels != null)
            {
                for(int x = 1; x <= _dataBase.GetLevelList().Count; x++)
                {
                    for(int y = 0; y < _saveData.CompletedLevels.Count; y++)
                    {
                        if(_saveData.CompletedLevels[y] == _saveData.Pack + x)
                        {
                            _view.ShowCompleted(x);
                        }
                    }
                }
            }
        }

        private void LoadLevelList()
        {
            List<string> levels = _dataBase.GetLevelList();
            for (int x = 1; x <= _dataBase.GetLevelList().Count; x++)
            {
                _view.InstantiateButtons(_saveData.Pack, x.ToString());
            }
            ShowCheckmark();
        }

        private void OnSelectLevel(string level)
        {
            Publish<UpdateLevelSelection>(new UpdateLevelSelection(level));
            _model.SelectLevel(level);
            _openGameplay();
        }
    }
}
