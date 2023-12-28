
public class LoadLevelState : IGameState
{
    private StateMachine _stateMachine;
    public StateMachine StateMachine { get; }
    public LoadLevelState(StateMachine stateMachine)
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
