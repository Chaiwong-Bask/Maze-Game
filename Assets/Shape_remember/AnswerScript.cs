using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UniInject;
using UniRx;


// Disable warning about fields that are never assigned, their values are injected.
#pragma warning disable CS0649

public class AnswerScript : MonoBehaviour, INeedInjection
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public Color startColor;

    private void Start()
    {
        startColor = GetComponent<Image>().color;
       // startColor = Color.yellow;
    }

    public void Answer()
    {
        if(isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManager.wrong();
        }

    }
}
