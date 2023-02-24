using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public event EventHandler OnEnemySpawned;

    [SerializeField] private Transform enemyPrefab;

    [SerializeField] private float spawnDistance = 8f;

    private float spawnPosY = 1f;

    private const float SPAWN_REPEAT_RATE = 3f;

    private const float SPAWN_START_TIME = 1f;

    private Transform lastSpawnedEnemy;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            InvokeRepeating("Spawn", SPAWN_START_TIME, SPAWN_REPEAT_RATE);
            OnEnemySpawned += SpawnManager_OnEnemySpawned;

        }
    }

    private void SpawnManager_OnEnemySpawned(object sender, EventArgs e)
    {
        LocateEnemy();
        RotateEnemy();
    }

    private void Spawn()
    {
        Transform enemy = Instantiate(enemyPrefab, transform);
        lastSpawnedEnemy = enemy;
        OnEnemySpawned?.Invoke(this, EventArgs.Empty);
    }

    private void LocateEnemy()
    {
        Vector3 randomSpawnPos = UnityEngine.Random.insideUnitSphere;
        randomSpawnPos = new Vector3(randomSpawnPos.x, 0, randomSpawnPos.z).normalized * spawnDistance;
        randomSpawnPos.y = spawnPosY;
        lastSpawnedEnemy.transform.position = randomSpawnPos;

    }

    private void RotateEnemy()
    {
        lastSpawnedEnemy.TryGetComponent<Enemy>(out Enemy enemy);
        if (enemy != null)
        {
            enemy.LookThePlayer();
        }
    }

}
