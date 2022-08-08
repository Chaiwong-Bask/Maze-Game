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

public class PlayerInventory : MonoBehaviour
{
    

    public static int NumberOfTriangle { get; private set; }

    public static int NumberOfCircle { get; private set; }

    public static int NumberOfSquare { get; private set; }

   

    public void TriangleCollected()
    {
        NumberOfTriangle++;
        Debug.Log("Triangles collected = " + (NumberOfTriangle));
    }
    
    public void CircleCollected()
    {
        NumberOfCircle++;
        Debug.Log("Circles collected = " + (NumberOfCircle));
    }
    public void SquareCollected()
    {
        NumberOfSquare++;
        Debug.Log("Square collected = " + (NumberOfSquare));
    }
}
