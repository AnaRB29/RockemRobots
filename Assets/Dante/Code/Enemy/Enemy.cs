using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SeekArrival seek;
    [SerializeField] private List<Rigidbody> rbs;

    public static event Action<Enemy> OnEnemyDead;
    
    public void Init(Transform target, float speed)
    {
        seek.target = target;
        seek.speed = speed;
    }

    public void EnemyDead()
    {
        foreach (var rb in rbs)
        {
            rb.AddForce(-transform.forward * 100, ForceMode.Impulse);
        }
        Destroy(gameObject, 5);
        OnEnemyDead?.Invoke(this);
    }
}
