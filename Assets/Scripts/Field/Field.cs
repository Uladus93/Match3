
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
/// <summary>
/// It is copy of GameField whith determines count of columns and rows.
/// </summary>
/// <param name="column"></param>
/// <param name="row"></param>
public class Field
{
    private const byte _columnCount = 7;
    private const byte _rowCount = 7;
    public int ColumnCount { get { return _columnCount; } private set { } }
    public int RowCount { get { return _rowCount; } private set { } }

    private GameObject _fieldObject;
    private Tile[,] _tiles;
    private Controller _controller;
    private TileFactory _tilefactory;
    private ElementOfFieldFactory _elementfactory;
    private List<Tile> _match;
    private GameObject _lineChain;
    
    public Field(TileFactory tileFactory, ElementOfFieldFactory elementOfFieldFactory, GameObject lineChain, GameObject field)
    {
        _tiles = new Tile[_columnCount, _rowCount];
        _tilefactory = tileFactory;
        _elementfactory = elementOfFieldFactory;
        _match = new List<Tile>();
        _lineChain = lineChain;
        _fieldObject = field;
        _lineChain.GetComponent<LineRenderer>().useWorldSpace = true;
    }

    public void GenerateField()
    {
        for (byte i = 0; i < _rowCount; i++)
        {
            for (byte j = 0; j < _columnCount; j++)
            {
                _tiles[j, i] = _tilefactory.CreateTile(j, i);
                _elementfactory.CreateElement(this, _tiles[j, i]);
            }
        }
    }

    public void GenerateMatchPerformed()
    {
        Tuple<Vector2, Vector2, Tuple<float, float>> fieldCoordinates = DetectFieldCoordinatesOnTheScreen();
        Vector3 currentMousPosition = Camera.main.ScreenToViewportPoint(Mouse.current.position.value);
        if (IsCursorOnTheField())
        {
            byte XIndex = (byte)((currentMousPosition.x - fieldCoordinates.Item1.x) / fieldCoordinates.Item3.Item1);
            byte YIndex = (byte)((currentMousPosition.y - fieldCoordinates.Item1.y) / fieldCoordinates.Item3.Item2);
            Vector3 selectingTile = Camera.main.WorldToViewportPoint(_tiles[XIndex, YIndex].TileObject.transform.position);
            float tileRadius = 0.3f;
            if (Mathf.Abs(currentMousPosition.x - selectingTile.x) < tileRadius * fieldCoordinates.Item3.Item1 &&
                Mathf.Abs(currentMousPosition.y - selectingTile.y) < tileRadius * fieldCoordinates.Item3.Item2 &&
                !_tiles[XIndex, YIndex].IsSelected)
            {
                _tiles[XIndex, YIndex].SelectTile();
                _match.Add(_tiles[XIndex, YIndex]);
                if (_match.Count == 1)
                {
                    _lineChain.transform.position = _match[0].TileObject.transform.position;
                    _lineChain.GetComponent<LineRenderer>().positionCount = 1;
                    _lineChain.GetComponent<LineRenderer>().SetPosition(0, _match[0].TileObject.transform.position);
                    _lineChain.GetComponent<LineRenderer>().startWidth = 2.0f;
                    _lineChain.GetComponent<LineRenderer>().endWidth = 2.0f;
                }
                else if (_match.Count > 1)
                {
                    _lineChain.GetComponent<LineRenderer>().positionCount++;
                    _lineChain.GetComponent<LineRenderer>().SetPosition(_match.Count - 1, _match[^1].TileObject.transform.position);
                }
            }
            else if (_match.Count >= 2 && _tiles[XIndex, YIndex] == _match[^2])
            {
                _lineChain.GetComponent<LineRenderer>().positionCount--;
                _match[^1].UnselectTile();
                _match.RemoveAt(_match.Count - 1);
            }
        }

        bool IsCursorOnTheField()
        {
            if (currentMousPosition.x > fieldCoordinates.Item1.x && currentMousPosition.x < fieldCoordinates.Item2.x &&
            currentMousPosition.y > fieldCoordinates.Item1.y && currentMousPosition.y < fieldCoordinates.Item2.y)
            {
                return true;
            }
            else { return false; }
        }
    }

    public void GenerateMatchCanceled(CallbackContext mousePosition)
    {
        byte count = (byte)_match.Count;
        for (byte i = 0; i < count; i++)
        {
            GameObject.Destroy(_match[0].FieldElement);
            _match.RemoveAt(0);
            _lineChain.GetComponent<LineRenderer>().positionCount = 0;
        }
    }

    /// <summary>
    /// 1) Item1: Min position of tile in the Field.
    /// 2) Item2: Max position of tile in the Field.
    /// 3) Item3: Tuple lenghts without Tiles [x, y].
    /// </summary>
    /// <returns></returns>
    private Tuple<Vector2, Vector2, Tuple<float, float>> DetectFieldCoordinatesOnTheScreen()
    {
        Vector3 firstTilePosition = Camera.main.WorldToViewportPoint(_tiles[0, 0].TileObject.transform.position);
        float secondX = Camera.main.WorldToViewportPoint(_tiles[1, 0].TileObject.transform.position).x;
        float secondY = Camera.main.WorldToViewportPoint(_tiles[0, 1].TileObject.transform.position).y;
        float lenghtWithoutTilesForXAxis = secondX - firstTilePosition.x;
        float lenghtWithoutTilesForYAxis = secondY - firstTilePosition.y;
        float minX = firstTilePosition.x - lenghtWithoutTilesForXAxis / 2;
        float minY = firstTilePosition.y - lenghtWithoutTilesForYAxis / 2;
        float maxX = minX + lenghtWithoutTilesForXAxis * _columnCount;
        float maxY = minY + lenghtWithoutTilesForYAxis * _rowCount;
        Vector2 pointOfMinTile = new(minX, minY);
        Vector2 pointOfMaxTile = new(maxX, maxY);
        Tuple<float, float> lengthsWithoutTiles = Tuple.Create(lenghtWithoutTilesForXAxis, lenghtWithoutTilesForYAxis);
        return Tuple.Create(pointOfMinTile, pointOfMaxTile, lengthsWithoutTiles);
    }
}