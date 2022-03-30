using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountDownTimer : MonoBehaviour
{
   float currentTime = 0f;
   float startingTime = 10f;
   [SerializeField] Text countdowntimerText;

   void Start()
   {
       currentTime = startingTime;
   }

   void Update()
   {
       currentTime -= 1 * Time.deltaTime;
       countdowntimerText.text = currentTime.ToString();

       countdowntimerText.color = Color.red;

       if(currentTime <= 0){
           currentTime = 00;
       }   }

   
}
