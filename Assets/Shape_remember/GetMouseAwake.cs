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

public class GetMouseAwake : MonoBehaviour, INeedInjection
{
    void Start()
    {
        if(Cursor.lockState != CursorLockMode.Locked) {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log(Cursor.lockState);
        }
    }

    void Update() {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Awake()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log(Cursor.lockState);
    }

    private void OnGUI()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
    }
}
