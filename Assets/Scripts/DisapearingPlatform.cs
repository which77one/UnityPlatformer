using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearingPlatform : MonoBehaviour
{
    //public Animator anim;
    void Awake()
    {
       //anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //col.GetComponent<BoxCollider>().enabled = false;
        gameObject.SetActive(false);
    }
}
