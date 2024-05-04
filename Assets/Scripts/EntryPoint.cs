using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _tile;
    [SerializeField] private GameObject _sand;
    [SerializeField] private GameObject _spice;
    [SerializeField] private GameObject _worm;
    [SerializeField] private GameObject _solders;
    [SerializeField] private GameObject _water;
    [SerializeField] private GameObject _bait;
    [SerializeField] private GameObject _rocket;
    [SerializeField] private GameObject _line;
    [SerializeField] private Sprite _enemy1;
    [SerializeField] private Sprite _enemy2;
    [SerializeField] private GameObject _particles;
    [SerializeField] private GameObject _gameArea;
    [SerializeField] private Button _startButton;
    private bool _sceneIsLoaded;

    private ElementOfFieldFactory _elementOfFieldFactory;
    private StateMachine _stateMachine;


    public StateMachine StateMachine { get { return _stateMachine; } private set { } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _elementOfFieldFactory = new ElementOfFieldFactory(_sand, _spice, _worm, _solders, _water, _bait, _rocket, _enemy1, _enemy2);
        _stateMachine = new StateMachine();
        _stateMachine.AddState(this, new InitializationState(_stateMachine, _elementOfFieldFactory, _tile, _line, _particles, _gameArea));
        _startButton.onClick.AddListener(() => StartCoroutine(LoadGameScene()));
        _sceneIsLoaded = false;
    }


    private IEnumerator LoadGameScene()
    {
        if (_sceneIsLoaded == false)
        {
            _sceneIsLoaded = true;
            SceneManager.LoadScene(1);

            while (!SceneManager.GetSceneByBuildIndex(1).isLoaded)
            {
                yield return new WaitForEndOfFrame();
            }

            _stateMachine.TransitionToState(typeof(InitializationState));
        }
    }
}