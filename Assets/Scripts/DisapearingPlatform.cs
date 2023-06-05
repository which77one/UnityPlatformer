using System.Collections;
using UnityEngine;

public class DisapearingPlatform : MonoBehaviour
{
    public Animator anim;
    public bool HasBeenDestroyed;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DisappearTime());
            if (HasBeenDestroyed = true)
            {
                StartCoroutine(ReappearTime());
            }
        }
    }


    IEnumerator DisappearTime()
    {
        anim.SetTrigger("IsDisappearing");
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        HasBeenDestroyed = true;
    }
    IEnumerator ReappearTime()
    {
        anim.SetTrigger("IsReappearing");
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
