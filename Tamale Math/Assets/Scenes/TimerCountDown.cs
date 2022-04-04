using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondLeft = 30;
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
        takingAway - true;
        yield return new WaitForSeconds(1);
        secondLeft -= 1;
        textDisplay.GetComponent<Text>().text = "00:" + secondLeft;
        takingAway = false;
    }

    
        
    
}
