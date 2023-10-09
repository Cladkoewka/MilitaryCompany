using Assets.CodeBase.Data;

namespace Assets.CodeBase.Services.PersistentProgress
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}