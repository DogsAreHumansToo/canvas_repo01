using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    public PlayerMovementScript playerMovement;

    private ScreenShakeController cameraShake;

    [SerializeField] private PlayerCombat playerCounter;
    public float dazedTime1;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        cameraShake = FindObjectOfType<ScreenShakeController>();
    }
    private void Update()
    {
        
        Vector2 playerPosition = player.transform.position;
        playerPosition.y += 0.9f;
        transform.position = Vector2.MoveTowards(this.transform.position, playerPosition, speed * Time.deltaTime);
    }

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
            collision.GetComponent<HealthScript>().TakeDamage(damage);

            StartCoroutine(cameraShake.Shake(.04f, .04f));
        }
    }//pogpog
}
