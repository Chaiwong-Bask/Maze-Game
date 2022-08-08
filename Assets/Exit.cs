using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UniInject;
using UniRx;
using UnityEngine.SceneManagement;

// Disable warning about fields that are never assigned, their values are injected.
#pragma warning disable CS0649

public class Exit : MonoBehaviour, INeedInjection
{
    [SerializeField]
    private float delay = 30f;


    private float timeE;

    void Update()
    {

        timeE += Time.deltaTime;

        if (timeE > delay)
        {
            Application.Quit();
            Debug.Log("Application is quitting . . .");
        }

    }
}
