using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
	private Vector3 Velocity;                                   //移動方向
	[SerializeField, Range(0, 1)] float MoveSpeed = 0.0f;       //移動速度
	[SerializeField] private float Acceleration;                //加速度
	[SerializeField] private Vector3 InitialVelocity;           //初速度
	private float ApplySpeed = 0.1f;                            //回転の適用速度
	private PlayerFollow RefCamera;                             //カメラの水平回転を参照する
	private Rigidbody _rigidbody;                               //Rigidbodyを参照
	private Transform _transform;
	private Animator _animator;
	[SerializeField] private float MaxSpeed = 7.0f;             //速度の上限値
	[SerializeField] private float AddSpeed = 0.03f;            //加速値
	[SerializeField] private float SubSpeed = 0.05f;            //減速値

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

		//スティック操作をしているかどうか
		if ((lsh != 0) || (lsv != 0))
		{
			//スティックを上に倒したとき
			if (lsv > 0)
			{
				// [nagashima]
				// rigidbody と addforce を使う方法
				//_rigidbody.AddForce(0, 0, Acceleration * Time.deltaTime);

				//加速度の時間積分から速度を求める
				Velocity.z += Acceleration * Time.deltaTime;

				//速度の時間積分から位置を求める
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //加速させる
				}
				bSpeedUp_z = true;
            }
            else if (lsv == 0)
			{
				bSpeedUp_z = false;
			}

			//スティックを下に倒したとき
			if (lsv < 0)
			{
				//加速度の時間積分から速度を求める
				Velocity.z -= Acceleration * Time.deltaTime;
				//速度の時間積分から位置を求める
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //加速させる
				}
				bSpeedUp_z = true;
			}
			else if (lsv == 0)
			{
				bSpeedUp_z = false;
			}

			//スティックを右に倒したとき
			if (lsh < 0)
			{
				//加速度の時間積分から速度を求める
				Velocity.x -= Acceleration * Time.deltaTime;
				//速度の時間積分から位置を求める
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //加速させる
				}
				bSpeedUp_x = true;
			}
			else if (lsh == 0)
			{
				bSpeedUp_x = false;
			}

			//スティックを左に倒したとき
			if (lsh > 0)
			{
				//加速度の時間積分から速度を求める
				Velocity.x += Acceleration * Time.deltaTime;
				//速度の時間積分から位置を求める
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //加速させる
				}
				bSpeedUp_x = true;
			}
			else if (lsh == 0)
			{
				bSpeedUp_x = false;
			}
		}

		//L_Stick操作をしていない場合
		else if ((dph != 0) || (dpv != 0))
		{
			//十字上を押したとき
			if (dpv > 0)
			{
				// [nagashima]
				// rigidbody と addforce を使う方法
				//_rigidbody.AddForce(0, 0, Acceleration * Time.deltaTime);

				//加速度の時間積分から速度を求める
				Velocity.z += Acceleration * Time.deltaTime;

				//速度の時間積分から位置を求める
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //加速させる
				}
				bSpeedUp_z = true;
			}
			else if (dpv == 0)
			{
				bSpeedUp_z = false;
			}

			//十字下を押したとき
			if (dpv < 0)
			{
				//加速度の時間積分から速度を求める
				Velocity.z -= Acceleration * Time.deltaTime;
				//速度の時間積分から位置を求める
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //加速させる
				}
				bSpeedUp_z = true;
			}
			else if (dpv == 0)
			{
				bSpeedUp_z = false;
			}

			//十字右を押したとき
			if (dph < 0)
			{
				//加速度の時間積分から速度を求める
				Velocity.x -= Acceleration * Time.deltaTime;
				//速度の時間積分から位置を求める
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //加速させる
				}
				bSpeedUp_x = true;
			}
			else if (dph == 0)
			{
				bSpeedUp_x = false;
			}

			//十字左を押したとき
			if (dph > 0)
			{
				//加速度の時間積分から速度を求める
				Velocity.x += Acceleration * Time.deltaTime;
				//速度の時間積分から位置を求める
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //加速させる
				}
				bSpeedUp_x = true;
			}
			else if (dph == 0)
			{
				bSpeedUp_x = false;
			}
		}

		//L＿Stick操作もD＿Pad操作もをしていない場合
		else
		{
			//十字キー入力から、XZ平面を移動する方向を得ます

			//上方向に加減速させる
			if (Input.GetKey(KeyCode.UpArrow))
			{
				//加速度の時間積分から速度を求める
				Velocity.z += Acceleration * Time.deltaTime;
				//速度の時間積分から位置を求める
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //加速させる
				}
				bSpeedUp_z = true;
			}
			else if (Input.GetKeyUp(KeyCode.UpArrow))
			{
				bSpeedUp_z = false;
			}

			//左方向に加減速させる
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				//加速度の時間積分から速度を求める
				Velocity.x -= Acceleration * Time.deltaTime;
				//速度の時間積分から位置を求める
				transform.position -= Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //加速させる
				}
				bSpeedUp_x = true;
			}
			else if (Input.GetKeyUp(KeyCode.LeftArrow))
			{
				bSpeedUp_x = false;
			}

			//下方向に加減速させる
			if (Input.GetKey(KeyCode.DownArrow))
			{
				//加速度の時間積分から速度を求める
				Velocity.z -= Acceleration * Time.deltaTime;
				//速度の時間積分から位置を求める
				transform.position -= Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //加速させる
				}
				bSpeedUp_z = true;
			}
			else if (Input.GetKeyUp(KeyCode.DownArrow))
			{
				bSpeedUp_z = false;
			}

			//右方向に加減速させる
			if (Input.GetKey(KeyCode.RightArrow))
			{
				//加速度の時間積分から速度を求める
				Velocity.x += Acceleration * Time.deltaTime;
				//速度の時間積分から位置を求める
				transform.position += Velocity * Time.deltaTime;
				if (MoveSpeed < MaxSpeed)
				{
					MoveSpeed += AddSpeed;    //加速させる
				}
				bSpeedUp_x = true;
			}
			else if (Input.GetKeyUp(KeyCode.RightArrow))
			{
				bSpeedUp_x = false;
			}
		}

		//bSpeedUpがfalseであれば減速させる
		if (bSpeedUp_z == false && bSpeedUp_x == false && MoveSpeed > 0.0f)
		{
			MoveSpeed = Mathf.Max(MoveSpeed - SubSpeed, 0.0f);
		}

		//速度ベクトルの長さを１秒でMoveSpeedだけ進むように調整します
		Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime;

		//いずれかの方向に移動している場合
		if (Velocity.magnitude > 0.0f)
		{
			_animator.SetBool("Run", true); ;

			//プレイヤーの回転(transform.rotation)の更新
			//無回転状態のプレイヤーのZ+方向(後頭部)を
			//カメラの水平回転(RefCamera.Hrotation)で回した移動の反対方向(-Velocity)に回す回転に段々近づけます
			transform.rotation = Quaternion.Slerp(transform.rotation,
												  Quaternion.LookRotation(RefCamera.Hrotation * Velocity),
												  ApplySpeed);

			//プレイヤーの位置(transform.position)の更新
			//カメラの水平回転(RefCamera.Hrotation)で回した移動方向(Velocity)を足しこみます
			transform.position += RefCamera.Hrotation * Velocity;
		}
		else
		{
            _animator.SetBool("Run", false);
        }
	}
}
