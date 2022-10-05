using UnityEngine;
using UnityEngine.UI;

namespace ExampleGame.Module.Level
{
    public class LevelButton : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI LevelText;
        public string LevelId;
        public Button SelectButton;
        public Image CompletedImage;
    }
}