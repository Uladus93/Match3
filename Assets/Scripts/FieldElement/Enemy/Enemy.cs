public class Enemy : FieldElement
{
    private EnemyType _enemyType;
    public EnemyType TokenType { get { return _enemyType; } private set { } }

    public Enemy(EnemyType enemyType)
    {
        _enemyType = enemyType;
    }

    private void Awake()
    {
        _elementType = TypesOfFieldElements.Enemy;
    }
}