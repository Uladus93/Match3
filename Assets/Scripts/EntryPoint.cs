using UnityEngine;
using UnityEngine.UI;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Slider _loadingSlider;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _loadingCanvas;
    private StateMachine _stateMachine;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _stateMachine = new StateMachine();

        _stateMachine.AddState(new InitializationState( _stateMachine, _tilePrefab, _loadingCanvas));
        _stateMachine.AddState(new MenuState(_stateMachine));
        _stateMachine.AddState(new LoadLevelState(_stateMachine));
        _stateMachine.AddState(new PauseState(_stateMachine));
        _stateMachine.TransitionToState(typeof(InitializationState));
    }
}