using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
	private Vector3 Velocity;                                   //�ړ�����
	[SerializeField, Range(0, 1)] float MoveSpeed = 0.0f;       //�ړ����x
	[SerializeField] private float Acceleration;                //�����x
	[SerializeField] private Vector3 InitialVelocity;           //�����x
	private float ApplySpeed = 0.1f;                            //��]�̓K�p���x
	private PlayerFollow RefCamera;                             //�J�����̐�����]���Q�Ƃ���
	private Rigidbody _rigidbody;                               //Rigidbody���Q��
	private Transform _transform;
	private Animator _animator;
	[SerializeField] private float MaxSpeed = 7.0f;             //���x�̏���l
	[SerializeField] private float AddSpeed = 0.03f;            //�����l
	[SerializeField] private float SubSpeed = 0.05f;            //�����l

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
		bool bSpeedUp_z = false;
		bool bSpeedUp_x = false;

		//L Stick
		float lsh = Input.GetAxis("L_Stick_H");
		float lsv = Input.GetAxis("L_Stick_V");
		//D_Pad
		float dph = Input.GetAxis("D_Pad_H");
		float dpv = Input.GetAxis("D_Pad_V");

		//�X�e�B�b�N��������Ă��邩�ǂ���
		if ((lsh != 0) || (lsv != 0))
		{
			//�X�e�B�b�N����ɓ|�����Ƃ�
			if (lsv > 0)
			{
				// [nagashima]
				// rigidbody �� addforce ���g�����@
				//_rigidbody.AddForce(0, 0, Acceleration * Time.deltaTime);

				//�����x�̎��Ԑϕ����瑬�x�����߂�
				Velocity.z += Acceleration * Time.deltaTime;

				//���x�̎��Ԑϕ�����ʒu�����߂�
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //����������
				}
				bSpeedUp_z = true;
            }
            else if (lsv == 0)
			{
				bSpeedUp_z = false;
			}

			//�X�e�B�b�N�����ɓ|�����Ƃ�
			if (lsv < 0)
			{
				//�����x�̎��Ԑϕ����瑬�x�����߂�
				Velocity.z -= Acceleration * Time.deltaTime;
				//���x�̎��Ԑϕ�����ʒu�����߂�
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //����������
				}
				bSpeedUp_z = true;
			}
			else if (lsv == 0)
			{
				bSpeedUp_z = false;
			}

			//�X�e�B�b�N���E�ɓ|�����Ƃ�
			if (lsh < 0)
			{
				//�����x�̎��Ԑϕ����瑬�x�����߂�
				Velocity.x -= Acceleration * Time.deltaTime;
				//���x�̎��Ԑϕ�����ʒu�����߂�
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //����������
				}
				bSpeedUp_x = true;
			}
			else if (lsh == 0)
			{
				bSpeedUp_x = false;
			}

			//�X�e�B�b�N�����ɓ|�����Ƃ�
			if (lsh > 0)
			{
				//�����x�̎��Ԑϕ����瑬�x�����߂�
				Velocity.x += Acceleration * Time.deltaTime;
				//���x�̎��Ԑϕ�����ʒu�����߂�
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //����������
				}
				bSpeedUp_x = true;
			}
			else if (lsh == 0)
			{
				bSpeedUp_x = false;
			}
		}

		//L_Stick��������Ă��Ȃ��ꍇ
		else if ((dph != 0) || (dpv != 0))
		{
			//�\������������Ƃ�
			if (dpv > 0)
			{
				// [nagashima]
				// rigidbody �� addforce ���g�����@
				//_rigidbody.AddForce(0, 0, Acceleration * Time.deltaTime);

				//�����x�̎��Ԑϕ����瑬�x�����߂�
				Velocity.z += Acceleration * Time.deltaTime;

				//���x�̎��Ԑϕ�����ʒu�����߂�
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //����������
				}
				bSpeedUp_z = true;
			}
			else if (dpv == 0)
			{
				bSpeedUp_z = false;
			}

			//�\�������������Ƃ�
			if (dpv < 0)
			{
				//�����x�̎��Ԑϕ����瑬�x�����߂�
				Velocity.z -= Acceleration * Time.deltaTime;
				//���x�̎��Ԑϕ�����ʒu�����߂�
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //����������
				}
				bSpeedUp_z = true;
			}
			else if (dpv == 0)
			{
				bSpeedUp_z = false;
			}

			//�\���E���������Ƃ�
			if (dph < 0)
			{
				//�����x�̎��Ԑϕ����瑬�x�����߂�
				Velocity.x -= Acceleration * Time.deltaTime;
				//���x�̎��Ԑϕ�����ʒu�����߂�
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //����������
				}
				bSpeedUp_x = true;
			}
			else if (dph == 0)
			{
				bSpeedUp_x = false;
			}

			//�\�������������Ƃ�
			if (dph > 0)
			{
				//�����x�̎��Ԑϕ����瑬�x�����߂�
				Velocity.x += Acceleration * Time.deltaTime;
				//���x�̎��Ԑϕ�����ʒu�����߂�
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //����������
				}
				bSpeedUp_x = true;
			}
			else if (dph == 0)
			{
				bSpeedUp_x = false;
			}
		}

		//L�QStick�����D�QPad����������Ă��Ȃ��ꍇ
		else
		{
			//�\���L�[���͂���AXZ���ʂ��ړ���������𓾂܂�

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
				bSpeedUp_z = true;
			}
			else if (Input.GetKeyUp(KeyCode.UpArrow))
			{
				bSpeedUp_z = false;
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
				bSpeedUp_x = true;
			}
			else if (Input.GetKeyUp(KeyCode.LeftArrow))
			{
				bSpeedUp_x = false;
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
				bSpeedUp_z = true;
			}
			else if (Input.GetKeyUp(KeyCode.DownArrow))
			{
				bSpeedUp_z = false;
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
				bSpeedUp_x = true;
			}
			else if (Input.GetKeyUp(KeyCode.RightArrow))
			{
				bSpeedUp_x = false;
			}
		}

		//bSpeedUp��false�ł���Ό���������
		if (bSpeedUp_z == false && bSpeedUp_x == false && MoveSpeed > 0.0f)
		{
			MoveSpeed = Mathf.Max(MoveSpeed - SubSpeed, 0.0f);
		}

		//���x�x�N�g���̒������P�b��MoveSpeed�����i�ނ悤�ɒ������܂�
		Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime;

		//�����ꂩ�̕����Ɉړ����Ă���ꍇ
		if (Velocity.magnitude > 0.0f)
		{
			_animator.SetBool("Run", true); ;

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
            _animator.SetBool("Run", false);
        }
	}
}
