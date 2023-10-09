using Assets.CodeBase.Architecture.Factory;
using Assets.CodeBase.Services.PersistentProgress;
using Assets.CodeBase.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Architecture.GameStates
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        
        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader/*, IGameFactory gameFactory, IPersistentProgressService progressService, IStaticDataService staticDataService*/)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }
        public void Enter(string sceneName)
        {
            Debug.Log("Enter LoadLevelState");
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            Debug.Log("Exit LoadLevelState");
        }
        
        private void OnLoaded()
        {
            _stateMachine.Enter<GameLoopState>();
        }
    }
}