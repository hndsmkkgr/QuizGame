using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
//using UnityEditor;

namespace ExampleGame.Module.Global
{
    public class DatabaseController : BaseController<DatabaseController>
    {
        private List<QuizPackSO> _quizPacks;

        private QuizPackSO _pack;
        
        public void SetPackFromPath(string pack)
        {
            //_pack = (QuizPackSO)AssetDatabase.LoadAssetAtPath("Assets/Resources/ScriptableObjects/Pack" + pack + ".asset", typeof(QuizPackSO));
            _pack = Resources.Load<QuizPackSO>("ScriptableObjects/Pack" + pack);
        }

        public List<string> GetPackList()
        {
            List<string> packs = new List<string>();
            foreach(QuizPackSO qp in _quizPacks)
            {
                packs.Add(qp.PackId);
            }
            return packs;
        }

        public List<QuizPackSO> GetPackContents()
        {
            return _quizPacks;
        }

        public List<string> GetLevelList()
        {
            List<string> levels = new List<string>();
            foreach(Level lv in _pack.PackContents)
            {
                levels.Add(lv.LevelId);
            }
            return levels;
        }

        public void SetQuizPacks(List<QuizPackSO> quizPacks)
        {
            _quizPacks = quizPacks;
        }

        public void SetCurrentPack(string currentPack)
        {
            for(int x = 0; x < _quizPacks.Count; x++)
            {
                if(_quizPacks[x].PackId == currentPack)
                {
                    _pack = _quizPacks[x];
                    return;
                }
            }
        }

        public Level GetLevelData(string levelId)
        {
            return _pack.PackContents[int.Parse(levelId)-1];
        }
    }
}