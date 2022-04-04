using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondLeft = 50;
    public bool takingAway = false;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "00:" + secondLeft;

    }
    void Update()
    {
        if(takingAway == false && secondLeft > 0)
        {
            StartCoroutine(TimerTaker());
        }
    }
    IEnumerator TimerTaker()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondLeft -= 1;
        if(secondLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0 " + secondLeft;
    
        }
        else
        {
             textDisplay.GetComponent<Text>().text = "00:" + secondLeft;
           
        }
       
        takingAway = false;
    }        
    
}
