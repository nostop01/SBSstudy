using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float rotateTime;
    [SerializeField]
    private float moveTime;
    [SerializeField]
    private float shootDelayTime = 0.5f;

    public float moveSpeed = 2f;
    public float rotateSpeed = 5f;

    private float maxRayDistance = 300f;

    [SerializeField]
    private int setRotatePos;

    public Transform[] _trmObjcts;
    public Transform _bulletSpawner;
    public GameObject _bullet;

    private Rigidbody rigid;

    private RaycastHit hit;


    public enum EnemyState
    {
        IDLE = 1, //기본상태
        MOVE = 2, //걷기상태
        CHASE = 3, //쫓는상태
        ATTACK = 4, //공격중
        QUESTION = 5 //관심을 가진 상태
    }

    EnemyState _state;

    #region EnemyStateFunction

    void SetIdleState()
    {
        _state = EnemyState.IDLE;
    }

    void SetChaseState()
    {
        _state = EnemyState.CHASE;
    }

    void SetMoveState()
    {
        _state = EnemyState.MOVE;
    }

#endregion

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

        SetRotateTimer();

        SetIdleState();
    }


    private void Update()
    {
        rotateTime -= Time.deltaTime;  //받아온 랜덤한 값에서 시간을 빼고,

        moveTime -= Time.deltaTime;

        shootDelayTime -= Time.deltaTime;

        if (rotateTime <= 0)
        {
            rotateTime = 0;
        }

        if (moveTime <= 0)
        {
            moveTime = 0;
        }

        if(shootDelayTime <= 0)
        {
            shootDelayTime = 0;
        }

        ShootRayCast();

        if (_state == EnemyState.IDLE && rotateTime == 0)
        {
            //Turn(setRotatePos);
            SetRotate();
            _state = EnemyState.MOVE;

            SetRotateTimer();  //반복
        }

        if(_state == EnemyState.MOVE && moveTime != 0f)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        else if(moveTime == 0)
        {
            SetMoveTimer();
            _state = EnemyState.IDLE;
        }

        if(_state == EnemyState.ATTACK && shootDelayTime <= 0)
        {
            Attack();
            _state = EnemyState.IDLE;
        }
    }

    void SetRotateTimer()
    {
        rotateTime = Random.Range(3, 8); //3초에서 8초 사이 랜덤한 값을 받는다
        setRotatePos = Random.Range(0, 3);
    }

    void SetMoveTimer()
    {
        moveTime = Random.Range(3, 5);
    }

    void Turn(int i)
    {
        Vector3 vec = _trmObjcts[i].position - transform.position;
        var newRotation = Quaternion.LookRotation(vec);

        rigid.rotation = Quaternion.Slerp(rigid.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }

    void SetRotate()
    {
        switch(setRotatePos)
        {
            case 0:
                transform.LookAt(_trmObjcts[0]);
                break;
            case 1:
                transform.LookAt(_trmObjcts[1]);
                break;
            case 2:
                transform.LookAt(_trmObjcts[2]);
                break;
            case 3:
                transform.LookAt(_trmObjcts[3]);
                break;
        }
    }

    private void ShootRayCast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRayDistance))
        {
            if(hit.collider.CompareTag("Player"))
            {
                _state = EnemyState.ATTACK;
            }
        }
    }

    private void Attack()
    {
        Instantiate(_bullet, _bulletSpawner.position, _bulletSpawner.rotation);
        shootDelayTime = 0.5f;
    }
}
