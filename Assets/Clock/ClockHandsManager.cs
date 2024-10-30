using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMove : MonoBehaviour
{
    [SerializeField] private int TimeNum = 10;            //����ɂ����鎞�Ԃ�ς��邽�߂̕ϐ��A�P�ʂ� �� �B
   
    private float TimeCalculate = 0;    //�^�C�}�[�̌v�Z�Ɏg���l��n���ϐ�
    private bool MoningNight = true;    //����̃t���O
    public GameObject particleObject;   //transform.Rotate��Z���W���擾���邽�߂̂���

    public Material[] sky;
    int num = 0; 


    void Start()
    {
        // VSyncCount �� Dont Sync �ɕύX
        QualitySettings.vSyncCount = 0;

        //60fps��ڕW�ɐݒ�
        Application.targetFrameRate = 60;

        //���݂̎��v�������ݒ�Ȃ̂����f�o�b�O���O�ɕ\��������
        //Debug.Log(TimeNum + "���łP�����鎞�v");

        //�t���O�����̏�Ԃ̂��Ƃ�1�x�����\��
        if (MoningNight == true)
        {
            //Debug.Log("��");
        }

        //TimeNum�ɓ��͂��ꂽ�l��
        TimeCalculate = -1.0f / (TimeNum * 10.0f);
    }


    void Update()
    {
        
        //Z���W���ړ�����������
        transform.Rotate(new Vector3(0, 0, TimeCalculate));


        //Z���W�iRotation�j��0�`-180�̊Ԃ�true(��)�A�P�`180�̊Ԃ�false�i��j
        if (gameObject.transform.localEulerAngles.z <= 180 && MoningNight == true && gameObject.transform.localEulerAngles.z != 0)
        {

            num = 1;


            MoningNight = false;
            //Debug.Log("��");
        }

        if (gameObject.transform.localEulerAngles.z <= 0)
        {
            num = 0;

            MoningNight = true;
            //Debug.Log("��");
        }

        RenderSettings.skybox = sky[num];
    }
}
