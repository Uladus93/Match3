
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
    public int ColumnCount { get { return _columnCount; } private set { } }
    public int RowCount { get { return _rowCount; } private set { } }

    private Tile[,] _tiles;

    private GameObject _canvas;

    private TileFactory _factory;
    
    public Field(TileFactory tileFactory)
    {
        _tiles = new Tile[_columnCount, _rowCount];
        _factory = tileFactory;
    }

    public void GenerateField()
    {
        for (int i = 0; i < _rowCount; i++)
        {
            for (int j = 0; j < _columnCount; j++)
            {
                _tiles[j, i] = _factory.CreateTile(-130 + j * 40, -130 + i * 40);
            }
        }
    }
}