using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float delayAttackTime = 0;
    private bool isAttacking;
    public int attackDamage;
    public Transform attackPoint;

    public float attackRange = 0.5f;

    public LayerMask enemyLayers;
    public Animator anim;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
            isAttacking = true;
        }

        if(isAttacking)
        {
            delayAttackTime += Time.deltaTime;
            if(delayAttackTime>= 0.5f)
            {
                isAttacking=false;
                delayAttackTime =0;
            }
        }
    }
    private void Attack()
    {
        if(isAttacking == false)
        {
            anim.SetTrigger("Attack");
            isAttacking = true;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyTakingDamage>().TakeDamage(attackDamage);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
