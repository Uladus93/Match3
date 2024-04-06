using UnityEngine;
using UnityEngine.UI;

public class TileFactory
{
    private GameObject _prefab;
    private GameObject _parent;
    private Particles _particles;
    private SoundManager _soundManager;
    private float _width;
    private float _height;

    public TileFactory(GameObject prefab, GameObject parent, Particles particles, SoundManager soundManager)
    {
        _prefab = prefab;
        _parent = parent;
        _particles = particles;
        _soundManager = soundManager;
        _width = parent.GetComponent<Image>().rectTransform.rect.width;
        _height = parent.GetComponent<Image>().rectTransform.rect.height;
    }

    public Tile CreateTile(byte x, byte y)
    {
        Vector3 parentScale = _parent.GetComponentInParent<RectTransform>().lossyScale;
        Rect tileSize = _prefab.GetComponent<Image>().rectTransform.rect;
        float distanceKoef = 1.1f;
        Tile tile = new Tile(TilesState.open, true, y, x, _particles, _soundManager);
        GameObject tileObject = GameObject.Instantiate(_prefab, new Vector3( _parent.transform.position.x - (_width/2 * parentScale.x * 0.77f),
                                                                             _parent.transform.position.y - (_height / 2 * parentScale.y * 0.77f),
                                                                             _parent.transform.position.z) + 
                                                                new Vector3((x * tileSize.width) * parentScale.x * distanceKoef,
                                                                            (y * tileSize.height) * parentScale.y * distanceKoef,
                                                                            _parent.transform.position.z), Quaternion.identity, _parent.transform);
        tileObject.GetComponent<RectTransform>().localPosition = new Vector3(tileObject.GetComponent<RectTransform>().localPosition.x, tileObject.GetComponent<RectTransform>().localPosition.y, 0);


        tile.SetPrefabOfTile(tileObject, this);
        return tile;
    }
}