using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private StateMachine _stateMachine;
    public StateMachine StateMachine { get { return _stateMachine; } private set { } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _stateMachine = new StateMachine();
        _stateMachine.AddState(GetType(), new InitializationState(_stateMachine));
        _stateMachine.AddState(GetType(), new MenuState(_stateMachine));
        _stateMachine.AddState(GetType(), new PlayGameState(_stateMachine));
        _stateMachine.AddState(GetType(), new PauseState(_stateMachine));
        _stateMachine.TransitionToState(typeof(InitializationState));
    }
}