using Assets.Scripts.FSM.States;
using System;
using System.Collections.Generic;

public class LevelStateMachine
{
    private Dictionary<Type, ILevelState> _states;
    private ILevelState _currentState;

    public LevelStateMachine()
    {
        _states = new Dictionary<Type, ILevelState>()
        {
            [typeof(LoadingLevelState)] = new LoadingLevelState(this),
            [typeof(InitializeLevelState)] = new InitializeLevelState(this)
        };
    }

    public void EnterIn<TState>() where TState : ILevelState
    {
        if (_states.TryGetValue(typeof(TState), out ILevelState state))
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }

    public void AddState(ILevelState state)
    {
        Type type = state.GetType();
        if(_states.TryGetValue(type) == false)
        {
            _states.Add(type, state);
        }
    }
}
