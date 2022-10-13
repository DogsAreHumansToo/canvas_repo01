using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    

    private void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<HealthScript>().TakeDamage(damage);
        }
    }
}
