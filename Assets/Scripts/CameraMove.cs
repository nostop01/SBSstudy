using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    float mouseSpeed = 15;
    float mouseY = 0;

    void Start()
    {
        
    }

    void Update()
    {
        mouseY += Input.GetAxis("Mouse Y") * mouseSpeed;

        mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f);

        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }
}
