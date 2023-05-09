using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.States
{
  public class GameStateMachine
  {
    private Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
    private IState _activeState;

    public void AddState(Type type, IState state) => 
      _states.Add(type, state);

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

    private TState ChangeState<TState>() where TState : class, IState
    {
      _activeState?.Exit();
      
      TState state = GetState<TState>();
      _activeState = state;
      
      return state;
    }

    private TState GetState<TState>() where TState : class, IState => 
      _states[typeof(TState)] as TState;
  }
}