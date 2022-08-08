using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_time : MonoBehaviour
{

    public Text timeText;
    private float startTime;
    private bool finnished = false;
    static public Text F_text;

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
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timeText.text = minutes + ":" + seconds;

        F_text = timeText;
    }

    public void Finnish()
    {
        finnished = true;
        timeText.color = Color.yellow;

    }
}
