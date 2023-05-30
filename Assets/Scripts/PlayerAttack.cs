using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timetoAttack = 0.25f;
    private float timer = 0f;
    public Animator anim;

    void Start()
    {
        attackArea = transform.GetChild(1).gameObject;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
            
        }
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timetoAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                
            }
        }
    }
    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        anim.SetTrigger("Attack");

    }
}
