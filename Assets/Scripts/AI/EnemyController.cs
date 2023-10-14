using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float moveSpeed = 3f;

    public SphereCollider SensArea;
    public Transform _playerTrm;
    public GameObject _gun;
    public GameObject _bullet;

    private RaycastHit _hit;

    public enum EnemyState
    {
        IDLE = 1, //기본상태
        MOVE = 2, //걷기상태
        CHASE = 3, //쫓는상태
        ATTACK = 4, //공격중
        QUESTION = 5, //관심을 가진 상태
        READY = 6
    }

    public EnemyState _state;

    private void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log(_state);

        switch(_state)
        {
            case EnemyState.IDLE:
                OnIdleAct();
                break;

            case EnemyState.MOVE:
                OnMoveAct();
                break;

            case EnemyState.CHASE:
                ChaseTarget();
                break;

            case EnemyState.ATTACK:
                AttackTarget();
                break;

            case EnemyState.QUESTION:
                RotateTarget();
                break;

            case EnemyState.READY:

                break;
        }

        Debug.DrawRay(transform.position, transform.forward * 10, Color.blue);
    }

    void ChaseTarget()
    {
        Vector3 TargetDir = (_playerTrm.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(TargetDir), 1);

        if (Vector3.Distance(_playerTrm.position, transform.position) >= 4.5f)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Physics.Raycast(_gun.transform.position, _gun.transform.forward, out _hit))
        {
            if (_hit.collider.name == "PlayerTrm")
            {
                _state = EnemyState.ATTACK;
            }

            WaitSecond(2);
        }

    }

    void RotateTarget()
    {
        Vector3 TargetDir = (_playerTrm.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(TargetDir), 0.25f);
    }

    void AttackTarget()
    {
        Instantiate(_bullet, _gun.transform.position, _gun.transform.rotation);
        _state = EnemyState.IDLE;
    }

    IEnumerator WaitSecond(int i)
    {
        yield return new WaitForSeconds(i);
    }

    void OnMoveAct()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void OnIdleAct()
    {

    }
}
