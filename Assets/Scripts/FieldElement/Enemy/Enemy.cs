public class Enemy : FieldElement
{
    private protected EnemyType _enemyType;
    private protected bool _isInvulnerable;
    private protected byte _lives;
    private protected byte _occupationTime;
    public EnemyType EnemyType { get { return _enemyType; } private set { } }
    public byte Lives { get { return _lives; } private set{ } }
    public byte OccupationTime { get { return _occupationTime; } private set { } }

    public Enemy(EnemyType enemyType)
    {
        _enemyType = enemyType;
        _elementType = TypesOfFieldElements.Enemy;
    }
}