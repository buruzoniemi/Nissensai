using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 Velocity;                           //�ړ�����
    private float MoveSpeed = 5.0f;                     //�ړ����x
    [SerializeField] private Vector3 Acceleration;      //�����x
    [SerializeField] private Vector3 InitialVelocity;   //�����x
    private float ApplySpeed = 0.1f;                    //��]�̓K�p���x
    private PlayerFollow RefCamera;                     //�J�����̐�����]���Q�Ƃ���
    private Rigidbody Rigdbody;                         //Rigidbody���Q��

    private void Start()
    {
        Velocity = InitialVelocity;
        Rigdbody = GetComponent<Rigidbody>();
        RefCamera = GameObject.Find("Main Camera").GetComponent<PlayerFollow>();
    }

    void Update()
    {
        //WASD���͂���AXZ���ʂ��ړ���������𓾂܂�
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
        if (Velocity.magnitude > 0)
        {
            //�v���C���[�̉�](transform.rotation)�̍X�V
            //����]��Ԃ̃v���C���[��Z+����(�㓪��)��
            //�J�����̐�����](RefCamera.Hrotation)�ŉ񂵂��ړ��̔��Ε���(-Velocity)�ɉ񂷉�]�ɒi�X�߂Â��܂�
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(RefCamera.Hrotation * -Velocity),
                                                  ApplySpeed);

            //�v���C���[�̈ʒu(transform.position)�̍X�V
            //�J�����̐�����](RefCamera.Hrotation)�ŉ񂵂��ړ�����(Velocity)�𑫂����݂܂�
            transform.position += RefCamera.Hrotation * Velocity;
        }
    }
}
