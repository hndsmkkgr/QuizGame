using UnityEngine.Events;
using Agate.MVC.Base;
using ExampleGame.Module.Global;
using ExampleGame.Message;

namespace ExampleGame.Module.QuizGame
{
    public class QuizController : ObjectController<QuizController, QuizModel, IQuizModel, QuizView>
    {
        private Global.Level _level;
        private GameFlowController _gameflow;
        private SaveDataController _saveData;
        private DatabaseController _dataBase;
        private UnityAction _backToPack;
        private UnityAction _backToLevel;
        private UnityAction _nextLevel;
        private UnityAction _showPopup;

        public override void SetView(QuizView view)
        {
            base.SetView(view);
            view.SetCallBacks(SelectAnswer);

            view.SetHint(_level.Hint);
            view.SetButtonText(_level.Choices);
            view.SetQuestion(_level.Question);

            _gameflow.StartGame(_level.TotalTime);
        }

        public void SetLevel(Global.Level level)
        {
            _model.SetPack(_saveData.Pack);
            _model.SetLevel(level.LevelId);
            _level = level;
        }
        
        public void SetActions(UnityAction backToPack, UnityAction backToLevel, UnityAction nextLevel, UnityAction showPopup)
        {
            _backToPack = backToPack;
            _backToLevel = backToLevel;
            _nextLevel = nextLevel;
            _showPopup = showPopup;
        }

        private void SelectAnswer(int answer)
        {
            _gameflow.TimeOut();
            if (_level.Choices[answer] == _level.Answer)
            {
                _gameflow.SendData(_model.Level);
                StoreLevelProgress();
                if (_saveData.Level != _dataBase.GetLevelList().Count.ToString())
                {
                    string lvl = (int.Parse(_model.Level) + 1).ToString();
                    _model.SetLevel(lvl);
                    Publish<UpdateLevelSelection>(new UpdateLevelSelection(_model.Level));
                    _nextLevel();
                }
                else
                {
                    int levelCount = GetPackCompletion();
                    if (levelCount == _dataBase.GetLevelList().Count) _backToPack();
                    else _backToLevel();
                }
            }
            else
            {
                _showPopup();
            }
            //model kalo di game kecil emg gabut tp kalo di game gede contoh genshin
            //HP gamungkin selalu send ke server tp bisa di lokal dulu (model) trs baru dikirim pas logout
            //kalo ga pindah scene sih enaknya ada data yg diunload krn garbage collector ga reliable
        }

        private int GetPackCompletion()
        {
            int levelCount = 0;
            foreach (string lv in _saveData.CompletedLevels)
            {
                if (lv.Contains(_saveData.Pack)) levelCount++;
            }
            return levelCount;
        }

        private void StoreLevelProgress()
        {
            if (_saveData.CompletedLevels != null)
            {
                if (_saveData.CompletedLevels.Contains(_model.Pack + _model.Level)) return;
            }
            Publish<UpdateLevelComplete>(new UpdateLevelComplete(_model.Pack + _model.Level));

            int coin = _saveData.Coin;
            coin += _level.Reward;
            _gameflow.GiveReward(coin);

            int levelCount = GetPackCompletion();
            if (levelCount == _dataBase.GetLevelList().Count)
            {
                if (_saveData.CompletedPacks != null)
                {
                    if (_saveData.CompletedPacks.Contains(_saveData.Pack)) return;
                }
                Publish<UpdatePackComplete>(new UpdatePackComplete(_model.Pack));
            }
        }
    }
}