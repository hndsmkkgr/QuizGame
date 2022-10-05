using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Agate.MVC.Base;

namespace ExampleGame.Module.QuizGame
{
    public class CountdownView : ObjectView<ICountdownModel>
    {
        [SerializeField] private TMPro.TextMeshProUGUI _timer;
        private IEnumerator _timerCoroutine;

        protected override void InitRenderModel(ICountdownModel model)
        {
            _timer.text = model.TimeRemaining.ToString();
        }

        protected override void UpdateRenderModel(ICountdownModel model)
        {
            _timer.text = model.TimeRemaining.ToString();
        }
        
        public void SetText(int time)
        {
            _timer.text = time.ToString();
        }

        public void RunTimer(IEnumerator action)
        {
            _timerCoroutine = action;
            StartCoroutine(_timerCoroutine);
        }
    }
}