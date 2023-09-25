using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VariableReference<T>
{
    [SerializeField] private bool useConstant;

    [SerializeField] private Variable<T> variable;

    [SerializeField] private T constant;

    public T Value
    {
        get
        {
            return useConstant ? constant : variable.Value;
        }
    }
}
