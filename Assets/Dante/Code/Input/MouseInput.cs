using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    
    private enum PositionType
    {
        ScreenPos,
        WorldPos,
        ViewPort
    }

    [SerializeField] private PositionType mousePositionType;

    [SerializeField] private Camera mouseCamera;
    private void Awake()
    {
        if(mouseCamera == null)
            mouseCamera = Camera.main;
    }

    public Vector3 Position
    {
        get
        {
            var mouseScreenPos = Input.mousePosition;
            var worldPos = mouseCamera.ScreenToWorldPoint(mouseScreenPos);
            worldPos.z = 0;
            return mousePositionType switch
            {
                PositionType.ScreenPos => mouseScreenPos,
                PositionType.WorldPos => worldPos,
                PositionType.ViewPort => mouseCamera.ScreenToViewportPoint(mouseScreenPos)
            };
            
        }
    }
}
