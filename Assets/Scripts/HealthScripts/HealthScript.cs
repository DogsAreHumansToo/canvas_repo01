using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public static event Action onPlayerDeath;
    public GameObject hitSparkObject;
    Animator animatorHitSpark;

    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private void Start()
    {
        animatorHitSpark = hitSparkObject.gameObject.GetComponent<Animator>();

    }
    private void Awake()
    {
        currentHealth = startingHealth;
        
    }
    //Player Taking Damage
    public void TakeDamage(float _Damage)
    {
        animatorHitSpark.SetTrigger("Hurt");
        currentHealth = Mathf.Clamp(currentHealth - _Damage, 0, startingHealth);

        if (currentHealth <= 0)
        {
            //currentHealth = 0;
            
            onPlayerDeath?.Invoke();
            
        }
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //TakeDamage(1);
        }
    }

}
