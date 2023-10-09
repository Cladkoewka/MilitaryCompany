using UnityEngine;

namespace Assets.CodeBase.Architecture.GameStates
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public GameLoopState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public void Enter()
        {
            Debug.Log("Enter GameLoopState");
        }

        public void Exit()
        {
            Debug.Log("Exit GameLoopState");
        }
    }
}