using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{ 
    public int level;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OpenScene()
    {
        SceneManager.LoadScene("Level" +level.ToString());
    }
}
