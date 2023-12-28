
public interface IGameState
{
    public StateMachine StateMachine { get;}
    public void Enter();
    public void Exit();
}
