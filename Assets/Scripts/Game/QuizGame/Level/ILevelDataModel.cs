using UnityEngine;
using System.Collections;
using Agate.MVC.Base;

namespace ExampleGame.Module.Level
{
    public interface ILevelDataModel : IBaseModel
    {
        string LevelId { get; }
        bool IsCompleted { get; }
    }
}