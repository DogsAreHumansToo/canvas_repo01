using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHitBox : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public GameObject hitSparkEmpty;
    public GameSystem gameSystem;
    public bool isBoss;

    

    PlayerCombat killCount;
    private EnemySpawnerFixed enemySpawner; //


    private ScreenShakeController cameraShake;
    Animator animator;
    Animator animatorHitSpark;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        cameraShake = FindObjectOfType<ScreenShakeController>();
        animator = GetComponent<Animator>();
        gameSystem = FindObjectOfType<GameSystem>();
        
        animatorHitSpark = hitSparkEmpty.gameObject.GetComponent<Animator>();
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
    //Enemy Taking Damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(cameraShake.Shake(.04f, .03f));
        animator.SetTrigger("Hurt");
        animatorHitSpark.SetTrigger("Hurt");
        

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

        BGAlphaChange bGAlphaChange = FindObjectOfType<BGAlphaChange>();
        bGAlphaChange.MoreTransparency();
        
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
