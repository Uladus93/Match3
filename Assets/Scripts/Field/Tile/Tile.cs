using UnityEngine;

public class Tile
{
    private GameObject _prefabOfTileInstance;
    private TilesState _tileType;
    private GameObject _prefabOfFieldElement;
    private FieldElement _elementOfField;
    private bool _isEmpty;
    
    public GameObject PrefabOfTileInstance { get { return _prefabOfTileInstance;} private set { } }
    public FieldElement ElementOfField { get { return _elementOfField; } private set { } }
    public Tile(TilesState type, bool isEmpty)
    {
        _tileType = type;
        _isEmpty = isEmpty;
    }

    public void SetPrefabOfTile(GameObject prefab, System.Object caller)
    {
        if (caller.GetType() == typeof(TileFactory) && prefab != null)
        {
           _prefabOfTileInstance = prefab;
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

    public void SetElementOfField(FieldElement element, GameObject prefab)
    {
        _prefabOfFieldElement = prefab;
        _elementOfField = element;
    }

    public void ChangeElementOfField()
    {
        
    }
}