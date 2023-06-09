using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public PlayerHealthManager playerHealthManager;
    public PlayerController playerController;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            
            playerController.KBCounter = playerController.KBTotalTime;
            if(col.transform.position.x <= transform.position.x)
            {
                playerController.KnockToRight = true; 
            }
            if(col.transform.position.x > transform.position.x)
            {
                playerController.KnockToRight = false; 
            }
            col.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(1);
        }
    }
}
