using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHitBox : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public GameSystem gameSystem;
    public bool isBoss;

    PlayerCombat killCount;
    private EnemySpawnerFixed enemySpawner;

    //public SpriteRenderer yuh;

    private ScreenShakeController cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        cameraShake = FindObjectOfType<ScreenShakeController>();
    }

    private void Update()
    {
        enemySpawner = FindObjectOfType<EnemySpawnerFixed>();
        gameSystem = FindObjectOfType<GameSystem>();
        if(gameSystem.timeLevel == true)
        {
            if (enemySpawner.targetTime <= 0 && gameSystem.hasBossSpawned == false)
            {
                if (!isBoss)
                {
                    Debug.Log("room clear");
                    Die();
                }
            }
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(cameraShake.Shake(.04f, .02f));
        //play HURT animation

        if (currentHealth <= 0)
        {
            Die();
        }
        
    }

    public void Die()
    {
        if(gameSystem == null)
        {
            gameSystem = FindObjectOfType<GameSystem>();
        }
        Debug.Log("Enemy died!");

        
        Debug.Log(gameSystem.enemiesKilled);

        enemySpawner = FindObjectOfType<EnemySpawnerFixed>();
        enemySpawner.enemiesInRoom--;
        
        //if (EnemySpawnerFixed.spawnTime <= 0 && enemySpawner.enemiesInRoom <= 0)
        //{
        //    enemySpawner.spawnerDone = true;
        //}

        //Die Animation

        //Disable the enemy

        gameSystem.enemiesKilled++;
       

        Destroy(gameObject.GetComponent<BoxCollider2D>());
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
       
        StartCoroutine(destroyObject());
        
    }
    private IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }


}
