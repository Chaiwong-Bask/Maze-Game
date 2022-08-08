using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    // public static CursorLockMode lockState;
    // Update is called once per frame
    /*
        IEnumerator FixMouse()
        {
            Cursor.lockState = CursorLockMode.Locked;
            yield return new WaitForSeconds(Time.deltaTime * 2);
            Cursor.lockState = CursorLockMode.Confined;
        }
        */
    void Start()
        {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log(Cursor.lockState);
    }
        


    /*   private void Start()
       {
           Cursor.lockState = CursorLockMode.Locked;
       }

       void Update()
       {

           if(Cursor.lockState != CursorLockMode.Confined)
           {
               Cursor.lockState = CursorLockMode.None;
               Cursor.lockState = CursorLockMode.Confined;
           }
               Cursor.lockState = CursorLockMode.Locked;
               Cursor.visible = true;


       }*/

    void Awake()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
      
        Debug.Log(Cursor.lockState);
    }

    private void OnGUI()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
    }
    /*private void OnApplicationFocus(bool ApplicationIsBack)
    {
        if(ApplicationIsBack == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }*/
}
