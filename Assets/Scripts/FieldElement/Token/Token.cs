using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : FieldElement
{
    private TokenType _type;

    private void Awake()
    {
        _type = TypesOfFieldElements.Token;
    }

}