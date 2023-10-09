using Assets.CodeBase.Data;

namespace Assets.CodeBase.Services.PersistentProgress
{
    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}