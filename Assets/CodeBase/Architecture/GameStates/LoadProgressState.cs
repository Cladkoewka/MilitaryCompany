using Assets.CodeBase.Data;
using Assets.CodeBase.Services.PersistentProgress;
using Assets.CodeBase.Services.SaveLoad;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.Architecture.GameStates
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }
        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, string>("Base");
        }

        public void Exit()
        {
            Debug.Log("Exit LoadProgressState");
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            var progress =  new PlayerProgress();

            return progress;
        }
    }
}