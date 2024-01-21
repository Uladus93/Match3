using UnityEngine;
using UnityEngine.WSA;

public class ElementOfFieldFactory
{
    private GameObject _sandPrefab;
    private GameObject _spicePrefab;
    private GameObject _wormPrefab;
    private GameObject _soldersPrefab;
    private GameObject _waterPrefab;
    private GameObject _baitPrefab;

    public ElementOfFieldFactory(GameObject sandPrefab, GameObject spicePrefab, GameObject wormPrefab, GameObject soldersPrefab, GameObject waterPrefab, GameObject baitPrefab)
    {
        _sandPrefab = sandPrefab;
        _spicePrefab = spicePrefab;
        _wormPrefab = wormPrefab;
        _soldersPrefab = soldersPrefab;
        _waterPrefab = waterPrefab;
        _baitPrefab = baitPrefab;
    }

    public void CreateElement(System.Object caller, Tile parent)
    {
        if (caller.GetType() == typeof(Field))
        {
            float rnd = Random.Range(0, 600);
            if (rnd >= 0 && rnd < 100)
            {
                Token sandElement = new Token(TokenType.sand);
                GameObject sandObject = GameObject.Instantiate(_sandPrefab, parent.PrefabOfTileInstance.transform.position, Quaternion.identity, parent.PrefabOfTileInstance.transform);
                parent.SetElementOfField(sandElement, sandObject);
            }
            else if (rnd >= 100 && rnd < 200)
            {
                Token spiceElement = new Token(TokenType.spice);
                GameObject spiceObject = GameObject.Instantiate(_spicePrefab, parent.PrefabOfTileInstance.transform.position, Quaternion.identity, parent.PrefabOfTileInstance.transform);
                parent.SetElementOfField(spiceElement, spiceObject);
            }
            else if (rnd >= 200 && rnd < 300)
            {
                Enemy wormElement = new Enemy(EnemyType.worm);
                GameObject wormObject = GameObject.Instantiate(_wormPrefab, parent.PrefabOfTileInstance.transform.position, Quaternion.identity, parent.PrefabOfTileInstance.transform);
                parent.SetElementOfField(wormElement, wormObject);
            }
            else if (rnd >= 300 && rnd < 400)
            {
                Enemy soldersElement = new Enemy(EnemyType.solders);
                GameObject soldersObject = GameObject.Instantiate(_soldersPrefab, parent.PrefabOfTileInstance.transform.position, Quaternion.identity, parent.PrefabOfTileInstance.transform);
                parent.SetElementOfField(soldersElement, soldersObject);
            }
            else if (rnd >= 400 && rnd < 500)
            {
                Bonus waterElement = new Bonus(BonusType.water);
                GameObject waterObject = GameObject.Instantiate(_waterPrefab, parent.PrefabOfTileInstance.transform.position, Quaternion.identity, parent.PrefabOfTileInstance.transform);
                parent.SetElementOfField(waterElement, waterObject);
            }
            else if (rnd >= 500 && rnd <= 600)
            {
                Bonus baitElement = new Bonus(BonusType.bait);
                GameObject baitObject = GameObject.Instantiate(_baitPrefab, parent.PrefabOfTileInstance.transform.position, Quaternion.identity, parent.PrefabOfTileInstance.transform);
                parent.SetElementOfField(baitElement, baitObject);
            }
        }
    }
}