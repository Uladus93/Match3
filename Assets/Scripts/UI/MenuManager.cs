using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _topListButton;
    [SerializeField] private Button _settingsButton;

    [SerializeField] private GameObject _topListWindow;
    [SerializeField] private GameObject _settingsWindow;

    private StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = GameObject.FindObjectOfType<EntryPoint>().StateMachine;
    }

    private void Start()
    {
        _playButton.onClick.AddListener(() => _stateMachine.TransitionToState(typeof(PlayGameState)));
        _settingsButton.onClick.AddListener(() => OpenCloseGameObject(_settingsWindow));
        _topListButton.onClick.AddListener(() => OpenCloseGameObject(_topListWindow));
    }

    public void OpenCloseGameObject(GameObject menuObject)
    {
        if (menuObject.activeSelf)
        {
            menuObject.SetActive(false);
        }
        else
        {
            menuObject.SetActive(true);
        }
    }
}