using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMove : MonoBehaviour
{
    private float[] fVectorZ = { -0.05f, -0.01f, -0.005f };  //�P���A�T���A10���̏ꍇ�̈ړ��ʂ̔z��
    private int[] iIVXMinute = { 1, 5, 10 };//���݂̎��v�������ݒ�Ȃ̂����f�o�b�O���O�ɕ\�������邽�߂̔z��

    //����ɂ����鎞�Ԃ��P���ɂ������Ƃ��͂O�����A
    //�T���̎��͂P�����A10���̎��͂Q����
    private int TimeNum = 0;            //����ɂ����鎞�Ԃ�ς��邽�߂̕ϐ�
    private bool MoningNight = true;    //����̃t���O
    public GameObject particleObject;   //transform.Rotate��Z���W���擾���邽�߂̂���


    void Start()
    {
        //���݂̎��v�������ݒ�Ȃ̂����f�o�b�O���O�ɕ\��������
        Debug.Log(iIVXMinute[TimeNum] + "���łP�����鎞�v");
    }


    void Update()
    {
        //Z���W���ړ�����������
        transform.Rotate(new Vector3(0, 0, fVectorZ[TimeNum]));

        //Z���W�iRotation�j��0�`-180�̊Ԃ�true(��)�A�P�`180�̊Ԃ�false�i��j
        if (gameObject.transform.localEulerAngles.z <= 180 && MoningNight == true && gameObject.transform.localEulerAngles.z != 0)
        {
            MoningNight = false;
            Debug.Log("��");
        }

        if (gameObject.transform.localEulerAngles.z <= 0)
        {
            MoningNight = true;
            Debug.Log("��");
        }
    }
}
