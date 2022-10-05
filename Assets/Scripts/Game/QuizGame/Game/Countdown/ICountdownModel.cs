using UnityEngine;
using System.Collections;
using Agate.MVC.Base;

namespace ExampleGame.Module.QuizGame
{
    public interface ICountdownModel : IBaseModel
    {
        int TimeRemaining { get; }
        bool IsRunning { get; }
    }
}