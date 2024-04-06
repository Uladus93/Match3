using UnityEngine;

public class GameAreaLinks : MonoBehaviour
{
    [SerializeField] private GameObject _gameField;
    [SerializeField] private GameObject _gameScore;
    [SerializeField] private GameObject _marketButton;
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _soundToggle;
    [SerializeField] private GameObject _canvasUI;
    [SerializeField] private GameObject _soundUI;

    public GameObject GameField { get { return _gameField; } private set { } }
    public GameObject GameScore { get { return _gameScore; } private set { } }
    public GameObject MarketButton { get { return _marketButton; } private set { } }
    public GameObject SettingsButton { get { return _settingsButton; } private set { } }
    public GameObject SoundToggle { get { return _soundToggle; } private set { } }
    public GameObject CanvasUI { get { return _canvasUI; } private set { } }
    public GameObject SoundUI { get { return _soundUI; } private set { } }
}
