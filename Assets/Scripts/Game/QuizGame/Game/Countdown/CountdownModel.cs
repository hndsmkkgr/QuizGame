using System.Collections;
using UnityEngine;
using Agate.MVC.Base;
using ExampleGame.Message;
using Agate.MVC.Core;

namespace ExampleGame.Module.QuizGame
{
    public class CountdownModel : BaseModel, ICountdownModel
    {
        public int TimeRemaining { get; private set; }

        public bool IsRunning { get; private set; }
        
        public void SetCountdown(int time)
        {
            TimeRemaining = time;
        }
        
        public void EnableCountdown(bool isRunning)
        {
            IsRunning = isRunning;
        }

        public void DecreaseTime()
        {
            TimeRemaining--;
        }
    }
}