using UnityEngine.UI;

public class Tile
{
    private TypeOfTile _tileType;
    private bool _isEmpty;
    //private Image _image;

    public Tile(TypeOfTile type, bool isEmpty)
    {
        _tileType = type;
        _isEmpty = isEmpty;
    }

    public void ClearTile()
    {
        if (_tileType == TypeOfTile.open)
        {
            _isEmpty = true;
        }
    }

    public void FillTile()
    {
        if (_tileType == TypeOfTile.open)
        {
            _isEmpty = false;
        }
    }
}