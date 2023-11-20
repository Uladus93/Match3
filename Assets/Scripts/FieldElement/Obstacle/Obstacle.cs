public class Obstacle : FieldElement
{
    private ObstacleType _obstacleType;

    public Obstacle(ObstacleType obstacleType)
    {
        _obstacleType = obstacleType;
    }

    private void Awake()
    {
        _elementType = TypesOfFieldElements.Obstacle;
    }
}
