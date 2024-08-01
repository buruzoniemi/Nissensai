using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField]private Transform Player;          // �����Ώۃv���C���[

    private float Distance = 15.0f;    // �����Ώۃv���C���[����J�����𗣂�����
    private Quaternion Vrotation;      // �J�����̐�����](�����낵��])
    private Quaternion Hrotation;      // �J�����̐�����]

    void Start()
    {
        //��]�̏�����
        Vrotation = Quaternion.Euler(30, 0, 0);         // ������](X�������Ƃ����])�́A30�x�����낷��]
        Hrotation = Quaternion.identity;                // ������](Y�������Ƃ����])�́A����]
        transform.rotation = Hrotation * Vrotation;     // �ŏI�I�ȃJ�����̉�]�́A������]���Ă��琅����]���鍇����]

        //�ʒu�̏�����
        //player�ʒu���狗��distance������O�Ɉ������ʒu��ݒ肵�܂�
        transform.position = Player.position - transform.rotation * Vector3.forward * Distance;
    }

    void Update()
    {
        //�J�����̈ʒu(transform.position)�̍X�V
        //player�̈ʒu���狗��distance������O�Ɉ������ʒu��ݒ肵�܂�
        transform.position = Player.position - transform.rotation * Vector3.forward * Distance;
    }
}