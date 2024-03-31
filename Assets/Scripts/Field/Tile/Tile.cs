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
    private const float _koefficientOfSelectedTile = 1.1f;
    private Particles _particles;
    private SoundManager _soundManager;
    private Color _openTileColor = new((230f/255f), 200f/255f, 150f/255f);

    public GameObject TileObject { get { return _tileObject;} private set { } }
    public TilesState TileType { get { return _tileType; } private set { } }
    public GameObject FieldElement { get { return _fieldElement; } private set { } }
    public FieldElement ElementOfField { get { return _elementOfField; } private set { } }
    public FieldPosition FieldPosition { get { return _fieldPosition; } private set { } }
    public bool IsEmpty { get { return _isEmpty; } private set { } }
    public bool IsSelected { get { return _isSelected; } private set { } }
    public Tile(TilesState type, bool isEmpty, byte row, byte column, Particles particles, SoundManager soundManager)
    {
        _tileType = type;
        _isEmpty = isEmpty;
        IsSelected = false;
        _fieldPosition = new FieldPosition(row, column);
        _particles = particles;
        _soundManager = soundManager;
    }

    public void SetPrefabOfTile(GameObject prefab, System.Object caller)
    {
        if (caller.GetType() == typeof(TileFactory) && prefab != null)
        {
           _tileObject = prefab;
        }
    }

    public void TryClearTile()
    {
        if (_tileType == TilesState.open)
        {
            if (_elementOfField.GetType() == typeof(Solders))
            {
                Solders solders = _elementOfField as Solders;
                if (solders.GiveDamage() == 0)
                {
                    _soundManager.PlayDestroyElementSound(_elementOfField);
                    _particles.InstantiateParticles(_elementOfField, _fieldElement.transform.position);
                    GameObject.Destroy(_fieldElement);
                    _isEmpty = true;
                }
                else
                {
                    _soundManager.PlayDestroyElementSound(_elementOfField);
                    _particles.InstantiateParticles(_elementOfField, _fieldElement.transform.position);
                    _fieldElement.GetComponent<SpriteRenderer>().sprite = solders.ChangeSprite(_fieldElement.GetComponent<SpriteRenderer>().sprite);
                }
            }
            else
            {
                _soundManager.PlayDestroyElementSound(_elementOfField);
                _particles.InstantiateParticles(_elementOfField, _fieldElement.transform.position);
                GameObject.Destroy(_fieldElement);
                _isEmpty = true;
            }
        }
        else
        {
            OpenTile();
        }
    }

    public void OpenTile()
    {
        if (_tileType == TilesState.closed)
        {
            _soundManager.PlayOpenTileSound();
            _tileType = TilesState.open;
            _tileObject.GetComponent<SpriteRenderer>().color = _openTileColor;
        }
    }

    public void CloseTile()
    {
        if (_tileType == TilesState.open)
        {
            _tileType = TilesState.closed;
            _tileObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    public void SetElementOfField(FieldElement element, GameObject prefab)
    {
        _fieldElement = prefab;
        _elementOfField = element;
        _isEmpty = false;
        _isSelected = false;
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
}