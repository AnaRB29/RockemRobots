using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private VariableReference<Vector3> mouseInput;
    [SerializeField] private VectorAxis axisToRotate;

    private Vector3 _oldPosition = Vector3.zero;
    private float _currentRotation;
    private void Update()
    {
        var deltaPos = _oldPosition - mouseInput.Value;
        Debug.Log(deltaPos, gameObject);

        _oldPosition = mouseInput.Value;
    }
}
