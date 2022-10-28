using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerFixed : MonoBehaviour
{
    public GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;

    public GameObject[] enemies;
    public float minTimeBtwSpawns;
    public float maxTimeBtwSpawns;
    public bool canSpawn;
    public int maxEnemies;
    public int enemiesInRoom;
    public bool spawnerDone;
    public GameObject spawnerDoneGameObject;

    private int enemiesSpawned;
    

    private void Start()
    {
        Invoke("SpawnEnemy", 0.5f);
        enemiesSpawned = 0;
    }

    private void Update()
    {
        if (canSpawn)
        {
            if (enemiesSpawned >= maxEnemies)
            {
                canSpawn = false;
            }
        }
    }

    void SpawnEnemy()
    {
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        float timeBtwSpawns = Random.Range(minTimeBtwSpawns, maxTimeBtwSpawns);

        if (canSpawn)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], currentPoint.transform.position, Quaternion.identity);
            enemiesInRoom++;
            enemiesSpawned++;
        }

        Invoke("SpawnEnemy", timeBtwSpawns);
        if (spawnerDone)
        {
            spawnerDoneGameObject.SetActive(true);
        }
    }

}