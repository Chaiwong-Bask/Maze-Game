using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float timevalue = 30;
    //public bool timerIsRunning = false;
    public Text timeText;

   /* private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }*/
    void Update()
    {
        
            if (timevalue > 0)
            {
                timevalue -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timevalue = 0;
               // timerIsRunning = false;
            }
        DisplayTime(timevalue);
    }
         

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}

