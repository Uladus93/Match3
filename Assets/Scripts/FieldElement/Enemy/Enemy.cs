public class Enemy : FieldElement
{
    private EnemyType _enemyType;
    private bool _isInvulnerable;
    private byte _lives;
    public EnemyType EnemyType { get { return _enemyType; } private set { } }

    public Enemy(EnemyType enemyType)
    {
        _enemyType = enemyType;
        _elementType = TypesOfFieldElements.Enemy;
        if (_enemyType == EnemyType.worm)
        {
            _isInvulnerable = true;
            _lives = 255; 
            
        }
        else if (_enemyType == EnemyType.solders)
        {
            _isInvulnerable = false;
            _lives = 3;
        }
    }

    public byte GiveDamage()
    {
        if (!_isInvulnerable)
        {
            _lives--;
        }
        return _lives;
    }
}