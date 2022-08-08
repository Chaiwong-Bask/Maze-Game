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

public class Waveform : MonoBehaviour, INeedInjection
{
    //prefabs reference
    public GameObject the_pfCube;
    // array of game objects
    public GameObject[] the_cubes = new GameObject[1024];



	void Start() {

        float x = -512, y = 0, z = 0;
        //calculate
        float xIncrement = the_pfCube.transform.localScale.x;

        for( int i = 0;i < the_cubes.Length; i++)
        {
            // instantiate a prefab game object
            GameObject go = Instantiate(the_pfCube);
            //color material
            //go.GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(0, 1, 0));
            //default position
            go.transform.position = new Vector3(x, y, z);
            //incremetn the x position
            x += xIncrement;
            // give a name
            go.name = "cube" + i;
            //set a child of this waveform
            go.transform.parent = this.transform;
            // put into array
            the_cubes[i] = go;
        }
	}
	
	void Update() {

        //local reference to the time domain waveform
        float[] wf = AudioInput.the_waveform;


        //position the cubes
        for( int i =0; i < the_cubes.Length; i++)
        {
            the_cubes[i].transform.localPosition =
                new Vector3(the_cubes[i].transform.localPosition.x,
                50 * wf[i],
                the_cubes[i].transform.localPosition.z);
        }

	}
}
