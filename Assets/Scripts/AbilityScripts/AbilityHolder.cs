using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    float activeTime;
    public bool unlocked = false;
    public Image abilityUI;
    public bool onCoolDown;
    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;
    public KeyCode key;


    //private void Start()
    //{
    //    unlocked = false;
    //}

    void Update()
    {
        if(unlocked)
        {
            switch (state)
            {

                case AbilityState.ready:
                    if (Input.GetKeyDown(key))
                    {
                        ability.Activate(gameObject);
                        state = AbilityState.active;
                        activeTime = ability.activeTime;
                        
                    }
                    break;
                case AbilityState.active:
                    if (activeTime > 0)
                    {
                        activeTime -= Time.deltaTime;
                    }
                    else
                    {
                        ability.BeginCooldown(gameObject);
                        state = AbilityState.cooldown;
                        cooldownTime = ability.cooldownTime;
                    }
                    break;
                case AbilityState.cooldown:
                    if (cooldownTime > 0)
                    {
                        cooldownTime -= Time.deltaTime;
                        abilityUI.enabled = false;
                    }
                    else
                    {
                        abilityUI.enabled = true;
                        state = AbilityState.ready;
                    }
                    break;
            }
        }
    }

}
