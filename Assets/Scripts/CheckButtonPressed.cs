using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckButtonPressed : MonoBehaviour
{
    public GameObject Button;
    void Update()
    {
        if(Button.GetComponent<ButtonPressed>().IsPressed == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
