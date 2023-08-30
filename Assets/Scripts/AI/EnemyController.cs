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
        IDLE = 1, //�⺻���� 
        MOVE = 2, //�ȱ����
        RUN = 3, //�ٴ»���
        CHASE = 4, //�Ѵ»���
        QUESTION = 5 //������ ���� ����
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
        rotateTime -= Time.deltaTime;  //�޾ƿ� ������ ������ �ð��� ����,

        if (_state == EnemyState.IDLE && rotateTime == 0)
        {
            //Ư�� ������ŭ ȸ����Ű�� �ڵ� �ۼ�  //Ư�� ������ŭ ���� ȸ����Ų��

            SetRotateTimer();  //�ݺ�
        }
    }

    void SetRotateTimer()
    {
        rotateTime = Random.Range(5f, 8f); //5�ʿ��� 8�� ���� ������ ���� �޴´�
    }

}
