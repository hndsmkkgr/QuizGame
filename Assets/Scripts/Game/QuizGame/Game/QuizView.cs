using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Agate.MVC.Base;

namespace ExampleGame.Module.QuizGame
{
    public class QuizView : ObjectView<IQuizModel>
    {
        [SerializeField] private Answer _answerA;
        [SerializeField] private Answer _answerB;
        [SerializeField] private Answer _answerC;
        [SerializeField] private Answer _answerD;
        [SerializeField] private TMPro.TextMeshProUGUI _question;
        [SerializeField] private Image _hint;

        protected override void InitRenderModel(IQuizModel model)
        {
            return;
        }

        protected override void UpdateRenderModel(IQuizModel model)
        {
            return;
        }

        public void SetCallBacks(UnityAction<int> onAnswerClick)
        {
            _answerA.AnswerButton.onClick.RemoveAllListeners();
            _answerB.AnswerButton.onClick.RemoveAllListeners();
            _answerC.AnswerButton.onClick.RemoveAllListeners();
            _answerD.AnswerButton.onClick.RemoveAllListeners();

            _answerA.AnswerButton.onClick.AddListener(() => onAnswerClick(0));
            _answerB.AnswerButton.onClick.AddListener(() => onAnswerClick(1));
            _answerC.AnswerButton.onClick.AddListener(() => onAnswerClick(2));
            _answerD.AnswerButton.onClick.AddListener(() => onAnswerClick(3));
        }

        public void SetQuestion(string question)
        {
            _question.text = question;
        }

        public void SetButtonText(List<string> answers)
        {
            _answerA.AnswerText.text = answers[0];
            _answerB.AnswerText.text = answers[1];
            _answerC.AnswerText.text = answers[2];
            _answerD.AnswerText.text = answers[3];
        }

        public void SetHint(Sprite sprite)
        {
            _hint.sprite = sprite;
        }
    }

    [System.Serializable]
    public struct Answer
    {
        public Button AnswerButton;
        public TMPro.TextMeshProUGUI AnswerText;
    }
}