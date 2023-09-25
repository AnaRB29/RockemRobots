using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct AxisReference
{
    [SerializeField] private string _axisName;

    public float Value
    {
        get => Input.GetAxis(_axisName);
    }
}
