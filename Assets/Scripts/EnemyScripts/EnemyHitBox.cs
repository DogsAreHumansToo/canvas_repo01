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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        enemySpawner = FindObjectOfType<EnemySpawnerFixed>();
        gameSystem = FindObjectOfType<GameSystem>();

        if (enemySpawner.targetTime <= 0 && gameSystem.hasBossSpawned == false)
       {
           if (!isBoss)
           {
                Debug.Log("room clear");
                Die();
           }
       }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

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
        Destroy(gameObject);
    }


}
