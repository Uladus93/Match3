using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : FieldElement
{
    private void Awake()
    {
        _type = TypesOfFieldElements.Token;
    }
}