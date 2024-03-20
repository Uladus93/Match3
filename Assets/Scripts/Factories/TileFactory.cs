using UnityEngine;

public class TileFactory
{
    private GameObject _prefab;
    private GameObject _parent;
    private Particles _particles;
    private SoundManager _soundManager;

    public TileFactory(GameObject prefab, GameObject parent, Particles particles, SoundManager soundManager)
    {
        _prefab = prefab;
        _parent = parent;
        _particles = particles;
        _soundManager = soundManager;
    }

    public Tile CreateTile(byte x, byte y)
    {
        Tile tile = new Tile(TilesState.open, true, y, x, _particles, _soundManager);
        GameObject tileObject = GameObject.Instantiate(_prefab, _parent.transform.position + new Vector3(-3.405f + x * 1.13f, -3.405f + y * 1.13f, 0), Quaternion.identity, _parent.transform);
        tile.SetPrefabOfTile(tileObject, this);
        return tile;
    }
}