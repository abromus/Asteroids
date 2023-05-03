using System;
using System.Collections.Generic;

namespace Asteroids.Core.Services
{
    public sealed class StateMachine : IStateMachine
    {
        private IExitState _currentState;

        private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();

        public void Enter<TState>() where TState : class, IEnterState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void Add<TState>(TState state) where TState : class, IState
        {
            var type = typeof(TState);

            if (_states.ContainsKey(type))
                _states[type] = state;
            else
                _states.Add(type, state);
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
