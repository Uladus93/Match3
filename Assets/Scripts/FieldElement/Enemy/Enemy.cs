public class Enemy : FieldElement
{
    private EnemyType _enemyType;
    public EnemyType TokenType { get { return _enemyType; } private set { } }

    public Enemy(EnemyType enemyType)
    {
        _enemyType = enemyType;
    }

    public Enemy()
    {
        _elementType = TypesOfFieldElements.Enemy;
    }
}