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

    public Tile CreateTile(int x, int y)
    {
        Tile tile = new Tile(TilesState.open, false);
        tile.SetPrefab(GameObject.Instantiate(_prefab,_parent.transform.position + new Vector3(x, y, 0), Quaternion.identity, _parent.transform), this);
        return tile;
    }
}