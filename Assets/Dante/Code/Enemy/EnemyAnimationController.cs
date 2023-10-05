using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SeekArrival seekArrival;

    private void Start()
    {
        animator.speed = seekArrival.speed;
    }
}
