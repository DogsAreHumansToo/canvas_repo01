using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    //public Animator animator;

    public AudioSource enemyHitSound;
    public AudioSource missedAttack;

    public GameObject player;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    [SerializeField]
    Sprite attacksprite;
    [SerializeField]
    Sprite idleState;

    public float attackRange = 0.5f;
    public int attackDamage = 50;
    
    public float attackRate = 4f;
    float nextAttackTime = 0f;

    int enemyKilledCount;
    EnemyHitBox enemyTest;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                player.gameObject.GetComponent<SpriteRenderer>().sprite = attacksprite;
                //Debug.Log("attack");
                missedAttack.Play();

            }
            else
            {
                player.gameObject.GetComponent<SpriteRenderer>().sprite = idleState;
            }
        }
    }
    void win()
    {
        
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
