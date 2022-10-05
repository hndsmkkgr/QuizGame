using UnityEngine;
using System.Collections;
using Agate.MVC.Base;
using UnityEngine.Events;

namespace ExampleGame.Module.QuizGame
{
   public class CountdownController : ObjectController<CountdownController, CountdownModel, ICountdownModel, CountdownView>
    {
        private UnityAction _gameOver;
        public override void SetView(CountdownView view)
        {
            base.SetView(view);
            _view.RunTimer(Countdown());
        }

        public void SetTimeOutAction(UnityAction gameOver)
        {
            _gameOver = gameOver;
        }

        public void SetCountdown(int time)
        {
            _model.SetCountdown(time); //angka gini mending dr inspector
        }

        public void EnableCountdown(bool isEnabled)
        {
            _model.EnableCountdown(isEnabled);
        }

        public IEnumerator Countdown()
        {
            while(_model.IsRunning)
            {
                if (_model.TimeRemaining > 0)
                {
                    _model.DecreaseTime();
                    _view.SetText(_model.TimeRemaining);
                }
                else
                {
                    Debug.Log("gameover");
                    EnableCountdown(false);
                    _gameOver();
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }
}