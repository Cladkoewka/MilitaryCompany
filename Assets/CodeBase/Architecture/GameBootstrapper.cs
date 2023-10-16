using Assets.CodeBase.Architecture.GameStates;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Architecture
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [Inject]
        private GameStateMachine _gameStateMachine;

        private void Awake()
        {
            _gameStateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}