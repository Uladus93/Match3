using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _topListButton;
    [SerializeField] private Button _settingsButton;

    [SerializeField] private GameObject _levelSelectionWindow;
    [SerializeField] private GameObject _topListWindow;
    [SerializeField] private GameObject _settingsWindow;

    private void Start()
    {
        _playButton.onClick.AddListener(() => OpenCloseGameObject(_levelSelectionWindow));
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