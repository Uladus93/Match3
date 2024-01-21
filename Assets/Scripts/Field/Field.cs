
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

    private TileFactory _tilefactory;
    private ElementOfFieldFactory _elementfactory;
    
    
    public Field(TileFactory tileFactory, ElementOfFieldFactory elementOfFieldFactory)
    {
        _tiles = new Tile[_columnCount, _rowCount];
        _tilefactory = tileFactory;
        _elementfactory = elementOfFieldFactory;
    }

    public void GenerateField()
    {
        for (int i = 0; i < _rowCount; i++)
        {
            for (int j = 0; j < _columnCount; j++)
            {
                _tiles[j, i] = _tilefactory.CreateTile(-40 + j * 12, -40 + i * 12);
                _elementfactory.CreateElement(this, _tiles[j, i]);
            }
        }
    }
}