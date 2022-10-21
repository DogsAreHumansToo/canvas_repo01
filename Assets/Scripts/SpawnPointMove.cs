using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointMove : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D body;
    private float horizontalInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        EnableMovement();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // movement input
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (body.bodyType != RigidbodyType2D.Static)
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
    private void DisableMovement()
    {
        body.bodyType = RigidbodyType2D.Static;
    }

    private void EnableMovement()
    {
        body.bodyType = RigidbodyType2D.Dynamic;
    }
}
