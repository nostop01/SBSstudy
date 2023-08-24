using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawn : MonoBehaviour
{
    public GameObject _stonePrefab;

    public Transform _stoneTrm;

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameObject Stone = Instantiate(_stonePrefab) as GameObject;
        //    Stone.transform.SetParent(_stoneTrm.transform, false);
        //}
    }
}
