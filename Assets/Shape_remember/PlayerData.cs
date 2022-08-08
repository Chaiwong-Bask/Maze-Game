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

[SerializeField]
public class PlayerData : MonoBehaviour
{
    private int _score;
    private double _timePlayed;

    public PlayerData() { }
    public PlayerData(int score, double timePlayed)
    {
        _score = score;
        _timePlayed = timePlayed;
    }

    public int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    public double timePlayed
    {
        get
        {
            return _timePlayed;
        }
        set
        {
            _timePlayed = value;
        }
    }
    
}
