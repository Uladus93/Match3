
using UnityEngine;
/// <summary>
/// It is copy of GameField whith determines count of columns and rows.
/// </summary>
/// <param name="column"></param>
/// <param name="row"></param>
public class Field
{
    private byte _columnCount;
    private byte _rowCount;
    public int ColumnCount { get { return _columnCount; } private set { } }
    public int RowCount { get { return _rowCount; } private set { } }

    private Tile[,] _tiles;

    private GameObject _canvas;

    private TileFactory _factory;
    
    public Field(byte column, byte row, GameObject canvas, TileFactory tileFactory)
    {
        _columnCount = column;
        _rowCount = row;
        _canvas = canvas;
        _factory = tileFactory;
    }

    public void GenerateField()
    {
        for (int i = 0; i < _rowCount; i++)
        {
            for (int j = 0; j < _columnCount; j++)
            {
                _tiles[j, i] = _factory.CreateTile(j, i, _canvas.transform);
            }
        }
    }
}