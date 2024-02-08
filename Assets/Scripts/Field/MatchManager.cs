using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UIElements;

public class MatchManager
{
    private Field _parentField;
    private List<Tile> _match;
    private GameObject _lineChain;
    private List<Tile> _emptyTiles;
    private PlayerSessionData _playerSessionData;

    public MatchManager(Field field, GameObject lineChain, PlayerSessionData playerSessionData)
    {
        _parentField = field;
        _match = new List<Tile>();
        _lineChain = lineChain;
        _lineChain.GetComponent<LineRenderer>().useWorldSpace = true;
        _emptyTiles = new List<Tile>();
        _playerSessionData = playerSessionData;
    }

    public void GenerateMatchPerformed()
    {
        if (_playerSessionData.AquaScore > 0)
        {
            Tuple<Vector2, Vector2, Tuple<float, float>> fieldCoordinates = _parentField.DetectFieldCoordinatesOnTheScreen();
            Vector3 currentMousePosition = Camera.main.ScreenToViewportPoint(Mouse.current.position.value);
            if (IsCursorOnTheField())
            {
                FieldPosition tilePosition = determinateTileCoordinates();
                Vector3 elementInTile = Camera.main.WorldToViewportPoint(_parentField.Tiles[tilePosition.Column, tilePosition.Row].TileObject.transform.position);
                if (_match.Count == 0 && 
                    isCursorNearCenterOfTile() && 
                    _parentField.Tiles[tilePosition.Column, tilePosition.Row].ElementOfField.ElementType == TypesOfFieldElements.Enemy)
                {
                    Enemy enemy = _parentField.Tiles[tilePosition.Column, tilePosition.Row].ElementOfField as Enemy;
                    if (enemy.EnemyType == EnemyType.worm && _playerSessionData.BaitsScore > 0)
                    {
                        _parentField.Tiles[tilePosition.Column, tilePosition.Row].SelectTile();
                        _match.Add(_parentField.Tiles[tilePosition.Column, tilePosition.Row]);
                    }
                }
                else if (_match.Count == 0 && 
                    isCursorNearCenterOfTile() && 
                    _parentField.Tiles[tilePosition.Column, tilePosition.Row].ElementOfField.GetType() == typeof(Token))
                {
                    _parentField.Tiles[tilePosition.Column, tilePosition.Row].SelectTile();
                    _match.Add(_parentField.Tiles[tilePosition.Column, tilePosition.Row]);
                    _lineChain.transform.position = _match[0].TileObject.transform.position;
                    _lineChain.GetComponent<LineRenderer>().positionCount = 1;
                    _lineChain.GetComponent<LineRenderer>().SetPosition(0, _match[0].TileObject.transform.position);
                    _lineChain.GetComponent<LineRenderer>().startWidth = 2.0f;
                    _lineChain.GetComponent<LineRenderer>().endWidth = 2.0f;
                }
                else if (_match.Count > 0 && isCursorNearCenterOfTile() && !_parentField.Tiles[tilePosition.Column, tilePosition.Row].IsSelected
                    && _parentField.Tiles[tilePosition.Column, tilePosition.Row].ElementOfField.GetType() != typeof(Enemy)
                    && MathF.Abs(_match[^1].FieldPosition.Column - tilePosition.Column) < 2 && MathF.Abs(_match[^1].FieldPosition.Row - tilePosition.Row) < 2
                    && _match[0].ElementOfField.ElementType != TypesOfFieldElements.Enemy)
                {
                    _parentField.Tiles[tilePosition.Column, tilePosition.Row].SelectTile();
                    _match.Add(_parentField.Tiles[tilePosition.Column, tilePosition.Row]);
                    _lineChain.GetComponent<LineRenderer>().positionCount++;
                    _lineChain.GetComponent<LineRenderer>().SetPosition(_match.Count - 1, _match[^1].TileObject.transform.position);
                }
                else if (_match.Count >= 2 && _parentField.Tiles[tilePosition.Column, tilePosition.Row] == _match[^2])
                {
                    _lineChain.GetComponent<LineRenderer>().positionCount--;
                    _match[^1].UnselectTile();
                    _match.RemoveAt(_match.Count - 1);
                }

                bool isCursorNearCenterOfTile()
                {
                    float tileRadius = 0.3f;
                    if (Mathf.Abs(currentMousePosition.x - elementInTile.x) < tileRadius * fieldCoordinates.Item3.Item1 &&
                    Mathf.Abs(currentMousePosition.y - elementInTile.y) < tileRadius * fieldCoordinates.Item3.Item2)
                    {
                        return true;
                    }
                    else { return false; }
                }
            }

            bool IsCursorOnTheField()
            {
                if (currentMousePosition.x > fieldCoordinates.Item1.x && currentMousePosition.x < fieldCoordinates.Item2.x &&
                currentMousePosition.y > fieldCoordinates.Item1.y && currentMousePosition.y < fieldCoordinates.Item2.y)
                {
                    return true;
                }
                else { return false; }
            }

            FieldPosition determinateTileCoordinates()
            {
                byte XIndex = (byte)((currentMousePosition.x - fieldCoordinates.Item1.x) / fieldCoordinates.Item3.Item1);
                byte YIndex = (byte)((currentMousePosition.y - fieldCoordinates.Item1.y) / fieldCoordinates.Item3.Item2);
                return new FieldPosition(YIndex, XIndex);
            }
        } 
    }

