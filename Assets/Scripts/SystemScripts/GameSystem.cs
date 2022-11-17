using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameSystem : MonoBehaviour
{
    public int maxEnemies;
    public bool waveLevel = false;
    public bool timeLevel = false;
    public int enemiesKilled = 0;
    public GameObject completeLevelUI;
    public GameObject player;
    public GameObject boss;
    public GameObject currentPoint;

    public bool hasBossSpawned = false;

    public EnemySpawnerFixed enemySpawner;

    public ScreenShakeController cameraShake;

    private void start()
    {
        cameraShake = FindObjectOfType<ScreenShakeController>();
    }

    private void Update()
    {
        if (waveLevel)
        {
            if (enemiesKilled == maxEnemies)
            {
                if (hasBossSpawned == false)
                {
                    SpawnBoss();
                    StartCoroutine(cameraShake.Shake(1f, 0.6f));
                }

            }
            if (enemiesKilled > maxEnemies)
            {
                Debug.Log("WIN!!!!!!!!!!!!!!!");
                enemiesKilled = 0;
                player.SetActive(false);
                completeLevelUI.SetActive(true);
            }
        }

        if(timeLevel)
        {
            if(enemySpawner.targetTime <= 0)
            {
                if (hasBossSpawned == false)
                {
                    enemySpawner.spawnerON = false;
                    enemySpawner.canSpawn = false;
                    SpawnBoss();
                    StartCoroutine(cameraShake.Shake(1f, 0.6f));
                    enemiesKilled = 0;
                    maxEnemies = enemySpawner.enemiesInRoom;
                    
                }
                if (enemiesKilled > maxEnemies)
                {
                    Debug.Log("WIN!!!!!!!!!!!!!!!");
                    enemiesKilled = 0;
                    player.SetActive(false);
                    completeLevelUI.SetActive(true);
                }
            }
        }

    }

  
    public void SpawnBoss()
    {
        hasBossSpawned = true;
        Vector3 spawnPosition = player.transform.position;
        spawnPosition.x = player.transform.position.x + 18;
        Instantiate(boss, spawnPosition, Quaternion.identity); 
        
        Debug.Log("boss spawned");
    }

}
