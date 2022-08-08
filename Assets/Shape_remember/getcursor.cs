using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getcursor : MonoBehaviour
{
    public GameObject dialog, player, _camera;
    // Start is called before the first frame update
    void Start()
    {
        // _Cursor.SetActive(false);

        dialog.SetActive(false);
        player.SetActive(false);
        _camera.SetActive(true);

        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
     void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log(Cursor.lockState);
    }
     void OnGUI()
    {
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }


}
