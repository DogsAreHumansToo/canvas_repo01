using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    public PlayerMovementScript playerMovement;

    bool facingRight = true;
    public bool boss;
    private ScreenShakeController cameraShake;
    [SerializeField] private PlayerCombat playerCounter;
    public float dazedTime1;

    public Animator animator;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        cameraShake = FindObjectOfType<ScreenShakeController>();
    }
    private void Update()
    {
        if (boss == true)
        {
            Vector2 playerPosition = player.transform.position;
            playerPosition.y += 0.9f;
            transform.position = Vector2.MoveTowards(this.transform.position, playerPosition, speed * Time.deltaTime);
            animator.SetFloat("Speed", Mathf.Abs(speed));

            if (player.transform.position.x - this.transform.position.x < 0 && !facingRight)
            {
                flip();
            }
            else if (player.transform.position.x - this.transform.position.x > 0 && facingRight)
            {
                flip();
            }
        }
        if (boss == false)
        {
            Vector2 playerPosition = player.transform.position;
            playerPosition.y += 0.9f;
            transform.position = Vector2.MoveTowards(this.transform.position, playerPosition, speed * Time.deltaTime);
            

            if (player.transform.position.x - this.transform.position.x < 0 && !facingRight)
            {
                flip();
            }
            else if (player.transform.position.x - this.transform.position.x > 0 && facingRight)
            {
                flip();
            }
        }
    }

    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    //knock player when hit by enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement = player.GetComponent<PlayerMovementScript>();
        if (collision.gameObject.tag == "Player")
        {
            

            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if (collision.transform.position.x < transform.position.x)
            {
                playerMovement.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerMovement.KnockFromRight = false;
            }
            

            StartCoroutine(cameraShake.Shake(.04f, .08f));
            collision.GetComponent<HealthScript>().TakeDamage(damage);
            
        }
    }
}
