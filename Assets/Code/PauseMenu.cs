using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject _lockCursor;
    public int currentSceneIndex;

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused == true)
        {
            _lockCursor.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {

                Resume();

            }
            else
            {

                Pause();

            }
        }


    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        _lockCursor.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Resume");


    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        _lockCursor.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void LoadMenu()
    {
        Debug.Log("loading . . .");
        Time.timeScale = 1f;
        SceneManager.LoadScene("ModeSelect");
        Resume();
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game . . .");
        Application.Quit();
    }
    public void HintMenu()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(28);
    }
}
