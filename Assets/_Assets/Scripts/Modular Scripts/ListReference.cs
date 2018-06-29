using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

[Serializable]
public class ListReference
{

    public bool UseConstant = true;

    public List<GameObject> ConstantValue;
    public ListVariable Variable;

    public ListReference() { }

    public ListReference(List<GameObject> value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public List<GameObject> Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public static implicit operator List<GameObject>(ListReference reference)
    {
        return reference.Value;
    }
}
