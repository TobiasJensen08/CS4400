using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lean.Touch;

public class TouchInput : MonoBehaviour
{
    
    void OnEnable()
	{
		LeanTouch.OnFingerTap += HandleFingerTap;
        LeanTouch.OnFingerSwipe += InterpretSwipe;
	}

	void OnDisable()
	{
		LeanTouch.OnFingerTap -= HandleFingerTap;
        LeanTouch.OnFingerSwipe -= InterpretSwipe;
	}

	void HandleFingerTap(LeanFinger finger)
	{
		Debug.Log("You just tapped the screen with finger " + finger.Index + " at " + finger.ScreenPosition);
	}


    public void InterpretSwipe(LeanFinger finger)
	{
		// Store the swipe delta in a temp variable
		var swipe = finger.SwipeScreenDelta;

		/*
		//src: https://csharp.hotexamples.com/examples/-/Lean/-/php-lean-class-examples.html
		if (swipe.x < -Mathf.Abs(swipe.y))
		{
			Debug.Log ("You swiped left!");
		}
		
		if (swipe.x > Mathf.Abs(swipe.y))
		{
			Debug.Log ("You swiped right!");
		}
		
		if (swipe.y < -Mathf.Abs(swipe.x))
		{
			Debug.Log ("You swiped down!");
		}
		
		if (swipe.y > Mathf.Abs(swipe.x))
		{
			Debug.Log ("You swiped up!");
		}*/
		
		if(swipe.x>0 && swipe.y>0){
			Debug.Log("Swiped Top-right");
			Messenger<int>.Broadcast(GameEvent.ANSWER, 1);
		} else if(swipe.x>0 && swipe.y<=0){
			Debug.Log("Swiped Bottom-right");
			Messenger<int>.Broadcast(GameEvent.ANSWER, 2);
		} else if(swipe.x<=0 && swipe.y<=0){
			Debug.Log("Swiped Bottom-left");
			Messenger<int>.Broadcast(GameEvent.ANSWER, 3);
		} else{
			Debug.Log("Swiped Top-left");
			Messenger<int>.Broadcast(GameEvent.ANSWER, 0);
		}
	}
}
