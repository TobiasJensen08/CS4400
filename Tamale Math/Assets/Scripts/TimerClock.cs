using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerClock : MonoBehaviour
{
  public Text clockText;  

  private void Awake()
  {
      clockText = GetComponent<Text>();

  }
  private void Update()
  {
      DateTime time = DateTime.Now;
      string hour = LeadingZero(time.Hour);
      string minute = LeadingZero(time.Minute);
      string second = LeadingZero(time.Second);


      clockText.text = hour + ":" + minute + ":" + second;  //we want in a format of ex. 13:44:13
  }
  string LeadingZero(int n)
  {
      return n.ToString().PadLeft(2, '0');
  }
    
}
