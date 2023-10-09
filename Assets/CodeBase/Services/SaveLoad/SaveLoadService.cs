using Assets.CodeBase.Architecture.Factory;
using Assets.CodeBase.Data;
using Assets.CodeBase.Services.PersistentProgress;

namespace Assets.CodeBase.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
    
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;
        
        public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }
        
        public void SaveProgress()
        {
            throw new System.NotImplementedException();
        }

        public PlayerProgress LoadProgress()
        {
            throw new System.NotImplementedException();
        }
    }
}