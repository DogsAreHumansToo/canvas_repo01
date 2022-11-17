using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dash : Ability
{
    public float dashVelocity;
    BoxCollider2D boxCollider2D;
    bool onCoolDown;
    public override void Activate(GameObject parent)
    {

        PlayerMovementScript movement = parent.GetComponent<PlayerMovementScript>();
        boxCollider2D = parent.GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        movement.speed *= dashVelocity;
    }
    public override void BeginCooldown(GameObject parent)
    {
        PlayerMovementScript movement = parent.GetComponent<PlayerMovementScript>();
        boxCollider2D.enabled = true;
        movement.speed /= dashVelocity;

        
    }
}
