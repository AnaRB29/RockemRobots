using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Click Inputs")]
    [SerializeField] private AxisReference leftClick;
    [SerializeField] private AxisReference rightClick;

    
    private Vector3 _leftArmsPosition, _rightArmPosition;
}