    public void GenerateMatchCanceled(CallbackContext mousePosition)
    {
        if (_match.Count == 1 && _match[0].ElementOfField.ElementType == TypesOfFieldElements.Enemy)
        {
            _playerSessionData.RecountAqua(-1);
            _playerSessionData.RecountBaits(-1);
            _match[0].ClearTile();
            _parentField.FieldObjectGenerator.CreateOneObject(_match[0]);
            _match.RemoveAt(0);
        }
        else 
        {
            MakeMatch();
            CountEmptyTiles();
            _parentField.FieldObjectGenerator.CreateSomeObjects(_emptyTiles);
            _emptyTiles.Clear();
        }
    }

    private void MakeMatch()
    {
        if (_match.Count > 2)
        {
            byte count = (byte)_match.Count;
            for (byte i = 0; i < count; i++)
            {
                if (_match[0].ElementOfField.ElementType == TypesOfFieldElements.Bonus)
                {
                    Bonus bonus = _match[0].ElementOfField as Bonus;
                    switch (bonus.BonusType)
                    {
                        case BonusType.water:
                            _playerSessionData.RecountAqua(2);
                            break;
                        case BonusType.bait:
                            _playerSessionData.RecountBaits(1);
                            break;
                        default:
                            break;
                    }
                }
                else if (_match[0].ElementOfField.ElementType == TypesOfFieldElements.Token)
                {
                    DeterminateEnemyNeighborth(_match[0]);
                    Token token = _match[0].ElementOfField as Token;
                    switch (token.TokenType)
                    {
                        case TokenType.sand:
                            _playerSessionData.RecountScore(2);
                            break;
                        case TokenType.spice:
                            _playerSessionData.RecountScore(17);
                            break;
                        default:
                            break;
                    }
                }
                _match[0].ClearTile();
                _match.RemoveAt(0);
                _lineChain.GetComponent<LineRenderer>().positionCount = 0;
            }

            _playerSessionData.RecountAqua(-1);
        }
        else
        {
            byte count = (byte)_match.Count;
            for (byte i = 0; i < count; i++)
            {
                _match[0].UnselectTile();
                _match.RemoveAt(0);
            }
            _lineChain.GetComponent<LineRenderer>().positionCount = 0;
        }
    }

    private void CountEmptyTiles()
    {
        foreach (var tile in _parentField.Tiles)
        {
            if (tile.IsEmpty)
            {
                _emptyTiles.Add(tile);
            }
        }
    }

    private void DeterminateEnemyNeighborth(Tile tile)
    {
        byte xMinIndex;
        byte xMaxIndex;
        byte yMinIndex;
        byte yMaxIndex;

        if (tile.FieldPosition.Column == 0)
        {
            xMinIndex = 0;
            xMaxIndex = 1;
        }
        else if(tile.FieldPosition.Column == (byte)(_parentField.ColumnCount - 1))
        {
            xMinIndex = (byte)(_parentField.ColumnCount - 2);
            xMaxIndex = (byte)(_parentField.ColumnCount - 1);
        }
        else
        {
            xMinIndex = (byte)(tile.FieldPosition.Column - 1);
            xMaxIndex = (byte)(tile.FieldPosition.Column + 1);
        }

        if (tile.FieldPosition.Row == 0)
        {
            yMinIndex = 0;
            yMaxIndex = 1;
        }
        else if (tile.FieldPosition.Row == (byte)(_parentField.ColumnCount - 1))
        {
            yMinIndex = (byte)(_parentField.RowCount - 2);
            yMaxIndex = (byte)(_parentField.RowCount - 1);
        }
        else
        {
            yMinIndex = (byte)(tile.FieldPosition.Row - 1);
            yMaxIndex = (byte)(tile.FieldPosition.Row + 1);
        }

        for (int x = xMinIndex; x <= xMaxIndex; x++)
        {
            
            for (int y = yMinIndex; y <= yMaxIndex; y++)
            {
                Debug.Log($"{x}_{y}");
                if (x == tile.FieldPosition.Column && y == tile.FieldPosition.Column)
                {
                    continue;
                }
                else if (_parentField.Tiles[x, y].TileType == TilesState.closed)
                {
                    _parentField.Tiles[x, y].ClearTile();
                    Debug.Log("Tile is open.");
                    continue;
                }
                else if (_parentField.Tiles[x, y].ElementOfField.ElementType == TypesOfFieldElements.Enemy) 
                {
                    Enemy enemy = _parentField.Tiles[x, y].ElementOfField as Enemy;
                    if (enemy.GiveDamage() == 0)
                    {
                        _parentField.Tiles[x, y].ClearTile();
                        Debug.Log("Tile is empty.");
                    } 
                }
            }
        }
    }
}