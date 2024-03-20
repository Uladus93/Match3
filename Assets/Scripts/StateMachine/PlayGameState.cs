using Unity.VisualScripting;
using UnityEngine;

public class PlayGameState : IGameState
{
    private StateMachine _stateMachine;
    private const string _sceneName = "GamePlayScene";
    private Field _field;
    private PlayerSessionData _playerSessionData;

    public StateMachine StateMachine { get { return _stateMachine; } private set { } }

    public PlayGameState(StateMachine stateMachine, Field field, PlayerSessionData playerSessionData)
    {
        _stateMachine = stateMachine;
        _field = field;
        _playerSessionData = playerSessionData;
    }
    public void Enter()
    {

    }

    public void Exit()
    {
        //SaveGameData
    }
}