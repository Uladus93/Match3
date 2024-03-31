using UnityEngine;

public class ElementOfFieldFactory
{
    private GameObject _sandPrefab;
    private GameObject _spicePrefab;
    private GameObject _wormPrefab;
    private GameObject _soldersPrefab;
    private GameObject _waterPrefab;
    private GameObject _baitPrefab;
    private GameObject _rocketPrefab;
    private Sprite _enemySprite1;
    private Sprite _enemySprite2;

    public ElementOfFieldFactory(GameObject sandPrefab, GameObject spicePrefab, GameObject wormPrefab,
        GameObject soldersPrefab, GameObject waterPrefab, GameObject baitPrefab, GameObject rocketPrefab, Sprite enemySprite1, Sprite enemySprite2)
    {
        _sandPrefab = sandPrefab;
        _spicePrefab = spicePrefab;
        _wormPrefab = wormPrefab;
        _soldersPrefab = soldersPrefab;
        _waterPrefab = waterPrefab;
        _baitPrefab = baitPrefab;
        _rocketPrefab = rocketPrefab;
        _enemySprite1 = enemySprite1;
        _enemySprite2 = enemySprite2;
    }

    public void CreateElement(System.Object caller, Tile parent)
    {
        if (caller.GetType() == typeof(FieldObjectGenerator))
        {
            int rnd = Random.Range(0, 700);
            if (rnd >= 0 && rnd < 100)
            {
                Sand sandElement = new Sand(TokenType.sand);
                GameObject sandObject = GameObject.Instantiate(_sandPrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
                parent.SetElementOfField(sandElement, sandObject);
            }
            else if (rnd >= 100 && rnd < 200)
            {
                Spice spiceElement = new Spice(TokenType.spice);
                GameObject spiceObject = GameObject.Instantiate(_spicePrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
                parent.SetElementOfField(spiceElement, spiceObject);
            }
            else if (rnd >= 200 && rnd < 300)
            {
                Worm wormElement = new Worm(EnemyType.worm);
                GameObject wormObject = GameObject.Instantiate(_wormPrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
                parent.SetElementOfField(wormElement, wormObject);
            }
            else if (rnd >= 300 && rnd < 400)
            {
                Solders soldersElement = new Solders(EnemyType.solders, _enemySprite1, _enemySprite2, 0, 3);
                GameObject soldersObject = GameObject.Instantiate(_soldersPrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
                parent.SetElementOfField(soldersElement, soldersObject);
            }
            else if (rnd >= 400 && rnd < 500)
            {
                Aqua aquaElement = new Aqua(BonusType.water);
                GameObject waterObject = GameObject.Instantiate(_waterPrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
                parent.SetElementOfField(aquaElement, waterObject);
            }
            else if (rnd >= 500 && rnd <= 600)
            {
                Bait baitElement = new Bait(BonusType.bait);
                GameObject baitObject = GameObject.Instantiate(_baitPrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
                parent.SetElementOfField(baitElement, baitObject);
            }
            else if(rnd >= 600 && rnd <= 700)
            {
                Rocket rocketElement = new Rocket(BonusType.rocket);
                GameObject rocketObject = GameObject.Instantiate(_rocketPrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
                parent.SetElementOfField(rocketElement, rocketObject);
            }
        }
    }

    public void CreateWater(System.Object caller, Tile parent)
    {
        if (caller.GetType() == typeof(FieldObjectGenerator))
        {
            Aqua aquaElement = new Aqua(BonusType.water);
            GameObject waterObject = GameObject.Instantiate(_waterPrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
            parent.SetElementOfField(aquaElement, waterObject);
        }
    }

    public void CreateSpice(System.Object caller, Tile parent)
    {
        if (caller.GetType() == typeof(FieldObjectGenerator))
        {
            Spice spiceElement = new Spice(TokenType.spice);
            GameObject spiceObject = GameObject.Instantiate(_spicePrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
            parent.SetElementOfField(spiceElement, spiceObject);
        }
    }

    public void CreateSand(System.Object caller, Tile parent)
    {
        if (caller.GetType() == typeof(FieldObjectGenerator))
        {
            Sand sandElement = new Sand(TokenType.sand);
            GameObject sandObject = GameObject.Instantiate(_sandPrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
            parent.SetElementOfField(sandElement, sandObject);
        }
    }

    public void CreateRocket(System.Object caller, Tile parent)
    {
        if (caller.GetType() == typeof(FieldObjectGenerator))
        {
            Rocket rocketElement = new Rocket(BonusType.rocket);
            GameObject rocketObject = GameObject.Instantiate(_rocketPrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
            parent.SetElementOfField(rocketElement, rocketObject);
        }
    }

    public void CreateBait(System.Object caller, Tile parent)
    {
        if (caller.GetType() == typeof(FieldObjectGenerator))
        {
            Bait baitElement = new Bait(BonusType.bait);
            GameObject baitObject = GameObject.Instantiate(_baitPrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
            parent.SetElementOfField(baitElement, baitObject);
        }
    }

    public void CreateSolders(System.Object caller, Tile parent, char solderNumber, char occupationTime)
    {
        if (caller.GetType() == typeof(FieldObjectGenerator))
        {
            byte soldersNumber = determineSolders();
            byte timeOccupation = occupateTime();
            Solders soldersElement = new Solders(EnemyType.solders, _enemySprite1, _enemySprite2, timeOccupation, soldersNumber);
            GameObject soldersObject = GameObject.Instantiate(_soldersPrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
            soldersObject.GetComponent<SpriteRenderer>().sprite = soldersElement.ChangeSprite(soldersObject.GetComponent<SpriteRenderer>().sprite);

            parent.SetElementOfField(soldersElement, soldersObject);

            byte determineSolders()
            {
                if (solderNumber == 'x')
                {
                    return 1;
                }
                if (solderNumber == 'y')
                {
                    return 2;
                }
                return 3;
            }

            byte occupateTime()
            {
                if (solderNumber == 'k')
                {
                    return 1;
                }
                if (solderNumber == 'l')
                {
                    return 2;
                }
                if (solderNumber == 'm')
                {
                    return 3;
                }
                if (solderNumber == 'n')
                {
                    return 4;
                }
                if (solderNumber == 'o')
                {
                    return 5;
                }
                return 0;
            }
        }
    }

    public void CreateWorm(System.Object caller, Tile parent)
    {
        if (caller.GetType() == typeof(FieldObjectGenerator))
        {
            Worm wormElement = new Worm(EnemyType.worm);
            GameObject wormObject = GameObject.Instantiate(_wormPrefab, parent.TileObject.transform.position, Quaternion.identity, parent.TileObject.transform);
            parent.SetElementOfField(wormElement, wormObject);
        }
    }
}