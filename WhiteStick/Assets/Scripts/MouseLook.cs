using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform stickRotation;

    float xRotation = 0f;
    float yRotation = 0f;

    float duttTimer = 0f;
    public float animTimer = 1f;
    bool startTimer;
    bool endTimer;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        
    }

    void Update()
    {
        if (!Input.GetKey(KeyCode.Mouse1))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            //xRotation -= mouseY;
            //xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);

            yRotation += mouseX;

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startTimer = true;


            transform.Rotate(9, 0, 0);
            Debug.Log("White Cane boop");
        } 
        if (startTimer == true)
        {
            duttTimer += Time.deltaTime;

            float lerpPercent = duttTimer / animTimer;

            float xRotation = Mathf.Lerp(0, 8, lerpPercent);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

            if (duttTimer >= animTimer)
            {
                startTimer = false;
                duttTimer = 0f;
                endTimer = true;
            }
        }
        if (endTimer == true)
        {
            duttTimer += Time.deltaTime;

            float lerpPercent = duttTimer / animTimer;

            float xRotation = Mathf.Lerp(8, 0, lerpPercent);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
            if (duttTimer >= animTimer)
            {
                endTimer = false;
                duttTimer = 0f;
            }
        }

    }
}
