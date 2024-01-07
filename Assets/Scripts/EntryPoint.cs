using UnityEngine;
using UnityEngine.UI;

public class EntryPoint : MonoBehaviour
{
    private StateMachine _stateMachine;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _stateMachine = new StateMachine();
        _stateMachine.AddState(GetType(), new InitializationState( _stateMachine));
        _stateMachine.AddState(GetType(), new MenuState(_stateMachine));
        _stateMachine.AddState(GetType(), new LoadLevelState(_stateMachine));
        _stateMachine.AddState(GetType(), new PauseState(_stateMachine));
        _stateMachine.TransitionToState(typeof(InitializationState));
    }
}