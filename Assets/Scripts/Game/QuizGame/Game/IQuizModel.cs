using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace ExampleGame.Module.QuizGame
{
    public interface IQuizModel : IBaseModel
    {
        string Pack { get; }
        string Level { get; }
    }
}