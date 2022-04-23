using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.DateTime;
using System;

public class TimerCountDown : MonoBehaviour
{
    [SerializeField]
    private Text textEnergy;

    [SerializeField]
    private Text textTimer;

     [SerializeField]
    private int maxEnergy;

    private int totalEnergy = 0;

    private DateTime nextEnergyTime;
    private DateTime lastAddedTime;

    private int restoreDuration = 10; // 10 second fo testing purpose

    private bool restoring = false;

    void Start()
    {
       // PlayerPrefs.DeleteAll();
        Load();
        StartCoroutine(RestoreRoutine());
      
    } 
    
    public void useEnergy()
    {
        if( totalEnergy == 0)
        return;

        totalEnergy --;
        UpdateEnergy();

        if(!restoring)
        {
            if(totalEnergy+1 == maxEnergy)
            {
                //if enrgy is full just now
                nextEnergyTime = AddDuration(DateTime.Now, restoreDuration);
            }
            StartCoroutine(RestoreRoutine());
        }
    }

    private IEnumerator RestoreRoutine()
    {
        UpdateEnergy();
        UpdateTimer();
        restoring = true;

        while(totalEnergy < maxEnergy)
        {
            DateTime currentTime = DateTime.Now;
            DateTime counter = nextEnergyTime;
            bool isAdding = false;

            while(currentTime > counter)
            {
                if(totalEnergy < maxEnergy)
                {
                    isAdding = true;
                    totalEnergy++;
                    DateTime timeToAdd = lastAddedTime > counter ? lastAddedTime : counter;
                    counter = AddDuration(timeToAdd, restoreDuration);
                }
                else
                    break;
            }
            if(isAdding)
            {
                lastAddedTime = DateTime.Now;
                nextEnergyTime = counter;
            }

            UpdateTimer();
            UpdateEnergy();
            Save();
            yield return null;

        }
        restoring = false;

    }

    private void UpdateTimer()
    {
        if(totalEnergy >= maxEnergy)
        {
            textTimer.text = "Full";
            return;
        }
        TimeSpan t = nextEnergyTime - DateTime.Now;
        string value = StringToDate.Format("{0}:{1:D2}:{2:D2}", (int)t.TotalHours, t.Minutes, t.Seconds);

    }

    private void UpdateEnergy()
    {
        textEnergy.text = totalEnergy.ToString();

    }

    private DateTime AddDuration(DateTime time, int duration)
    {
        return time.AddSeconds(duration);
    }


      public void Load()
    {
        totalEnergy = PlayerPrefs.GetInt("totalEnergy");
        nextEnergyTime = StringToDate(PlayerPrefs.GetString("nextEnergyTime"));
        lastAddedTime = StringToDate(PlayerPrefs.GetString("lastAddedTime"));


    }  
    public void Save()
    {
        PlayerPrefs.SetInt("totalEnergy", totalEnergy);
        PlayerPrefs.SetString("nextEnergyTime", nextEnergyTime.ToString());
        PlayerPrefs.SetString("lastAddedTime", lastAddedTime.ToString());
        

    }  
    private DateTime StringToDate(string date)
    {
        if(String.IsNullOrEmpty(date))
            return DateTime.Now;

        return DateTime.Parse(date);    


    }
    
}
