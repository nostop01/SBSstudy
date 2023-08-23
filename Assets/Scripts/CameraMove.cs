using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float rx = 0;
    float ry = 0;

    [Header("마우스 감도")]
    public float rotateSpeedX;
    public float rotateSpeedY;

    private void Start()
    {
        rx = transform.eulerAngles.x;
        ry = transform.eulerAngles.y;
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        rx += v * rotateSpeedX * Time.deltaTime;
        ry += h * rotateSpeedY * Time.deltaTime;

        rx = Mathf.Clamp(rx, -55, 55);

        transform.eulerAngles = new Vector3(-rx, ry, 0); 
    }
}
