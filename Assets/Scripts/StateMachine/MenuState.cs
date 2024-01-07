using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class MenuState : IGameState
{
    StateMachine _stateMachine;
    private const string _sceneName = "MenuScene";
    public StateMachine StateMachine { get; }
    public MenuState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public void Enter()
    {
        var menuSceneOperation = Addressables.LoadSceneAsync(_sceneName, activateOnLoad: true);

        if (SceneManager.GetActiveScene().name == "LoadingScene" && SceneManager.GetActiveScene().isLoaded)
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            while (menuSceneOperation.PercentComplete <= 0.9f)
            {
                Debug.Log(SceneManager.GetActiveScene().name);
                LoadingStateText.SetLoadingText(this, _sceneName);
                LoadingProgressImage.SetFillOfImage(this, menuSceneOperation.PercentComplete);
            }
        }
        
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
