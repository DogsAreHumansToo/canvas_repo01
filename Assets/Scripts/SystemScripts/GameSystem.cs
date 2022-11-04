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
                    StartCoroutine(cameraShake.Shake(1f, 0.8f));
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
                    SpawnBoss();
                    StartCoroutine(cameraShake.Shake(1f, 0.8f));
                    enemiesKilled = 0;
                    maxEnemies = 1;
                    enemySpawner.toggleTimer = false;
                }
                //if (enemiesKilled > maxEnemies)
                //{
                //    Debug.Log("WIN!!!!!!!!!!!!!!!");
                //    enemiesKilled = 0;
                //    player.SetActive(false);
                //    completeLevelUI.SetActive(true);
                //}
            }
        }

    }

  
    public void SpawnBoss()
    {
        hasBossSpawned = true;
        Instantiate(boss, transform.position, Quaternion.identity);
        
        Debug.Log("boss spawned");
    }

}
