using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.Architecture.GameStates
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public LoadProgressState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        public void Enter()
        {
            Debug.Log("Enter LoadProgressState");
            _gameStateMachine.Enter<LoadLevelState, string>("Base");
        }

        public void Exit()
        {
            Debug.Log("Exit LoadProgressState");
        }
    }
}