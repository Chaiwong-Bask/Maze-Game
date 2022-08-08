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
[RequireComponent(typeof(Toggle))]
public class MicToggle : MonoBehaviour, INeedInjection
{
    Toggle myToggle;

	void Start() {

        myToggle = GetComponent<Toggle>();

      
	
	}
	
	void Update() {
	
	}
}
