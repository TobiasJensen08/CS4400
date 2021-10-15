using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        
        var fingers = Lean.Touch.LeanTouch.Fingers;//For unknown reasons, each finger adds two entries to the list
        // A bug was found in the touch count.

        //var leanFinger = Lean.Touch.LeanFinger.TapCount;
        if(fingers.Count>0){
            Debug.Log("Tap: " + fingers[0].Tap);
            Debug.Log("Swipe: " + fingers[0].Swipe);
        }

    }
}
