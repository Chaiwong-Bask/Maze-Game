using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    //public GameObject questionTrigger;
    public GameObject questionNumTrigger;
    public GameObject lockCursor;

    private void OnTriggerEnter()
    {
        questionNumTrigger.SetActive(true);
        lockCursor.SetActive(false);
        //questionTrigger.SetActive(false);
        Debug.Log("Working");
    }
    
}
