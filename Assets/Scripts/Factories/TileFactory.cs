using UnityEngine;

public class TileFactory
{
    private GameObject _prefab;

    public TileFactory(GameObject prefab)
    {
        _prefab = prefab;
    }

    public Tile CreateTile(int x, int y, Transform parent)
    {
        Tile tile = new Tile(TilesState.open, false);
        tile.SetPrefab(GameObject.Instantiate(_prefab, new Vector3(x, y, 0), Quaternion.identity, parent), this);
        return tile;
    }
}