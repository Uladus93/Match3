using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Material _backgroundMaterial;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _canvas;
    private StateMachine _stateMachine;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _stateMachine = new StateMachine();
        _stateMachine.AddState(new InitializationState());
        //add other states here.
        _stateMachine.TransitionToState(typeof(InitializationState));
    }
}