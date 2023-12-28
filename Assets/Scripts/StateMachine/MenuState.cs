using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuState : IGameState
{
    StateMachine _stateMachine;
    public StateMachine StateMachine { get; }
    public MenuState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public void Enter()
    {
        Scene menuScene = SceneManager.GetSceneByName("MenuScene");
        SceneManager.SetActiveScene(menuScene);
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
