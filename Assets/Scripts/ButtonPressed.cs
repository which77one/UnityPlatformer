using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    public Animator anim;
    public bool IsPressed = false;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        anim.SetTrigger("IsPressed");
        IsPressed = true;   
    }
    void OnTriggerExit2D(Collider2D col)
    {
        anim.SetTrigger("IsNotPressed");
        IsPressed = false;    
    }

}
