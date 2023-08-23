using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMove : MonoBehaviour
{
    Rigidbody _rigid;

    private void Awake()
    {
        Destroy(gameObject, 3);
    }

    private void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    public void Shoot(Vector3 speed)
    {
        //_rigid.AddForce(speed, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(speed);
    }
}
