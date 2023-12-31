using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor.SearchService;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using System.Net;
using System.Threading.Tasks;


public class InitializationState : IGameState
{
    private StateMachine _stateMachine;
    private static AsyncOperationHandle<SceneInstance> _sceneLoadOpHandle;

    public StateMachine StateMachine { get { return _stateMachine; } private set { } }
    public InitializationState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
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
        _sceneLoadOpHandle = Addressables.LoadSceneAsync("LoadingScene", activateOnLoad: true);
        _sceneLoadOpHandle.Completed += OnCanvasLoadComplete;
    }

    private void OnCanvasLoadComplete(AsyncOperationHandle<SceneInstance> asyncOperationHandle)
    {
        _stateMachine.TransitionToState(typeof(MenuState));
    }
}