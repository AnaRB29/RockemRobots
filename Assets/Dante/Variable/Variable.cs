using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Variable<T> : ScriptableObject
{
    private T _value = default;
    public T Value
    {
        get => _value;
        set => _value = value;
    }
}
