using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Tile
{
    private GameObject _prefabInstance;
    private TilesState _tileType;
    private bool _isEmpty;
    
    public GameObject PrefabInstance { get { return _prefabInstance;} private set { } }
    public Tile(TilesState type, bool isEmpty)
    {
        _tileType = type;
        _isEmpty = isEmpty;
    }

    public void SetPrefab(GameObject prefab, System.Object caller)
    {
        if (caller.GetType() == typeof(TileFactory) && prefab != null)
        {
           _prefabInstance = prefab;
        }
    }

    public void ClearTile()
    {
        if (_tileType == TilesState.open)
        {
            _isEmpty = true;
        }
    }

    public void FillTile()
    {
        if (_tileType == TilesState.open)
        {
            _isEmpty = false;
        }
    }

    public void ChangeTileState()
    {
        
    }
}