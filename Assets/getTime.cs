using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class getTime : MonoBehaviour
{

    public Text timeSpent;

    private float gt;

    // Start is called before the first frame update
    void Start()
    {
        gt = CountTime.t;
        Debug.Log(gt);

    }

  
}
