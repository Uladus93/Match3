using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private int _columnCount;
    private int _rowCount;
    public int ColumnCount { get { return _columnCount; } private set { } }
    public int RowCount { get { return _rowCount; } private set { } }
}