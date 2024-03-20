using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class InitializationState : IGameState
{
    private StateMachine _stateMachine;
    private GameObject _fieldObject;
    private ElementOfFieldFactory _elementOfFieldFactory;
    private GameObject _tile;
    private GameObject _line;
    private GameObject _particles;
    private TileFactory _tileFactory;
    private GameObject _tilesLine;
    private GameObject _water;
    private GameObject _score;
    private GameObject _rockets;
    private GameObject _baits;
    private GameObject _shop;
    private GameObject _settingsWindow;


    public StateMachine StateMachine { get { return _stateMachine; } private set { } }
    public InitializationState(StateMachine stateMachine, ElementOfFieldFactory elementOfFieldFactory, GameObject tile, GameObject line, GameObject particles)
    {
        _stateMachine = stateMachine;
        _elementOfFieldFactory = elementOfFieldFactory;
        _tile = tile;
        _line = line;
        _particles = particles;
    }

    public void Enter()
    {
        _fieldObject = GameObject.Find("Field Image");
        GameObject playerData = GameObject.Find("PlayerData");
        int playerDataChildCount = playerData.transform.childCount;
        for (int i = 0; i < playerDataChildCount; i++)
        {
            GameObject childObject = playerData.transform.GetChild(i).gameObject;
            if (childObject.name == "WaterCount")
            {
                _water = childObject.transform.GetChild(0).gameObject;
                continue;
            }
            else if (childObject.name == "SpiceCount")
            {
                _score = childObject.transform.GetChild(0).gameObject;
                continue;
            }
            else if (childObject.name == "RocketCount")
            {
                _rockets = childObject.transform.GetChild(0).gameObject;
                continue;
            }
            else if (childObject.name == "BaitCount")
            {
                _baits = childObject.transform.GetChild(0).gameObject;
                continue;
            }
        }

        GameObject _soundManager = GameObject.Find("SoundManager");
        GameObject interpretator = GameObject.Find("Interpretator");
        
        
        GameObject settingsCanvas = GameObject.Find("Settings Canvas");
        int settingsDataChildCount = settingsCanvas.transform.childCount;
        for (int i = 0; i < settingsDataChildCount; i++)
        {
            GameObject childObject = settingsCanvas.transform.GetChild(i).gameObject;
            if (childObject.name == "Shop")
            {
                _shop = childObject.gameObject;
                continue;
            }
            else if (childObject.name == "Settings Button")
            {
                _settingsWindow = childObject.transform.GetChild(0).gameObject;
                continue;
            }
        }

        _particles = GameObject.Instantiate(_particles, new Vector3(0, 0, 0), Quaternion.identity, _fieldObject.transform);
        _tileFactory = new TileFactory(_tile, _fieldObject, _particles.GetComponent<Particles>(), _soundManager.GetComponent<SoundManager>());
        _tilesLine = GameObject.Instantiate(_line, new Vector3(0, 0, 0), Quaternion.identity, _fieldObject.transform);
        PlayerSessionData playerSessionData = new PlayerSessionData(_water, _score, _baits, _rockets);
        playerSessionData.RefreshData();
        Field gameField = new Field(_tileFactory, _elementOfFieldFactory, _tilesLine, _fieldObject, playerSessionData);
        interpretator.GetComponent<GameInterpretator>().SetField(gameField);
        _shop.AddComponent<Market>();
        _shop.GetComponent<Market>().SetMarketData(interpretator.GetComponent<GameInterpretator>(), playerSessionData);
        _stateMachine.AddState(this, new PlayGameState(_stateMachine, gameField, playerSessionData));
        _stateMachine.AddState(this, new ReloadGameState(_stateMachine, gameField, playerSessionData));

        int windowDataChildCount = _settingsWindow.transform.childCount;
        for (int i = 0; i < windowDataChildCount; i++)
        {
            GameObject childObject = _settingsWindow.transform.GetChild(i).gameObject;
            if (childObject.name == "Restart Button")
            {
                childObject.GetComponent<Button>().onClick.AddListener(() => _stateMachine.TransitionToState(typeof(ReloadGameState)));
            }
        }
        _stateMachine.TransitionToState(typeof(PlayGameState));
    }

    public void Exit()
    {
        
    }
}