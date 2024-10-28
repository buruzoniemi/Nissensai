using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveScale;  // �ő�ړ����x
    [SerializeField] private float acceleration;  // �����x
    [SerializeField] private float deceleration;  // �������̉����x

    // �v���C���[�̈ړ����x
    [SerializeField, Header("�v���C���[�̈ړ����xX��")] private float m_pMove_X = 1.0f;
    [SerializeField, Header("�v���C���[�̈ړ����xY��")] private float m_pMove_Y = 0.0f;  // �ʏ�͎g�p���Ȃ�
    [SerializeField, Header("�v���C���[�̈ړ����xZ��")] private float m_pMove_Z = 1.0f;

    private Vector3 moveDirection = Vector3.zero;  // �ړ�������ۑ�����ϐ�
    private Vector3 currentVelocity = Vector3.zero;  // ���݂̈ړ����x
    private Rigidbody rigidbody;
    private PlayerRotation playerRotation;  // PlayerRotation �N���X�̃C���X�^���X
    private PlayerAnimation playerAnimation;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerRotation = GetComponent<PlayerRotation>();  // PlayerRotation �N���X���擾
    }

    void Update()
    {
        // ���͂ɂ��ړ������̍X�V
        Move(m_pMove_X, m_pMove_Y, m_pMove_Z);
        // �����x�ɂ��ړ�����
        ApplyMovement();
        //�����Ă鎞�̃A�j���[�V����
        //RunAnimChange();
        //�X�e�B�b�N�œ��͂���Ă���������擾
    }

    // �ړ��x�N�g�����v�Z
    void Move(float x, float y, float z)
    {
        //������
        moveDirection = Vector3.zero;

        //Lstick
        float lsh = Input.GetAxis("L_Stick_H");     //��������
        float lsv = Input.GetAxis("L_Stick_V");     //��������

        // ����L�[���������Ƃ��̏���
        if (transform.position.z < 10.0f)
        {
            if (InputManager.GetKey(KeyBoard.WKey) || InputManager.GetKey(KeyBoard.UpArrow))
            {
                moveDirection += new Vector3(0, 0, z);
            }
        }
        // �����L�[���������Ƃ��̏���
        if (transform.position.z > -10.0f)
        {
            if (InputManager.GetKey(KeyBoard.SKey) || InputManager.GetKey(KeyBoard.DownArrow))
            {
                moveDirection += new Vector3(0, 0, -z);
            }
        }
        // �����L�[���������Ƃ��̏���
        if (transform.position.x > -10.0f)
        {
            if (InputManager.GetKey(KeyBoard.AKey) || InputManager.GetKey(KeyBoard.LeftArrow))
            {
                moveDirection += new Vector3(-x, 0, 0);
            }
        }
        // �E���L�[���������Ƃ��̏���
        if (transform.position.x < 10.0f)
        {
            if (InputManager.GetKey(KeyBoard.DKey) || InputManager.GetKey(KeyBoard.RightArrow))
            {
                moveDirection += new Vector3(x, 0, 0);
            }
        }

        //�X�e�B�b�N��������Ă��邩�ǂ���
        if ((lsh != 0) || (lsv != 0))
        {
            //Lstick����ɓ|�����Ƃ��̏���
            if (transform.position.z < 10.0f)
            {
                if (lsv > 0)
                {
                    moveDirection += new Vector3(0, 0, z);
                }
            }
            //Lstick�����ɓ|�����Ƃ��̏���
            if (transform.position.z > -10.0f)
            {
                if (lsv < 0)
                {
                    moveDirection += new Vector3(0, 0, -z);
                }
            }
            //Lstick�����ɓ|�����Ƃ��̏���
            if (transform.position.x > -10.0f)
            {
                if (lsh < 0)
                {
                    moveDirection += new Vector3(-x, 0, 0);
                }
            }
            //Lstick���E�ɓ|�����Ƃ��̏���
            if (transform.position.x < 10.0f)
            {
                if (lsh > 0)
                {
                    moveDirection += new Vector3(x, 0, 0);
                }
            }
        }


        // �ړ��x�N�g���𐳋K�����āA�΂߈ړ��ł̑��x�������Ȃ�Ȃ��悤�ɂ���
        if (moveDirection.magnitude > 0.1f)
        {
            moveDirection = moveDirection.normalized;  // ���K��
        }

    }

    // �����x��K�p���Ĉړ������鏈��
    void ApplyMovement()
    {
        // �ڕW���x�� moveDirection �Ɋ�Â��Čv�Z�i�ő呬�x���l���j
        Vector3 targetVelocity = moveDirection * moveScale;

        // �ړ��������[���̏ꍇ�A�����Ɍ���������K�p
        if (targetVelocity.magnitude == 0)
        {
            currentVelocity = Vector3.MoveTowards(currentVelocity, Vector3.zero, deceleration * Time.deltaTime);
            playerAnimation.StopRunAnim();
        }
        else
        {
            // ���݂̑��x�ƖڕW���x�̊Ԃ���`��Ԃ��āA�����x��K�p
            currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, acceleration * Time.deltaTime);
            playerAnimation.RunAnim();
        }

        // ���ۂɈړ�������iRigidbody���g���Ă���ꍇ��Force��Velocity�ł��ǂ��j
        transform.Translate(currentVelocity * Time.deltaTime, Space.World);

        // ��]������PlayerRotation�N���X�ɈϏ�
        playerRotation.RotatePlayer(currentVelocity);
    }
}