using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 2;
    public float duration = 4;
    public AudioSource pickUpSND;//

    //public GameObject pickupEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }
    IEnumerator Pickup(Collider2D player)
    {
        Debug.Log("Picked UP!");
        PlayerCombat stats = player.GetComponent<PlayerCombat>();
        stats.attackRate *= multiplier;
        pickUpSND.Play();

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.attackRate /= multiplier;

        Destroy(gameObject);
    }

}