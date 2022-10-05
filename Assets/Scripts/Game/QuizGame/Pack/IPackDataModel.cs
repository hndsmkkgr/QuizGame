using Agate.MVC.Base;

namespace ExampleGame.Module.Pack
{
    public interface IPackDataModel : IBaseModel
    {
        string PackId { get; }
        bool IsUnlocked { get; }
        bool IsCompleted { get; }
        int Cost { get; }
    }
}
