using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 Velocity;                           //�ړ�����
    private float MoveSpeed = 0.0f;                     //�ړ����x
    [SerializeField] private float Acceleration;        //�����x
    [SerializeField] private Vector3 InitialVelocity;   //�����x
    private float ApplySpeed = 0.1f;                    //��]�̓K�p���x
    private PlayerFollow RefCamera;                     //�J�����̐�����]���Q�Ƃ���
    private Rigidbody Rigdbody;                         //Rigidbody���Q��
    private bool bSpeedUp = false;
    [SerializeField] private float MaxSpeed = 7.0f;
    [SerializeField] private float AddSpeed = 0.01f;
    [SerializeField] private float SubSpeed = 0.03f;

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
        {
            //�����x�̎��Ԑϕ����瑬�x�����߂�
            Velocity.z += Acceleration * Time.deltaTime;
            //���x�̎��Ԑϕ�����ʒu�����߂�
            transform.position += Velocity * Time.deltaTime;
            if (MoveSpeed < MaxSpeed)
            {
                MoveSpeed += AddSpeed;    //����������
            }
            bSpeedUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            bSpeedUp = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //�����x�̎��Ԑϕ����瑬�x�����߂�
            Velocity.x -= Acceleration * Time.deltaTime;
            //���x�̎��Ԑϕ�����ʒu�����߂�
            transform.position -= Velocity * Time.deltaTime;
            if (MoveSpeed < MaxSpeed)
            {
                MoveSpeed += AddSpeed;    //����������
            }
            bSpeedUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            bSpeedUp = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //�����x�̎��Ԑϕ����瑬�x�����߂�
            Velocity.z -= Acceleration * Time.deltaTime;
            //���x�̎��Ԑϕ�����ʒu�����߂�
            transform.position -= Velocity * Time.deltaTime;
            if (MoveSpeed < MaxSpeed)
            {
                MoveSpeed += AddSpeed;    //����������
            }
            bSpeedUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            bSpeedUp = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //�����x�̎��Ԑϕ����瑬�x�����߂�
            Velocity.x += Acceleration * Time.deltaTime;
            //���x�̎��Ԑϕ�����ʒu�����߂�
            transform.position += Velocity * Time.deltaTime;
            if (MoveSpeed < MaxSpeed)
            {
                MoveSpeed += AddSpeed;    //����������
            }
            bSpeedUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            bSpeedUp = false;
        }

        if (bSpeedUp == false && MoveSpeed > 0)
        {
            MoveSpeed -= SubSpeed;

        }

        //���x�x�N�g���̒������P�b��MoveSpeed�����i�ނ悤�ɒ������܂�
        Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime;

        //�����ꂩ�̕����Ɉړ����Ă���ꍇ
        if (Velocity.magnitude > 0)
        {
            //�v���C���[�̉�](transform.rotation)�̍X�V
            //����]��Ԃ̃v���C���[��Z+����(�㓪��)��
            //�J�����̐�����](RefCamera.Hrotation)�ŉ񂵂��ړ��̔��Ε���(-Velocity)�ɉ񂷉�]�ɒi�X�߂Â��܂�
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(RefCamera.Hrotation * Velocity),
                                                  ApplySpeed);

            //�v���C���[�̈ʒu(transform.position)�̍X�V
            //�J�����̐�����](RefCamera.Hrotation)�ŉ񂵂��ړ�����(Velocity)�𑫂����݂܂�
            transform.position += RefCamera.Hrotation * Velocity;
        }
    }
}
