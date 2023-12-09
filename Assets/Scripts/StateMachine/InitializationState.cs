using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using System.Linq;

public class InitializationState : IGameState
{
    private GameObject _background;
    private GameObject _tilePrefab;
    private Tile _tile;
    private Tile _tile2;
    private Transform _transform;
    private GameObject _loadingCanvas;
    private SceneLoader _sceneLoader;

    private Scene _scene;
    public InitializationState(GameObject background, GameObject tilePrefab, GameObject loadingCanvas)
    {
        _background = background;
        _tilePrefab = tilePrefab;
        _loadingCanvas = loadingCanvas;
    }

    public void Enter()
    {
        ViewLoadingScene();
        InitializeBackground();
        InitializeTiles();
        InitializeCanvas();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void ViewLoadingScene()
    {
        _sceneLoader = new SceneLoader();
        _sceneLoader.LoadSceneAsync(this, _loadingCanvas);
        _sceneLoader.SetProgressBarValue(this, 0.1f);
        _sceneLoader.SetStateText(this, "Initialize scenes.");
    }

    private void InitializeBackground()
    {
        
    }

    private void InitializeTiles()
    {
        
    }

    private void InitializeCanvas()
    {
        
    }

    
}