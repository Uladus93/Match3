using UnityEngine;

public class Tile
{
    private GameObject _tileObject;
    private TilesState _tileType;
    private GameObject _fieldElement;
    private FieldElement _elementOfField;
    private FieldPosition _fieldPosition;
    private bool _isEmpty;
    private bool _isSelected;
    private const float _koefficientOfSelectedTile = 1.2f;
    
    public GameObject TileObject { get { return _tileObject;} private set { } }
    public TilesState TileType { get { return _tileType; } private set { } }
    public GameObject FieldElement { get { return _fieldElement; } private set { } }
    public FieldElement ElementOfField { get { return _elementOfField; } private set { } }
    public FieldPosition FieldPosition { get { return _fieldPosition; } private set { } }
    public bool IsEmpty { get { return _isEmpty; } private set { } }
    public bool IsSelected { get { return _isSelected; } private set { } }
    public Tile(TilesState type, bool isEmpty, byte row, byte column)
    {
        _tileType = type;
        _isEmpty = isEmpty;
        IsSelected = false;
        _fieldPosition = new FieldPosition(row, column);
    }

    public void SetPrefabOfTile(GameObject prefab, System.Object caller)
    {
        if (caller.GetType() == typeof(TileFactory) && prefab != null)
        {
           _tileObject = prefab;
        }
    }

    public void ClearTile()
    {
        if (_tileType == TilesState.open)
        {
            GameObject.Destroy(_fieldElement);
            _isEmpty = true;
        }
        else
        {
            _tileType = TilesState.open;
        }
    }

    public void ChangeTileState()
    {
        
    }

    public void SetElementOfField(FieldElement element, GameObject prefab)
    {
        _fieldElement = prefab;
        _elementOfField = element;
        _isEmpty = false;
        _isSelected = false;
    }

    public void ChangeElementOfField()
    {
        
    }

    public void SelectTile()
    {
        _isSelected = true;
        _fieldElement.transform.localScale *= _koefficientOfSelectedTile;
    }

    public void UnselectTile()
    {
        _isSelected = false;
        _fieldElement.transform.localScale /= _koefficientOfSelectedTile;
    }

    public void SetPosition(byte x, byte y)
    {
        
    }
}