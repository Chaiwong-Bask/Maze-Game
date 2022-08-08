
using UnityEngine;
using UniInject;
using UniRx;
using UnityEngine.SceneManagement;

// Disable warning about fields that are never assigned, their values are injected.
#pragma warning disable CS0649

public class LoadAfterTime : MonoBehaviour, INeedInjection
{
    [SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    private string sceneNameToLoad;

    private float timeElapsed;

    private void Update()
    {
        timeElapsed += UnityEngine.Time.deltaTime;

        if(timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
