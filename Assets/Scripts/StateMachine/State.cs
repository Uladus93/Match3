using UnityEngine;

public class State : IGameState
{
    StateMachine _stateMachine;
    public StateMachine StateMachine { get; }

    public State(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public void Enter()
    {
        
    }
    public void Exit()
    {
        
    }
}
