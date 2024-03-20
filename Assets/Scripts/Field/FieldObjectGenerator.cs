using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObjectGenerator
{
    private Field _parentField;
    private TileFactory _tilefactory;
    private ElementOfFieldFactory _elementfactory;
    
    public FieldObjectGenerator(Field field, TileFactory tileFactory, ElementOfFieldFactory elementsFactory)
    {
        _parentField = field;
        _tilefactory = tileFactory;
        _elementfactory = elementsFactory;
    }
    public Tile[,] CreateAllNewField(Tile[,] tiles)
    {
        for (byte i = 0; i < _parentField.RowCount; i++)
        {
            for (byte j = 0; j < _parentField.ColumnCount; j++)
            {
                tiles[j, i] = _tilefactory.CreateTile(j, i);
                _elementfactory.CreateElement(this, tiles[j, i]);
            }
        }

        return tiles;
    }

    public void CreateSomeObjects(List<Tile> emptyTiles)
    {
        int count = emptyTiles.Count;
        for (int i = 0; i < count; i++)
        {
            _elementfactory.CreateElement(this, emptyTiles[0]);
            emptyTiles.RemoveAt(0);
        }
    }

    public void CreateOneObject(Tile emptyTile)
    {
        _elementfactory.CreateElement(this, emptyTile);
    }
}