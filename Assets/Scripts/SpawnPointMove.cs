using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointMove : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D body;
    private float horizontalInput;
    public PlayerMovementScript player;
    public bool left;

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
        Vector2 offset;
        offset.y = 1;
        if (left)
        {
            offset.x = -12;
        }
        else
        {
            offset.x = 12;
        }
        body.MovePosition(player.body.position + offset);

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
