using UnityEngine;

public class FieldPosition
{
    private int _row;
    private int _column;

    public int Row { get { return _row; } private set { } }
    public int Column { get { return _column; } private set { } }

    public void SetPosition(Field field, int row, int column)
    {
        if (row >= 0 && row < field.RowCount)
        {
            _row = row;
        }

        if (column >= 0 && column < field.ColumnCount)
        {
            _column = column;
        }
    }
}