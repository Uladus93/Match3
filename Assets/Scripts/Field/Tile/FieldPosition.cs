public struct FieldPosition
{
    private byte _row;
    private byte _column;

    public byte Row { get { return _row; } private set { } }
    public byte Column { get { return _column; } private set { } }

    public FieldPosition(byte row, byte column)
    {
        _row = row;
        _column = column;
    }
}