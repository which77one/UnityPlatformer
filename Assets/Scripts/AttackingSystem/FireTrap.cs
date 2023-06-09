using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField ] private float TimeToActivate;
    [SerializeField ] private float Duration;
    private Animator anim;
    private SpriteRenderer sprite;
    private bool triggered;
    private bool active;
    private void Awake() 
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();     
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if(!triggered)
            {
                StartCoroutine(ActiveFireTrap());
            }
            if(active)
            {
                col.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(1);
            }
            
        }
    }
    private IEnumerator ActiveFireTrap()
    {
        yield return new WaitForSeconds(TimeToActivate);
        triggered = true;
        active = true;
        anim.SetBool("activated", true);
        yield return new WaitForSeconds(Duration);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
