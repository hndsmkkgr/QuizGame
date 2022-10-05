using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame.Module.Global
{
    [CreateAssetMenu(fileName = "QuizPackSO", menuName = "ScriptableObjects/QuizPackSO")]
    public class QuizPackSO : ScriptableObject
    {
        public string PackId;
        public int Cost;
        public List<Level> PackContents;
    }

    [System.Serializable]
    public struct Level
    {
        public string LevelId;
        public string Question;
        public List<string> Choices;
        public string Answer;
        public Sprite Hint;
        public int Reward;
        public int TotalTime;
    }
}