using Unity.Loading;
using UnityEngine;
using UnityEngine.Events;
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
    private GameObject _settingsButton;
    private GameObject _gameArea;


    public StateMachine StateMachine { get { return _stateMachine; } private set { } }
    public InitializationState(StateMachine stateMachine, ElementOfFieldFactory elementOfFieldFactory, GameObject tile, GameObject line, GameObject particles, GameObject gameArea)
    {
        _stateMachine = stateMachine;
        _elementOfFieldFactory = elementOfFieldFactory;
        _tile = tile;
        _line = line;
        _particles = particles;
        _gameArea = gameArea;
    }

    public void Enter()
    {
        GameObject canvas = GameObject.Find("Canvas");
        _gameArea = GameObject.Instantiate(_gameArea, new Vector3(0, 0, 0), Quaternion.identity, canvas.transform);
        _gameArea.GetComponent<RectTransform>().localPosition = Vector3.zero;
        GameAreaLinks gameAreaLinker = _gameArea.GetComponent<GameAreaLinks>(); 
        _fieldObject = gameAreaLinker.GameField;
        GameObject playerData = gameAreaLinker.GameScore;
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

        gameAreaLinker.CanvasUI.GetComponent<Canvas>().sortingLayerID = SortingLayer.NameToID("UI");
        GameObject _soundManager = gameAreaLinker.SoundUI;
        GameObject interpretator = GameObject.Find("Interpretator");
        _shop = gameAreaLinker.MarketButton;
        _settingsButton = gameAreaLinker.SettingsButton;
        _settingsButton.GetComponent<ButtonOfMenu>().SetInterpretator(interpretator.GetComponent<GameInterpretator>());
        _soundManager.GetComponent<SoundManager>().SetSoundToggle(gameAreaLinker.SoundToggle);
        _particles = GameObject.Instantiate(_particles, new Vector3(0, 0, 0), Quaternion.identity, _fieldObject.transform);
        _tileFactory = new TileFactory(_tile, _fieldObject, _particles.GetComponent<Particles>(), _soundManager.GetComponent<SoundManager>());
        _tilesLine = GameObject.Instantiate(_line, new Vector3(0, 0, 0), Quaternion.identity, _fieldObject.transform);
        GameObject PlayerScoreJSONData = GameObject.Find("PlayerScore");
        PlayerSessionData playerSessionData = new PlayerSessionData(_water, _score, _baits, _rockets, PlayerScoreJSONData.GetComponent<PlayerScore>());
        Field gameField = new Field(_tileFactory, _elementOfFieldFactory, _tilesLine, _fieldObject, playerSessionData);
        PlayerScoreJSONData.GetComponent<PlayerScore>().SetDataForJSON(gameField, playerSessionData);
#if UNITY_WEBGL
        PlayerScoreJSONData.GetComponent<PlayerScore>().LoadGame();
#endif
        //playerSessionData.RefreshData();
        //gameField.FieldObjectGenerator.CreateAllNewField(gameField.Tiles);
        interpretator.GetComponent<GameInterpretator>().SetField(gameField);
        _shop.GetComponent<Market>().SetMarketData(interpretator.GetComponent<GameInterpretator>(), playerSessionData);
        _stateMachine.AddState(this, new PlayGameState(_stateMachine, gameField, playerSessionData));
        _stateMachine.AddState(this, new ReloadGameState(_stateMachine, gameField, playerSessionData));

        int windowDataChildCount = _settingsButton.transform.GetChild(0).transform.childCount;
        for (int i = 0; i < windowDataChildCount; i++)
        {
            GameObject childObject = _settingsButton.transform.GetChild(0).transform.GetChild(i).gameObject;
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