using UnityEngine;

public class Bonus : FieldElement
{
    private protected BonusType _bonusType;
    private protected int _count;
    public BonusType BonusType { get { return _bonusType; } private set { } }
    public int Count { get { return _count; } private set { } }

    public Bonus(BonusType bonusType)
    {
        _bonusType = bonusType;
        _elementType = TypesOfFieldElements.Bonus;
        _count = Random.Range(1, 2);
    }
}