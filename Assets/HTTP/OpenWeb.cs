using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class OpenWeb : MonoBehaviour
{
    
    void Start()
    {
        Application.OpenURL("http://127.0.0.1:13579/face_detect_resting.html");
    }
    /*
    void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest("http://127.0.0.1:13579/index.html"));

        // A non-existing page.
        StartCoroutine(GetRequest("http://127.0.0.1:13579/index.html"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }
    */
}
