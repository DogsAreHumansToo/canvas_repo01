using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    private float rotZ;
    public float RotationSpeed;
    public bool Clockwise;

    public PlayerMovementScript playerMovement;


    public DebrisSpawner _spawner;
    private ScreenShakeController cameraShake;
    [SerializeField] private GameObject player;
    [SerializeField] private float damage;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        cameraShake = FindObjectOfType<ScreenShakeController>();
    }
    private void Update()
    {
        if(Clockwise==false)
        {
            rotZ += Time.deltaTime * RotationSpeed;
        }
        else
        {
            rotZ += -Time.deltaTime * RotationSpeed;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            _spawner.GenerateNextObstGap();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
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
