using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UniInject;
using UniRx;

// Disable warning about fields that are never assigned, their values are injected.


public class Window_pointer : MonoBehaviour, INeedInjection
{
    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;

    private void Awake()
    {
        targetPosition = new Vector3(4, 3, 0);
        pointerRectTransform = transform.Find("pointer").GetComponent<RectTransform>();
    }
    private void Update()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) % 360;

        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);
    }



}
