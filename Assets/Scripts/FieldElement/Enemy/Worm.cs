
public class Worm : Enemy
{
    public Worm(EnemyType enemyType) : base(enemyType)
    {
            _isInvulnerable = true;
            _lives = 255;
    }
}
