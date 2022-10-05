using Agate.MVC.Base;

namespace ExampleGame.Module.Level
{
    public class LevelDataModel : BaseModel, ILevelDataModel
    {
        public string LevelId { get; private set; }
        public bool IsCompleted { get; private set; }

        public void CompleteLevel(bool isCompleted)
        {
            IsCompleted = isCompleted;
            SetDataAsDirty();
        }

        public void SelectLevel(string level)
        {
            LevelId = level;
            SetDataAsDirty();
        }
    }
}
