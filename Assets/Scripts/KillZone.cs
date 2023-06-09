using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KillZone : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);      
    }
}
