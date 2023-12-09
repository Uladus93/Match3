using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        _stateMachine.AddState(new InitializationState( _background, _tilePrefab, _loadingCanvas));
        //add other states here.
        _stateMachine.TransitionToState(typeof(InitializationState));
    }
}