using Assets.CodeBase.Data;

namespace Assets.CodeBase.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}