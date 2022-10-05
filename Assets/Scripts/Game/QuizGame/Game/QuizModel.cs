using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace ExampleGame.Module.QuizGame
{
    public class QuizModel : BaseModel, IQuizModel
    {
        public string Pack { get; private set; }
        public string Level { get; private set; }

        public void SetLevel(string level)
        {
            Level = level;
        }

        public void SetPack(string pack)
        {
            Pack = pack;
        }
    }
}