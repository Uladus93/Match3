using static Unity.PlasticSCM.Editor.WebApi.CredentialsResponse;

public class Bonus : FieldElement
{
    private BonusType _bonusType;
    public BonusType TokenType { get { return _bonusType; } private set { } }

    public Bonus(BonusType bonusType)
    {
        _bonusType = bonusType;
    }

    public Bonus()
    {
        _elementType = TypesOfFieldElements.Bonus;
    }
}