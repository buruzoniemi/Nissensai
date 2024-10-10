using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveScale = 1.0f;  // �ő�ړ����x
    [SerializeField] private float acceleration = 2.0f;  // �����x
    [SerializeField] private float deceleration = 2.0f;  // �������̉����x

    // �v���C���[�̈ړ����x
    [SerializeField, Header("�v���C���[�̈ړ����xX��")] private float m_pMove_X = 1.0f;
    [SerializeField, Header("�v���C���[�̈ړ����xY��")] private float m_pMove_Y = 0.0f;  // �ʏ�͎g�p���Ȃ�
    [SerializeField, Header("�v���C���[�̈ړ����xZ��")] private float m_pMove_Z = 1.0f;

    private Vector3 moveDirection = Vector3.zero;  // �ړ�������ۑ�����ϐ�
    private Vector3 currentVelocity = Vector3.zero;  // ���݂̈ړ����x
    private Rigidbody rigidbody;
    private PlayerRotation playerRotation;  // PlayerRotation �N���X�̃C���X�^���X

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerRotation = GetComponent<PlayerRotation>();  // PlayerRotation �N���X���擾
    }

    void Update()
    {
        // ���͂ɂ��ړ������̍X�V
        Move(m_pMove_X, m_pMove_Y, m_pMove_Z);

        // �����x�ɂ��ړ�����
        ApplyMovement();
    }

    // �ړ��x�N�g�����v�Z
    void Move(float x, float y, float z)
    {
        // �������i�ړ������j
        moveDirection = Vector3.zero;

        // ����L�[���������Ƃ��̏���
        if (InputManager.GetKey(KeyBoard.WKey) || InputManager.GetKey(KeyBoard.UpArrow))
        {
            moveDirection += new Vector3(0, 0, z);
        }
        // �����L�[���������Ƃ��̏���
        if (InputManager.GetKey(KeyBoard.SKey) || InputManager.GetKey(KeyBoard.DownArrow))
        {
            moveDirection += new Vector3(0, 0, -z);
        }
        // �����L�[���������Ƃ��̏���
        if (InputManager.GetKey(KeyBoard.AKey) || InputManager.GetKey(KeyBoard.LeftArrow))
        {
            moveDirection += new Vector3(-x, 0, 0);
        }
        // �E���L�[���������Ƃ��̏���
        if (InputManager.GetKey(KeyBoard.DKey) || InputManager.GetKey(KeyBoard.RightArrow))
        {
            moveDirection += new Vector3(x, 0, 0);
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

        // ���݂̑��x�ƖڕW���x�̊Ԃ���`��Ԃ��āA�����x��K�p
        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity,
                                       (targetVelocity.magnitude > 0) ? acceleration * Time.deltaTime : deceleration * Time.deltaTime);

        // ���ۂɈړ�������iRigidbody���g���Ă���ꍇ��Force��Velocity�ł��ǂ��j
        transform.Translate(currentVelocity * Time.deltaTime, Space.World);

        // ��]������PlayerRotation�N���X�ɈϏ�
        playerRotation.RotatePlayer(currentVelocity);
    }
}