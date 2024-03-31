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

    public Tile[,] LoadAllFieldFromJSON(Tile[,] tiles, string[] jsonTiles)
    {
        for (byte i = 0; i < _parentField.RowCount; i++)
        {
            for (byte j = 0; j < _parentField.ColumnCount; j++)
            {
                tiles[j, i] = _tilefactory.CreateTile(j, i);
                decryptJSON();

                void decryptJSON()
                {
                    char[] tileFeatures = jsonTiles[i * _parentField.ColumnCount + j].ToCharArray();
                    if (tileFeatures[0] == 'c')
                    {
                        tiles[j, i].CloseTile();
                    }
                    if (tileFeatures[1] == 'w')
                    {
                        _elementfactory.CreateWater(this, tiles[j, i]);
                        return;
                    }
                    if (tileFeatures[1] == 'd')
                    {
                        _elementfactory.CreateSand(this, tiles[j, i]);
                        return;
                    }
                    if (tileFeatures[1] == 'i')
                    {
                        _elementfactory.CreateSpice(this, tiles[j, i]);
                        return;
                    }
                    if (tileFeatures[1] == 'h')
                    {
                        _elementfactory.CreateSolders(this, tiles[j, i], tileFeatures[2], tileFeatures[3]);
                        return;
                    }
                    if (tileFeatures[1] == 'b')
                    {
                        _elementfactory.CreateBait(this, tiles[j, i]);
                        return;
                    }
                    if (tileFeatures[1] == 'a')
                    {
                        _elementfactory.CreateWorm(this, tiles[j, i]);
                        return;
                    }
                    if (tileFeatures[1] == 'r')
                    {
                        _elementfactory.CreateRocket(this, tiles[j, i]);
                        return;
                    }
                }
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