using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private MouseInput mouseInput;

    private Vector3 _oldPosition = Vector3.zero;
    private void Update()
    {
        var deltaPos = _oldPosition - mouseInput.Position;
        Debug.Log(deltaPos, gameObject);
    }
}
