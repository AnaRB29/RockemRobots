using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchHand : MonoBehaviour
{
    private enum MouseClick
    {
        Left = 0,
        Right = 1
    }
    [Header("Mouse Input")]
    [SerializeField] private MouseClick mouseButton;

    [Space, SerializeField, Min(0.001f)] private float speed = 1;
    
    private bool _isPressing;

    [SerializeField] private Transform target, foldTarget, unfoldTarget;

    void Update()
    {
        _isPressing = Input.GetMouseButton((int)mouseButton);

        var currentTarget = _isPressing ? unfoldTarget : foldTarget;
        target.position = Vector3.MoveTowards(target.position, currentTarget.position, speed * Time.deltaTime);
    }
}