using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string modeName = "ModeSelect";
    public SceneFader SceneFader;

    public void Play()
    {
        SceneFader.FadeTo(modeName);
    }

    public void Quit()
    {
        Debug.Log("Excuting...");
        Application.Quit();
    }
}
