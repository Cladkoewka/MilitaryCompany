using Assets.CodeBase.Architecture.GameStates;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Architecture
{
    public class Game
    {
        public GameStateMachine StateMachine { get; private set; }

        [Inject]
        public Game(ICoroutineRunner coroutineRunner, SceneLoader sceneLoader)
        {
            StateMachine = new GameStateMachine(sceneLoader);
        }
    }
}