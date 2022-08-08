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

public class SceneLoadAfterTime : MonoBehaviour, INeedInjection
{
    [SerializeField]
    private float delayBeforeLoading = 30f;
    [SerializeField]
    private string sceneNameToLoad;

    private float timeElapsed;

	void Update() {

        timeElapsed += Time.deltaTime;

        if(timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }

	}
}
