using UnityEngine;
using UnityEngine.UI;

namespace ExampleGame.Module.Pack
{
    public class PackButton : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI PackId;
        public TMPro.TextMeshProUGUI PackCost;
        public Button SelectButton;
        public Button UnlockButton;
        public Image CompletedImage;
    }
}