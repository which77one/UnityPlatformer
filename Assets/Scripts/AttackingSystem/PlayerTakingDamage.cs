using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakingDamage : MonoBehaviour
{
    public int currentHealth ;
    public int startingHealth = 5;
    //public Animator animTakingDamage;
    void awake()
    {
    
    }
    void Start()
    {
       currentHealth = startingHealth;   
    }

    public void TakeDamage(int damage)
    {
       
        currentHealth -= damage;

        // play animation 
        //animTakingDamage.SetTrigger("isTakingDamage");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
    
}
