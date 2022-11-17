using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    public Image abilityIcon;
    public AbilityHolder ability;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ability.onCoolDown == true)
        {
            abilityIcon.enabled = false;

        }
        else
        {
            abilityIcon.enabled = true;
        }
    }
}
