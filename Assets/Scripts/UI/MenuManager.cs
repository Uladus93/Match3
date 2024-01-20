using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

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