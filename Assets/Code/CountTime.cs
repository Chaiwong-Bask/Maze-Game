using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountTime : MonoBehaviour
{
    public Text timeSpent;
    public static float startTime, t;
    private bool finnished = false;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (finnished)
            return;
             t = Time.time - startTime;
       
       


            string minutes = ((int) t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timeSpent.text = minutes + ":" + seconds;
       

    }

    public void Finnish()
    {
        finnished = true;
        timeSpent.color = Color.yellow;
        Debug.Log(t);
    }
}
