using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    //public Animator animator;

    public AudioSource enemyHitSound;
    public AudioSource missedAttack;

    public GameObject player;
    public GameObject enemy;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    [SerializeField]
    Sprite attacksprite;
    [SerializeField]
    Sprite hurtsprite;
    [SerializeField]
    Sprite idleState;
    [SerializeField]
    Sprite enemyIdleState;

    public float attackRange = 0.5f;
    public int attackDamage = 50;
    
    public float attackRate = 4f;
    float nextAttackTime = 0f;

    [SerializeField]
    private float thrust, knockTime;


    private void OnEnable()
    {
        HealthScript.onPlayerDeath += DisableAttack;
    }
    private void OnDisable()
    {
        HealthScript.onPlayerDeath -= DisableAttack;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
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
    private void Start()
    {
        EnableAttack();
    }
    private void DisableAttack()
    {
        nextAttackTime = 50f;
    }

    private void EnableAttack()
    {
        nextAttackTime = 0f;
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
            
            
            if (enemy.gameObject.CompareTag("Enemy"))
            {
                Rigidbody2D enemy1 = enemy.GetComponent<Rigidbody2D>();
                if (enemy1 != null)
                {
                    
                    StartCoroutine(KnockCo(enemy1));
                    enemy.gameObject.GetComponent<SpriteRenderer>().sprite = hurtsprite;
                }

            }
            else
            {
                enemy.gameObject.GetComponent<SpriteRenderer>().sprite = enemyIdleState;
            }
            
            enemy.GetComponent<EnemyHitBox>().TakeDamage(attackDamage);
            //enemy.GetComponent<BossHitBox>().TakeDamage(attackDamage);
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

   


    //knock enemy when hit by player
    private IEnumerator KnockCo(Rigidbody2D enemy1)
    {


        if (enemy1 != null)
        {
            
            Vector2 differenceDirection = enemy1.transform.position - transform.position;
            Vector2 difference = differenceDirection.normalized * thrust;
            difference.y = 0;
            
            enemy1.velocity = difference;
            // enemy1.AddForce(difference, ForceMode2D.Impulse);
            yield return new WaitForSeconds(knockTime);
            
            enemy1.velocity = new Vector2();
            

        }

    }
}
 

