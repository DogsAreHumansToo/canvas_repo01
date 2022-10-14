using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    int enemyKilledCount = 0;

    private EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
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

    void Die()
    {
        Debug.Log("Enemy died!");

        Destroy(gameObject);
        enemySpawner = FindObjectOfType<EnemySpawner>();
        enemySpawner.enemiesInRoom--;
        if(enemySpawner.spawnTime <= 0 && enemySpawner.enemiesInRoom <= 0)
        {
            enemySpawner.spawnerDone = true;
        }

        //Die Animation

        //Disable the enemy
        enemyKilledCount++;
        Destroy(gameObject);
    }


}
