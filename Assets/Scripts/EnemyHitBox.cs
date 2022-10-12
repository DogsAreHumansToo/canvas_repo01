using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

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

        //Die Animation

        //Disable the enemy
    }


}
