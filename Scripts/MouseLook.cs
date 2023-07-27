using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;



public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = 0;
        float mouseY = 0;

        if (Touchscreen.current.touches.Count> 0 && Touchscreen.current.touches[0].isInProgress)
        {
            if (EventSystem.current.IsPointerOverGameObject(Touchscreen.current.touches[0].touchId.ReadValue()))
                return;
            mouseX = Touchscreen.current.touches[0].delta.ReadValue().x;
            mouseY = Touchscreen.current.touches[0].delta.ReadValue().y;
        }



        //if (Mouse.current != null)
        //{
        //    mouseX = Mouse.current.delta.ReadValue().x;
        //    mouseY = Mouse.current.delta.ReadValue().y;
        //}

        //if (Gamepad.current != null)
        //{
        //    mouseX = Gamepad.current.rightStick.ReadValue().x;
        //    mouseY = Gamepad.current.rightStick.ReadValue().y;
        //}

        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        mouseX *= mouseSensitivity;
        mouseY *= mouseSensitivity;

        xRotation += mouseY * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation,-80, 80);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);
    }
}
