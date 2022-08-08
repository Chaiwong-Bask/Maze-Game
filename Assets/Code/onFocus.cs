using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onFocus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnApplicationFocus(bool focus)
    {
        if(focus == false)
        {
            GameObject.Find("PauseCanvas").transform.GetChild(0).gameObject.SetActive(true);
            //Debug.Log("false");
        }
        else
        {
            GameObject.Find("PauseCanvas").transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
