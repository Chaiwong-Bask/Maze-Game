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

public class SaveScore : MonoBehaviour, INeedInjection
{
    public static int _score;

	void Start() {
        _score = QuizManager.score;
	}
	
	void Update() {
        _score = QuizManager.score;
    }
}
