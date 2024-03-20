using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private GameObject _parctilesWater;
    [SerializeField] private GameObject _parctilesBait;
    [SerializeField] private GameObject _parctilesRocket;
    [SerializeField] private GameObject _parctilesSand;
    [SerializeField] private GameObject _parctilesSpice;
    [SerializeField] private GameObject _parctilesWorm;
    [SerializeField] private GameObject _parctilesSolders;

    public GameObject parctilesWater { get { return _parctilesWater; } private set { } }
    public GameObject parctilesBait { get { return _parctilesBait; } private set { } }
    public GameObject parctilesRocket { get { return _parctilesRocket; } private set { } }
    public GameObject parctilesSand { get { return _parctilesSand; } private set { } }
    public GameObject parctilesSpice { get { return _parctilesSand; } private set { } }
    public GameObject parctilesWorm { get { return _parctilesWorm; } private set { } }
    public GameObject parctilesSolders { get { return _parctilesWorm; } private set { } }


    public void InstantiateParticles(FieldElement element, Vector3 position)
    {
        Vector3 particlePosition = new Vector3(position.x, position.y, position.z - 7);
        if (element.ElementType == TypesOfFieldElements.Token)
        {
            Token token = element as Token;
            switch (token.TokenType)
            {
                case TokenType.sand:
                    Instantiate(_parctilesSand, particlePosition, Quaternion.identity);
                    break;
                case TokenType.spice:
                    Instantiate(_parctilesSpice, particlePosition, Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
        else if (element.ElementType == TypesOfFieldElements.Bonus)
        {
            Bonus bonus = element as Bonus;
            switch (bonus.BonusType)
            {
                case BonusType.bait:
                    Instantiate(_parctilesBait, particlePosition, Quaternion.identity);
                    break;
                case BonusType.water:
                    Instantiate(_parctilesWater, particlePosition, Quaternion.identity);
                    break;
                case BonusType.rocket:
                    Instantiate(_parctilesRocket, particlePosition, Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
        else if (element.ElementType == TypesOfFieldElements.Enemy)
        {
            Enemy enemy = element as Enemy;
            switch (enemy.EnemyType)
            {
                case EnemyType.solders:
                    Instantiate(_parctilesSolders, particlePosition, Quaternion.identity);
                    break;
                case EnemyType.worm:
                    Instantiate(_parctilesWorm, particlePosition, Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
    }
}