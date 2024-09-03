using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;          // �����Ώۃv���C���[

    private float Distance = 10.0f;     // �����Ώۃv���C���[����J�����𗣂�����
    private float TurnSpeed = 7.5f;     //��]���x

    //������]���s������Quaternion�Ő��䂷��
    private Quaternion Vrotation;       // �J�����̐�����](�����낵��])
    public Quaternion Hrotation;        // �J�����̐�����]

    void Start()
    {
        //��]�̏�����
        Vrotation = Quaternion.Euler(60, 0, 0);         // ������](X�������Ƃ����])�́A45�x�����낷��]
        Hrotation = Quaternion.identity;                // ������](Y�������Ƃ����])�́A����]
        transform.rotation = Hrotation * Vrotation;     // �ŏI�I�ȃJ�����̉�]�́A������]���Ă��琅����]���鍇����]

        //�ʒu�̏�����
        //player�ʒu���狗��distance������O�Ɉ������ʒu��ݒ肵�܂�
        transform.position = Player.position - transform.rotation * Vector3.forward * Distance;
    }

    void Update()
    {
        // �}�E�X���g�p����������]�̍X�V
        if (Input.GetMouseButton(0))
        {
            Hrotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * TurnSpeed, 0);
        }

        // �J�����̉�](transform.rotation)�̍X�V
        // ���@1 : ������]���Ă��琅����]���鍇����]�Ƃ��܂�
        transform.rotation = Hrotation * Vrotation;

        // �J�����̈ʒu(transform.position)�̍X�V
        // player�ʒu���狗��distance������O�Ɉ������ʒu��ݒ肵�܂�
        transform.position = Player.position + new Vector3(0, 3, 0) - transform.rotation * Vector3.forward * Distance;
    }
}