using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 1;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("enemy"))
        {
            enemyHealth enemyHealth = col.GetComponent<enemyHealth>();
            enemyHealth.Damage(damage);
        }
    }
}
