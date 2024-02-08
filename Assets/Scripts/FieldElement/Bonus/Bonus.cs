using static Unity.PlasticSCM.Editor.WebApi.CredentialsResponse;

public class Bonus : FieldElement
{
    private BonusType _bonusType;
    public BonusType BonusType { get { return _bonusType; } private set { } }

    public Bonus(BonusType bonusType)
    {
        _bonusType = bonusType;
        _elementType = TypesOfFieldElements.Bonus;
    }
}