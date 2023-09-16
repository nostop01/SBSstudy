using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float rx= 0;
    public float rotateSpeedX;

    private void Start()
    {
        rx = transform.eulerAngles.x;
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float m = Input.GetAxis("Mouse X");

        rx += m * rotateSpeedX * Time.deltaTime;

        Vector3 dir = new Vector3(h, 0, v);

        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.Self);

        transform.eulerAngles = new Vector3(0, rx, 0);
    }
}
