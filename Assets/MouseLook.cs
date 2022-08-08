using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //public float mouseSensitivity = 100f;

    //public Transform playerBody;

    // float xRotation = 0f;

    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        //  Cursor.lockState = CursorLockMode.Locked;
        //  Cursor.lockState = CursorLockMode.Confined;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;


        //  float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * UnityEngine.Time.deltaTime;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * UnityEngine.Time.deltaTime;

        // xRotation -= mouseY;
        //  xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //  playerBody.Rotate(Vector3.up * mouseX);
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
    }
}
