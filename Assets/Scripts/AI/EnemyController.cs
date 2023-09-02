using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float rotateTime;
    [SerializeField]
    private float moveTime;

    public float moveSpeed = 2f;

    [SerializeField]
    private int setRotatePos;

    public Transform[] _trmObjcts;

    public enum EnemyState
    {
        IDLE = 1, //기본상태
        MOVE = 2, //걷기상태
        CHASE = 3, //쫓는상태
        QUESTION = 4 //관심을 가진 상태
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
        SetRotateTimer();

        SetIdleState();
    }


    private void Update()
    {
        rotateTime -= Time.deltaTime;  //받아온 랜덤한 값에서 시간을 빼고,

        if(rotateTime <= 0)
        {
            rotateTime = 0;
        }

        moveTime -= Time.deltaTime;

        if (moveTime <= 0)
        {
            moveTime = 0;
        }

        if (_state == EnemyState.IDLE && rotateTime == 0)
        {
            switch(setRotatePos)
            {
                case 0:
                    transform.LookAt(_trmObjcts[0]);
                    _state = EnemyState.MOVE;
                    break;
                case 1:
                    transform.LookAt(_trmObjcts[1]);
                    _state = EnemyState.MOVE;
                    break;
                case 2:
                    transform.LookAt(_trmObjcts[2]);
                    _state = EnemyState.MOVE;
                    break;
                case 3:
                    transform.LookAt(_trmObjcts[3]);
                    _state = EnemyState.MOVE;
                    break;
            }

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

}
