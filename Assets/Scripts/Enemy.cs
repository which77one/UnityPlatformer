using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage ;
    [SerializeField] private float speed ;
    [SerializeField] private enemyData data;
    private GameObject player;
    

    //movement
    public Transform[] patrolPoints;
    public int patrolDestination;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValue();
    }

    // Update is called once per frame
    void Update()
    {
        Slime();
        

    }
    private void SetEnemyValue()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }
    private void Slime()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if(patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPoints[0].position) <.2f )
            {
                transform.localScale = new Vector3(1,1,1);
                patrolDestination = 1;
            }
        }
        if(patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPoints[1].position) <.2f )
            {
                transform.localScale = new Vector3(-1,1,1);
                patrolDestination = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (col.GetComponent<Health>() != null)
            {
                col.GetComponent<Health>().Damage(damage);
                this.GetComponent<Health>().Damage(3);
            }
        }
    }
}
