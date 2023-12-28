using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEditor.SearchService;


public class InitializationState : IGameState
{
    private StateMachine _stateMachine;
    private GameObject _tilePrefab;
    private Tile _tile;
    private Tile _tile2;
    private Transform _transform;
    private GameObject _loadingCanvas;

    public StateMachine StateMachine { get { return _stateMachine; } private set { } }
    public InitializationState(StateMachine stateMachine, GameObject tilePrefab, GameObject loadingCanvas)
    {
        _stateMachine = stateMachine;
        _tilePrefab = tilePrefab;
        _loadingCanvas = loadingCanvas;
    }

    public void Enter()
    {
        LoadLoadingScene();
    }

    public void Exit()
    {
        
    }

    private void LoadLoadingScene()
    {
        var loadScene = SceneManager.LoadSceneAsync("LoadingScene");

        loadScene.completed += scene =>
        {
            var loadingSceneManager = GameObject.Instantiate(_loadingCanvas).GetComponent<SceneLoadManager>().GetComponent<SceneLoadManager>();
            loadingSceneManager.SetProgressBarValue(this, 0);
            loadingSceneManager.LoadSceneAsync(this, "MenuScene");
        };
    }
}