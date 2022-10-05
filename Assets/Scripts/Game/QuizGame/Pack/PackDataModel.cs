using Agate.MVC.Base;

namespace ExampleGame.Module.Pack
{
    public class PackDataModel : BaseModel, IPackDataModel
    {
        public string PackId { get; private set; }
        public bool IsUnlocked { get; private set; }
        public bool IsCompleted { get; private set; }
        public int Cost { get; private set; }

        public void SetCost(int cost)
        {
            Cost = cost;
            SetDataAsDirty();
        }

        public void UnlockPack(bool isUnlocked)
        {
            IsUnlocked = isUnlocked;
            SetDataAsDirty();
        }

        public void CompletePack(bool isCompleted)
        {
            IsCompleted = isCompleted;
            SetDataAsDirty();
        }

        public void SelectPack(string pack)
        {
            PackId = pack;
            SetDataAsDirty();
        }
    }
}