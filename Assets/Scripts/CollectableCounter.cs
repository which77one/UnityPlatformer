using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableCounter : MonoBehaviour
{
    TMP_Text gemText;
    public static int gemAmount;
    
    void Start()
    {
        gemText = GetComponent<TMP_Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        gemText.text = gemAmount.ToString();
    }
}
