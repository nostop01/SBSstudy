using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("이동속도")]
    [SerializeField]
    float MoveSpeed = 10f;

    [Header("마우스")]
    [SerializeField]
    float mouseX = 0;
    [SerializeField]
    float mouseSpeed = 0;

    [Header("점프")]
    [SerializeField]
    float JumpPower = 5f;


    Vector3 dir;

    CharacterController characterController;
    Rigidbody rigid;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        //Run();
        //Crowl();

        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if(characterController.isGrounded)
        {
            dir = new Vector3(h, 0, v);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                dir.y = 5f;
            }
        }

        characterController.Move(transform.TransformDirection(dir) * Time.deltaTime * MoveSpeed);

        dir.y += Physics.gravity.y * Time.deltaTime;
    }

    private void Run()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            MoveSpeed = 12.5f;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            MoveSpeed = 10;
        }
    }

    private void Crowl()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            MoveSpeed = 7.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            MoveSpeed = 10;
        }
    }
}
