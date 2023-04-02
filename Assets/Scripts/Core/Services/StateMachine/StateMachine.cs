using System;
using System.Collections.Generic;
using Asteroids.Settings;

namespace Asteroids.Core.Services
{
    public sealed class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IState> _states;

        private IExitState _currentState;

        public StateMachine(IScreenSystem screenSystem, ISceneLoader sceneLoader, ICanvasConfig canvasConfig)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this),
                [typeof(GameState)] = new GameState(this, screenSystem, canvasConfig),
                [typeof(SceneLoaderState)] = new SceneLoaderState(sceneLoader),
                [typeof(GameLoopState)] = new GameLoopState(),
            };
        }

        public void Enter<TState>() where TState : class, IEnterState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IEnterState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitState
        {
            _currentState?.Exit();

            var state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}
