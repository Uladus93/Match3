public class PauseState : IGameState
{
    private StateMachine _stateMachine;
    public StateMachine StateMachine { get; }
    public PauseState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
