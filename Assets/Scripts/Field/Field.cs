
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
    
    public Field(byte column, byte row)
    {
        _columnCount = column;
        _rowCount = row;
    }

    public void FillField()
    {
        _tiles = new Tile[_columnCount, _rowCount];

        for (int i = 0; i < _rowCount; i++)
        {
            for (int j = 0; j < _columnCount; j++)
            {
                _tiles[j, i] = new Tile(TypeOfTile.open, true);
            }
        }
    }
}