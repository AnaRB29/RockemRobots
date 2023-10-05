using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyFactory : MonoBehaviour
{
    [Header("Enemy Config")]
    [SerializeField] private Transform enemyTargetTransform;
    [SerializeField] private float enemyspeed;
    [SerializeField] private Enemy enemyPrefab;


    [Space,SerializeField] private List<Transform> spawnPoints;

    [SerializeField] private int numberOfEnemies;

    IEnumerator Start()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            CreateEnemy();
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void CreateEnemy()
    {
        var randomPoint = spawnPoints [Random.Range(0, spawnPoints.Count)];
        var enemy = Instantiate(enemyPrefab, randomPoint.position, Quaternion.identity);
        enemy.Init(enemyTargetTransform, enemyspeed);
    }

    private void OnEnemyDead(Enemy diedEnemy)
    {
        CreateEnemy();
    }

    private void OnEnable()
    {
        Enemy.OnEnemyDead += OnEnemyDead;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDead -= OnEnemyDead;
    }
}
