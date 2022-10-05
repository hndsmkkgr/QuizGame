using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace ExampleGame.Module.ClickGame
{
    public interface IClickGameModel : IBaseModel
    {
        int Coin { get; }
    }
}
