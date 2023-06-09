using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    public Animator anim;
    void Awake()
    {
       anim = GetComponent<Animator>();
    }
    public void OnTriggerEnter2D(Collider2D col)
    {      
        StartCoroutine(WinningTime());              
    } 
    IEnumerator WinningTime()
    {    
        Debug.Log("WinningTime");    
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level0");   
    }
}
