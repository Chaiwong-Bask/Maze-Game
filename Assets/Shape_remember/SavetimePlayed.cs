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

public class SavetimePlayed : MonoBehaviour, INeedInjection
{
    public static float _timespent;

	void Start() {

        _timespent = CountTime.t;

	}
	
	void Update() {

        _timespent = CountTime.t;

    }
}
