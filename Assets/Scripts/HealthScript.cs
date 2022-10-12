using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _Damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _Damage, 0, startingHealth);

        if(currentHealth > 0)
        {

        }
        else
        {

        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }
}
