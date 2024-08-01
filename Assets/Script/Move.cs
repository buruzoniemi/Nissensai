using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private Vector3 Velocity;           //�ړ�����
    private float MoveSpeed = 5.0f;     //�ړ����x

    // Update is called once per frame
    void Update()
    {
        //WASD���͂���AXZ���ʂ��ړ���������𓾂܂�
        Velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            Velocity.z += 1;
        if (Input.GetKey(KeyCode.A))
            Velocity.x -= 1;
        if (Input.GetKey(KeyCode.S))
            Velocity.z -= 1;
        if (Input.GetKey(KeyCode.D))
            Velocity.x += 1;

        //���x�x�N�g���̒������P�b��MoveSpeed�����i�ނ悤�ɒ������܂�
        Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime;

        //�����ꂩ�̕����Ɉړ����Ă���ꍇ
        if(Velocity.magnitude>0)
        {
            //�v���C���[�̈ʒu(transform.position)�̍X�V
            //�ړ������x�N�g���𑫂����݂܂�
            transform.position += Velocity;
        }
    }
}
