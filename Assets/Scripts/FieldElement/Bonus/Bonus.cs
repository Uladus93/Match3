public class Bonus : FieldElement
{
    private BonusType _bonusType;

    public Bonus(BonusType bonusType)
    {
        _bonusType = bonusType;
    }

    private void Awake()
    {
        _elementType = TypesOfFieldElements.Bonus;
    }
}