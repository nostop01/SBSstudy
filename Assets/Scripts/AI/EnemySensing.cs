using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensing : MonoBehaviour
{
    EnemyController _enemyController;

    // Start is called before the first frame update
    void Start()
    {
        _enemyController = FindObjectOfType<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _enemyController._state = EnemyController.EnemyState.QUESTION;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enemyController._state = EnemyController.EnemyState.IDLE;
        }
    }
}
