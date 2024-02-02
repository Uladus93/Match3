using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;


public class InitializationState : IGameState
{
    private StateMachine _stateMachine;
    private  AsyncOperationHandle<SceneInstance> _sceneLoadOpHandle;

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
        Addressables.Release(_sceneLoadOpHandle);
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