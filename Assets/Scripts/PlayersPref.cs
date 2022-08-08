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

public class PlayersPref : MonoBehaviour, INeedInjection
{
    public GameObject Player;
    public float xPos;
    public float yPos;
    public float zPos;

    void Start() {

        Player.transform.position = new Vector3(xPos, yPos, zPos);


	}
	
	void Update() {

        xPos = Player.transform.position.x;
        yPos = Player.transform.position.y;
        zPos = Player.transform.position.z;

	}


}
