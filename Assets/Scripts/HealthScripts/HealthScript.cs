using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public static event Action onPlayerDeath;
    public GameObject hitSparkObject;
    Animator animatorHitSpark;
    public AudioSource playerHitSound;

    private GameObject player;
    
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private void Start()
    {
        animatorHitSpark = hitSparkObject.gameObject.GetComponent<Animator>();
        player = gameObject.GetComponent<GameObject>();
        playerHitSound = player.GetComponent<AudioSource>();
    }
    private void Awake()
    {
        currentHealth = startingHealth;
        
    }
    //Player Taking Damage
    public void TakeDamage(float _Damage)
    {
        playerHitSound.Play();
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
