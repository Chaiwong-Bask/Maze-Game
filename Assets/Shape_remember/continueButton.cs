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

public class continueButton : MonoBehaviour, INeedInjection
{
    private int sceneToContinue;
   
    public void ContinueGame()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");

        if (sceneToContinue != 0)
        {
            SceneManager.LoadScene(sceneToContinue);
            
        }
        else
            return;
    }
}
