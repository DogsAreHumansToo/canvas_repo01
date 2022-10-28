using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dash : Ability
{
    public float dashVelocity;
    [SerializeField] bool canUseAbility = false;

    public override void Activate(GameObject parent)
    {
        PlayerMovementScript movement = parent.GetComponent<PlayerMovementScript>();
        movement.speed *= dashVelocity;


    }
    public override void BeginCooldown(GameObject parent)
    {
        PlayerMovementScript movement = parent.GetComponent<PlayerMovementScript>();
        movement.speed /= dashVelocity;
    }
}
