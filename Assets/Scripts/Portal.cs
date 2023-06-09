using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination;
    public GameObject player;
    public GameObject Box;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Box = GameObject.FindGameObjectWithTag("Box");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position) > 1f)
            {
                player.transform.position = destination.transform.position;
            }
        }
        if(col.CompareTag("Box"))
        {
            if(Vector2.Distance(Box.transform.position, transform.position) > 1f)
            {
                Box.transform.position = destination.transform.position ;
            }
        }   
    }
    
}
