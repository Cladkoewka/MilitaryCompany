using Assets.CodeBase.Architecture.Factory;
using Assets.CodeBase.Services.PersistentProgress;
using Assets.CodeBase.Services.StaticData;
using Assets.CodeBase.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.CodeBase.Architecture.GameStates
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly IStaticDataService _staticData;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory, IPersistentProgressService progressService, IStaticDataService staticDataService)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _staticData = staticDataService;
        }
        
        public void Enter(string sceneName)
        {
            Debug.Log("Enter LoadLevelState");
            _staticData.Load();
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            Debug.Log("Exit LoadLevelState");
        }
        
        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();
            
            _stateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            InitSpawners();
        }
        
        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }
        
        private void InitSpawners()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelData = _staticData.ForLevel(sceneKey);
            
            
            foreach (UnitSpawnerStaticData spawnerData in levelData.UnitSpawners)
                _gameFactory.CreateSpawner(spawnerData.Id, spawnerData.Position, spawnerData.MonsterTypeId);
        }
    }
}