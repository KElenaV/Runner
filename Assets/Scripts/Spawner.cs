using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private float _timeBetweenSpawn = 1;
    [SerializeField] private Transform[] _spawnPoints;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialized(_enemyPrefabs);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;
                
                int pointNumber = Random.Range(0, _spawnPoints.Length);
            
                SetEnemy(enemy, _spawnPoints[pointNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
