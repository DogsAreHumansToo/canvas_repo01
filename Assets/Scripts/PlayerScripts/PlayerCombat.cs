using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    //public Animator animator;

    public AudioSource enemyHitSound;
    public AudioSource missedAttack;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 50;
    
    public float attackRate = 4f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                Debug.Log("attack");
                missedAttack.Play();

            }
        }
    }
    void Attack()
    {
        //Play attack animation
        //animator.SetTrigger("Attack");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHitBox>().TakeDamage(attackDamage);
            enemyHitSound.Play();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
           
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
