using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 Velocity;                           //移動方向
    private float MoveSpeed = 0.0f;                     //移動速度
    [SerializeField] private float Acceleration;        //加速度
    [SerializeField] private Vector3 InitialVelocity;   //初速度
    private float ApplySpeed = 0.1f;                    //回転の適用速度
    private PlayerFollow RefCamera;                     //カメラの水平回転を参照する
    private Rigidbody Rigdbody;                         //Rigidbodyを参照
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
        //WASD入力から、XZ平面を移動する方向を得ます
        if (Input.GetKey(KeyCode.W))
        {
            //加速度の時間積分から速度を求める
            Velocity.z += Acceleration * Time.deltaTime;
            //速度の時間積分から位置を求める
            transform.position += Velocity * Time.deltaTime;
            if (MoveSpeed < MaxSpeed)
            {
                MoveSpeed += AddSpeed;    //加速させる
            }
            bSpeedUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            bSpeedUp = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //加速度の時間積分から速度を求める
            Velocity.x -= Acceleration * Time.deltaTime;
            //速度の時間積分から位置を求める
            transform.position -= Velocity * Time.deltaTime;
            if (MoveSpeed < MaxSpeed)
            {
                MoveSpeed += AddSpeed;    //加速させる
            }
            bSpeedUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            bSpeedUp = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //加速度の時間積分から速度を求める
            Velocity.z -= Acceleration * Time.deltaTime;
            //速度の時間積分から位置を求める
            transform.position -= Velocity * Time.deltaTime;
            if (MoveSpeed < MaxSpeed)
            {
                MoveSpeed += AddSpeed;    //加速させる
            }
            bSpeedUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            bSpeedUp = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //加速度の時間積分から速度を求める
            Velocity.x += Acceleration * Time.deltaTime;
            //速度の時間積分から位置を求める
            transform.position += Velocity * Time.deltaTime;
            if (MoveSpeed < MaxSpeed)
            {
                MoveSpeed += AddSpeed;    //加速させる
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

        //速度ベクトルの長さを１秒でMoveSpeedだけ進むように調整します
        Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime;

        //いずれかの方向に移動している場合
        if (Velocity.magnitude > 0)
        {
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
    }
}
