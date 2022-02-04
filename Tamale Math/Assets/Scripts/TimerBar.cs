using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider slider;
    public bool isCounting = false;

    public void SetTime(int t)
    {
        slider.value = t;
        if (isCounting)
        {
            slider.value = slider.value - 1;
        }
    }

}
