using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawn : MonoBehaviour
{
    public GameObject _stonePrefab;

    public Transform _stoneTrm;

    public bool _haveStone = false;

    private void Update()
    {
        if(_haveStone == false)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                GameObject Stone = Instantiate(_stonePrefab) as GameObject;
                Stone.transform.SetParent(_stoneTrm.transform, false);
                _haveStone = true;
            }
        }
    }
}
