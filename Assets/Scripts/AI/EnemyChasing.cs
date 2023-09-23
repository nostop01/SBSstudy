using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing : MonoBehaviour
{
    EnemyController _enemyController;

    public GameObject _sensObj;

    // Start is called before the first frame update
    void Start()
    {
        _enemyController = FindObjectOfType<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enemyController._state = EnemyController.EnemyState.CHASE;
            _sensObj.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enemyController._state = EnemyController.EnemyState.CHASE;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _sensObj.SetActive(true);
        }
    }
}
