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

public class FunctionTime : MonoBehaviour, INeedInjection
{
    private Action action;
    private float timer;

    public FunctionTime(Action action, float timer)
    {
        this.action = action;
        this.timer = timer;
    }

	void Update() {
        timer -= UnityEngine.Time.deltaTime;
        if(timer < 0)
        {
            //trigger action
            SceneManager.LoadScene(1);

        }
	}
}
