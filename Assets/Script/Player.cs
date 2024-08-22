using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Vector3 Velocity;                           //�ړ�����
    private float MoveSpeed = 0.0f;                     //�ړ����x
    [SerializeField] private float Acceleration;        //�����x
    [SerializeField] private Vector3 InitialVelocity;   //�����x
    private float ApplySpeed = 0.1f;                    //��]�̓K�p���x
    private PlayerFollow RefCamera;                     //�J�����̐�����]���Q�Ƃ���
    private Rigidbody _rigidbody;                        //Rigidbody���Q��
    private Transform _transform;
    private Animator _animator;
    private bool bSpeedUp = false;
    [SerializeField] private float MaxSpeed = 7.0f;     //���x�̏���l
    [SerializeField] private float AddSpeed = 0.05f;    //�����l
    [SerializeField] private float SubSpeed = 0.05f;    //�����l

    private void Start()
    {
        Velocity = InitialVelocity;
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        RefCamera = GameObject.Find("Main Camera").GetComponent<PlayerFollow>();
    }

    void Update()
    {
        //WASD���͂���AXZ���ʂ��ړ���������𓾂܂�

        //������ɉ�����������
        if (Input.GetKey(KeyCode.UpArrow))
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
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            bSpeedUp = false;
        }

        //�������ɉ�����������
        if (Input.GetKey(KeyCode.LeftArrow))
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
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            bSpeedUp = false;
        }

        //�������ɉ�����������
        if (Input.GetKey(KeyCode.DownArrow))
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
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            bSpeedUp = false;
        }

        //�E�����ɉ�����������
        if (Input.GetKey(KeyCode.RightArrow))
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
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            bSpeedUp = false;
        }

        if (bSpeedUp == false && MoveSpeed > 0.0f)
        {
            MoveSpeed -= SubSpeed;

        }

        //���x�x�N�g���̒������P�b��MoveSpeed�����i�ނ悤�ɒ������܂�
        Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime;
        

        //�����ꂩ�̕����Ɉړ����Ă���ꍇ
        if (Velocity.magnitude > 0.0f)
        {
            //�A�j���[�V������"walking"�ɂ���
            _animator.SetBool("walking", true);

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
        else
        {
            //�ړ����x��0.0f�ȉ��ł������"walking"����߂�
            _animator.SetBool("walking", false);
        }
    }
}
