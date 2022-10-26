using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    float activeTime;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    AbilityHolder state = AbiliyState.ready
    public KeyCode key;

    void Update()
    {
        switch(state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(key))
                {
                    ability.Activate();
                    state = AbilityState.active;
                    ativateTime = ability.activateTime;
                }
                break;
            case AbilityState.activate:
                if(activeTime > 0)
                {
                    activeTime -= activeTime.deltaTime;
                }
                else
                {
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                }
                break;
            case AbilityState.cooldown:
                break;
        }
        
    }

}
