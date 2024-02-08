using UnityEngine;

public class TileFactory
{
    private GameObject _prefab;
    private GameObject _parent;

    public TileFactory(GameObject prefab, GameObject parent)
    {
        _prefab = prefab;
        _parent = parent;
    }

    public Tile CreateTile(byte x, byte y)
    {
        Tile tile = new Tile(TilesState.open, true, y, x);
        GameObject tileObject = GameObject.Instantiate(_prefab, _parent.transform.position + new Vector3(-35 + x * 12, -35 + y * 12, 0), Quaternion.identity, _parent.transform);
        tile.SetPrefabOfTile(tileObject, this);
        return tile;
    }
}