using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float rotateTime;

    public enum EnemyState
    {
        IDLE = 1, //�⺻���� 
        MOVE = 2, //�ȱ����
        RUN = 3, //�ٴ»���
        CHASE = 4, //�Ѵ»���
        QUESTION = 5 //������ ���� ����
    }

    EnemyState _state;

    private void Start()
    {
        SetRotateTimer();

        _state = EnemyState.IDLE;
    }

    private void Update()
    {
        rotateTime -= Time.deltaTime;  //�޾ƿ� ������ ������ �ð��� ����,

        if(_state == EnemyState.IDLE)
        {
            if(rotateTime == 0)  //���� �پ� 0�� �Ǿ��� �� 
            {
                //Ư�� ������ŭ ȸ����Ű�� �ڵ� �ۼ�  //Ư�� ������ŭ ���� ȸ����Ų��

                SetRotateTimer();  //�ݺ�
            }
        }
    }

    void SetRotateTimer()
    {
        rotateTime = Random.Range(5f, 8f); //5�ʿ��� 8�� ���� ������ ���� �޴´�
    }
}
