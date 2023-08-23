using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStone : MonoBehaviour
{
    public GameObject gameobject;
    public Transform trans;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject stone = Instantiate(gameobject, trans.position, trans.rotation);
            stone.GetComponent<StoneMove>().Shoot(new Vector3(0, 200, 2000));
        }
    }
}
