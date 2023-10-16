using System;
using System.Collections.Generic;
using Assets.CodeBase.Architecture.Factory;
using Assets.CodeBase.Services.PersistentProgress;
using Assets.CodeBase.Services.SaveLoad;
using Assets.CodeBase.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Architecture.GameStates
{
    public class GameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;
        
        [Inject]
        public GameStateMachine(SceneLoader sceneLoader, IGameFactory gameFactory, IPersistentProgressService progressService, IStaticDataService staticDataService, ISaveLoadService saveLoadService)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, gameFactory, progressService, staticDataService),
                [typeof(LoadProgressState)] = new LoadProgressState(this, progressService, saveLoadService),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
      
            TState state = GetState<TState>();
            _activeState = state;
      
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}