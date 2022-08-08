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

public class AudioInput : MonoBehaviour, INeedInjection
{
    // the audio source
    public AudioSource the_audioSource;

    // time domain waveform
    public static float[] the_waveform = new float[1024];

    //maginitude spectrum
    public float[] the_spectrum = new float[512];



    void Start() {
        //get audio source reference the game object
        the_audioSource = GetComponent<AudioSource>();

        //loop
        the_audioSource.loop = true;



        // sanity check for microphone
        if(Microphone.devices.Length > 0)
        {
            //device name (of default microphone)
            string selectedDevice = Microphone.devices[0].ToString();

            // set microphone as an audio clip
            the_audioSource.clip = Microphone.Start(selectedDevice, true, 1, AudioSettings.outputSampleRate);

            //what is this doing draining the sample buffer
            //reduce input latency from the microphone
            while(!(Microphone.GetPosition(selectedDevice) > 0)) { }

        }

        //play
        the_audioSource.Play();
	
	}
	
	void Update() {

        // get the time domain waveform
        the_audioSource.GetOutputData(the_waveform, 0);

        //get the magnitude spectrum
        the_audioSource.GetSpectrumData(the_spectrum, 0, FFTWindow.Hanning);



	}
}
