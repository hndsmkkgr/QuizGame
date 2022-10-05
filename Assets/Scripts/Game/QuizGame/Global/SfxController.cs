using UnityEngine;
using Agate.MVC.Base;

namespace ExampleGame.Module.Sfx
{
    public class SfxController : BaseController<SfxController>
    {
        public void OnUpdateCoin()
        {
            Debug.Log("Play SFX");
        }
    }
}