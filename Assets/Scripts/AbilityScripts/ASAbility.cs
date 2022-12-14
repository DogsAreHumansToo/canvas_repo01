using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ASAbility : Ability
{
    public float multiplier = 2;
    public bool canUseAbility = false;

    public override void Activate(GameObject parent)
    {
        if(canUseAbility)
        {
            PlayerCombat stats = parent.GetComponent<PlayerCombat>();
            stats.attackRate *= multiplier;
        }
        
    }
    public override void BeginCooldown(GameObject parent)
    {
        PlayerCombat stats = parent.GetComponent<PlayerCombat>();
        stats.attackRate /= multiplier;
    }
    
}
