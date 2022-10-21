using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        Vector2 playerPosition = player.transform.position;
        playerPosition.y += 0.9f;
        transform.position = Vector2.MoveTowards(this.transform.position, playerPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<HealthScript>().TakeDamage(damage);
        }
    }
}
