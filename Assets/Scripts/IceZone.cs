using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceZone : MonoBehaviour
{
    public GameObject Player;
    void OnCollisionEnter2D(Collision2D col)
    {
        Player.GetComponent<PlayerController>().isSkiing = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        Player.GetComponent<PlayerController>().isSkiing = false;
    }
}
