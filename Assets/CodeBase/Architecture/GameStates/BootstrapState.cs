using System;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Architecture.GameStates
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            Debug.Log("Enter Bootstrap state");
            Debug.Log(_sceneLoader);
            Debug.Log(_stateMachine);
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
            Debug.Log("Exit Bootstrap state");
        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadProgressState>();
    }
}