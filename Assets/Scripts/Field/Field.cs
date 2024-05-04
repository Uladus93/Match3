using System;
using UnityEngine;
/// <summary>
/// It is copy of GameField whith determines count of columns and rows.
/// </summary>
/// <param name="column"></param>
/// <param name="row"></param>
public class Field
{
    private const byte _columnCount = 7;
    private const byte _rowCount = 7;
    private GameObject _fieldObject;
    private Tile[,] _tiles;
    private FieldObjectGenerator _fieldObjectGenerator;
    private MatchManager _matchManager;
    
    public FieldObjectGenerator FieldObjectGenerator { get { return _fieldObjectGenerator; } private set { } }
    public MatchManager MatchManager { get { return _matchManager; } private set { } }
    public byte ColumnCount { get { return _columnCount; } private set { } }
    public byte RowCount { get { return _rowCount; } private set { } }
    public Tile[,] Tiles { get { return _tiles; } private set { } }

    public Field(TileFactory tileFactory, ElementOfFieldFactory elementOfFieldFactory, GameObject lineChain, GameObject field, PlayerSessionData playerSessionData)
    {
        _fieldObjectGenerator = new FieldObjectGenerator(this, tileFactory, elementOfFieldFactory);
        _tiles = new Tile[_columnCount, _rowCount];
        //_tiles = _fieldObjectGenerator.CreateAllNewField(_tiles);
        _matchManager = new MatchManager(this, lineChain, playerSessionData);
        _fieldObject = field;
    }

    /// <summary>
    /// 1) Item1: Min position of tile in the Field.
    /// 2) Item2: Max position of tile in the Field.
    /// 3) Item3: Tuple lenghts without Tiles [x, y].
    /// </summary>
    /// <returns></returns>
    public Tuple<Vector2, Vector2, Tuple<float, float>> DetectFieldCoordinatesOnTheScreen()
    {
        Vector3 firstTilePosition = _tiles[0, 0].TileObject.transform.position;
        float secondX = (_tiles[1, 0].TileObject.transform.position).x;
        float secondY = (_tiles[0, 1].TileObject.transform.position).y;
        float lenghtBeetweenTilesForXAxis = secondX - firstTilePosition.x;
        float lenghtBeetweenTilesForYAxis = secondY - firstTilePosition.y;
        float minX = firstTilePosition.x - lenghtBeetweenTilesForXAxis / 2;
        float minY = firstTilePosition.y - lenghtBeetweenTilesForYAxis / 2;
        float maxX = minX + lenghtBeetweenTilesForXAxis * _columnCount;
        float maxY = minY + lenghtBeetweenTilesForYAxis * _rowCount;
        Vector2 pointOfMinTile = new(minX, minY);
        Vector2 pointOfMaxTile = new(maxX, maxY);
        Tuple<float, float> lengthsWithoutTiles = Tuple.Create(lenghtBeetweenTilesForXAxis, lenghtBeetweenTilesForYAxis);
        return Tuple.Create(pointOfMinTile, pointOfMaxTile, lengthsWithoutTiles);
    }

    public void LoadFieldFromJSON(string[] jsonTiles)
    {
        _tiles = _fieldObjectGenerator.LoadAllFieldFromJSON(_tiles, jsonTiles);
        PlayerScore.CheckPurchase();
    }
}