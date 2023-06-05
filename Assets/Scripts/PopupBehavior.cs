using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBehavior : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
           Destroy(gameObject);
        }
    }
}
