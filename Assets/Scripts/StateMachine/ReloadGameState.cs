
using UnityEngine;

public class ReloadGameState : IGameState
{
    private StateMachine _stateMachine;
    private Field _field;
    private PlayerSessionData _playerSessionData;
    public StateMachine StateMachine { get { return _stateMachine; } private set { } }
    public ReloadGameState(StateMachine stateMachine, Field field, PlayerSessionData playerSessionData)
    {
        _stateMachine = stateMachine;
        _field = field;
        _playerSessionData = playerSessionData;
    }

    public void Enter()
    {
        ReloadField();
        _stateMachine.TransitionToState(typeof(PlayGameState));
    }

    public void Exit()
    {
        
    }

    private void ReloadField()
    {
        for (byte i = 0; i < _field.RowCount; i++)
        {
            for (byte j = 0; j < _field.ColumnCount; j++)
            {
                GameObject.Destroy(_field.Tiles[j, i].FieldElement);
                if (_field.Tiles[j, i].TileType == TilesState.closed)
                {
                    _field.Tiles[j, i].OpenTile();
                }
                _field.FieldObjectGenerator.CreateOneObject(_field.Tiles[j, i]);
                _playerSessionData.RefreshData();
            }
        }
    }
}
