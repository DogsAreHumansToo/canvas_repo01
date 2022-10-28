using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameSystem : MonoBehaviour
{
    public int maxEnemies;
    public bool waveLevel = false;
    public int enemiesKilled = 0;
    public GameObject completeLevelUI;
    public GameObject player;
    public GameObject boss;
    public GameObject currentPoint;

    bool enemySpawn = false;

    private EnemySpawnerFixed enemySpawner;

    private void Update()
    {
        if (waveLevel)
        {
            if (enemiesKilled == maxEnemies)
            {
                if (enemySpawn == false)
                {
                    SpawnBoss();
                  
                    
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

    }

  
    public void SpawnBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
        Debug.Log("boss spawned");
        enemySpawn = true;

    }
}
