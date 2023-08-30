using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float rotateTime;

    [SerializeField]
    private float moveTime;

    public enum EnemyState
    {
        IDLE = 1, //기본상태 
        MOVE = 2, //걷기상태
        RUN = 3, //뛰는상태
        CHASE = 4, //쫓는상태
        QUESTION = 5 //관심을 가진 상태
    }

    EnemyState _state;


    void SetIdleState()
    {
        _state = EnemyState.IDLE;
    }

    void SetRunState()
    {
        _state = EnemyState.RUN;
    }

    void SetChaseState()
    {
        _state = EnemyState.CHASE;
    }

    void SetMoveState()
    {
        _state = EnemyState.MOVE;
    }

    private void Start()
    {
        SetRotateTimer();

        SetIdleState();
    }

    private void Update()
    {
        rotateTime -= Time.deltaTime;  //받아온 랜덤한 값에서 시간을 빼고,

        if (_state == EnemyState.IDLE && rotateTime == 0)
        {
            //특정 각도만큼 회전시키는 코드 작성  //특정 각도만큼 적을 회전시킨다

            SetRotateTimer();  //반복
        }
    }

    void SetRotateTimer()
    {
        rotateTime = Random.Range(5f, 8f); //5초에서 8초 사이 랜덤한 값을 받는다
    }

}
