using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform Player;  //�����Ώۃv���C���[
    private float Distance = 23.0f;             //�����Ώۃv���C���[����J�����𗣂�����
    private Quaternion Vrotation;               //�J�����̐�����](�����낵��])

    void Start()
    {
        //������](X�������Ƃ����])�́A90�x�����낷��]
        Vrotation = Quaternion.Euler(90, 0, 0);

        //player�ʒu���狗��distance������O�Ɉ������ʒu��ݒ肵�܂�
        transform.position = Player.position - transform.rotation * Vector3.forward * Distance;
    }
}