using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePadForce : MonoBehaviour
{
    public float bounceForce = 10f;
    public Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("IsOnJumpPad");
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * bounceForce,ForceMode2D.Impulse);
        }
    }
     
}
