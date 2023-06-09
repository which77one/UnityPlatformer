using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearingPlatform : MonoBehaviour
{
    public Animator anim;
    public bool HasBeenDestroyed;
    
    void Awake()
    {
       anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {  
            StartCoroutine(DisappearTime());           
        }
    } 
    IEnumerator DisappearTime()
    {    
        anim.SetTrigger("IsDisappearing");    
        yield return new WaitForSeconds(0.5f);      
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        
    }
    
        
        
    
    
}
