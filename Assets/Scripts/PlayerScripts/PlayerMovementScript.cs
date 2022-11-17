using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] public float speed;

    

    public Rigidbody2D body;
    private float horizontalInput;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    //Sean added sprite animation
    public Animator animator;

    private void OnEnable()
    {
        HealthScript.onPlayerDeath += DisablePlayerMovement;
    }
    private void OnDisable()
    {
        HealthScript.onPlayerDeath -= DisablePlayerMovement;
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        EnablePlayerMovement();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if(KBCounter <= 0)
        {
            // movement input
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
            
          
            
        }
        else
        {
            if(KnockFromRight==true)
            {
                body.velocity = new Vector2(-KBForce,0);
            }
            else
            {
                body.velocity = new Vector2(KBForce, 0);
            }
            KBCounter -= Time.deltaTime;
        }

        if(body.bodyType != RigidbodyType2D.Static)
        {
            // flip sprite
            if (horizontalInput > 0.01f)
            {
                transform.localScale = Vector3.one;
            }
            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        
    }

    private void DisablePlayerMovement()
    {
        body.bodyType = RigidbodyType2D.Static;
    }

    private void EnablePlayerMovement()
    {
        body.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Barrier")
        {
            Vector3 pushBack = new Vector3(0.3f,0.0f,0.0f);
            if(transform.position.x > 0)
            {
                pushBack.x = -pushBack.x;
            }
            else
            {
                Mathf.Abs(pushBack.x);
            }

            transform.position = transform.position + pushBack;
            Debug.Log("Barrier");
        }
    }
}
