using Assets.CodeBase.Architecture.GameStates;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Architecture
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [Inject]
        private Game _game;

        private void Awake()
        {
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}