using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : FieldElement
{
    private void Awake()
    {
        _type = TypesOfFieldElements.Obstacle;
    }
}
