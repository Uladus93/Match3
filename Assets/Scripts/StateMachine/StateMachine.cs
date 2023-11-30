using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private Dictionary<System.Type, IGameState> _states;
    private IGameState _currentState;

    public StateMachine()
    {
        _states = new Dictionary<Type, IGameState>();
    }

    public Dictionary<System.Type, IGameState> States { get { return _states; } private set { } }

    public void AddState(IGameState state)
    {
        if(!_states.ContainsKey(state.GetType()))
        {
            _states.Add(state.GetType(), state);
        }
    }

    public void TransitionToState(System.Type stateType)
    {
        if (!_states.ContainsKey(stateType))
        {
            Debug.LogError($"State of type {stateType.Name} is not registered.");
            return;
        }

        _currentState?.Exit();
        _currentState = _states[stateType];
        _currentState?.Enter();
    }
}