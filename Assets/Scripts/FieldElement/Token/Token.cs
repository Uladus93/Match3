using UnityEngine;

public class Token : FieldElement
{
    private TokenType _tokenType;
    public TokenType TokenType { get { return _tokenType; } private set { } }

    public Token(TokenType tokenType)
    {
        _tokenType = tokenType;
    }

    private void Awake()
    {
        _elementType = TypesOfFieldElements.Token;
    }
}