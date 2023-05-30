using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    //[SerializeField] private int speed = 1.5;
    [SerializeField] private enemyData data;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Slime();
    }
    private void Slime()
        {
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (col.GetComponent<playerHealth>() != null)
            {
                col.GetComponent<playerHealth>().Damage(damage);
                this.GetComponent<playerHealth>().Damage(3);
            }
        }
    }
}
