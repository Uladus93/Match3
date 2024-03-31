
using UnityEngine;

public class Solders : Enemy
{
    private byte _needStrenght;
    private Sprite _enemySprite1;
    private Sprite _enemySprite2;

    public Sprite EnemySprite1 { get { return _enemySprite1; } private set { } }
    public Sprite EnemySprite2 { get { return _enemySprite2; } private set { } }
    public Solders(EnemyType enemyType, Sprite enemySprite1, Sprite enemySprite2, byte occupationTime, byte soldersNumber) : base(enemyType)
    {
        _enemySprite1 = enemySprite1;
        _enemySprite2 = enemySprite2;
        _isInvulnerable = false;
        _lives = soldersNumber;
        _occupationTime = occupationTime;
        _needStrenght = 5;
    }
    public byte GiveDamage()
    {
        if (_lives > 0)
        {
            _lives--;
        }

        return _lives;
    }

    public void UseStrenght(Tile tile)
    {
        _occupationTime++;
        if (_occupationTime == _needStrenght)
        {
            tile.CloseTile();
            _occupationTime = 0;
        }
    }

    public Sprite ChangeSprite( Sprite defaultSprite)
    {
        switch (_lives)
        {
            case 2: return _enemySprite2;
                case 1: return _enemySprite1;
        }

        return defaultSprite;
    }
}