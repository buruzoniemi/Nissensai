using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Vector3 Velocity;                           //移動方向
    private float MoveSpeed = 0.0f;                     //移動速度
    [SerializeField] private float Acceleration;        //加速度
    [SerializeField] private Vector3 InitialVelocity;   //初速度
    private float ApplySpeed = 0.1f;                    //回転の適用速度
    private PlayerFollow RefCamera;                     //カメラの水平回転を参照する
    private Rigidbody _rigidbody;                        //Rigidbodyを参照
    private Transform _transform;
    private Animator _animator;
    private bool bSpeedUp = false;
    [SerializeField] private float MaxSpeed = 7.0f;     //速度の上限値
    [SerializeField] private float AddSpeed = 0.05f;    //加速値
    [SerializeField] private float SubSpeed = 0.05f;    //減速値

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
        //WASD入力から、XZ平面を移動する方向を得ます

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
            bSpeedUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            bSpeedUp = false;
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
            bSpeedUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            bSpeedUp = false;
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
            bSpeedUp = true;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            bSpeedUp = false;
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

        //速度ベクトルの長さを１秒でMoveSpeedだけ進むように調整します
        Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime;
        

        //いずれかの方向に移動している場合
        if (Velocity.magnitude > 0.0f)
        {
            //アニメーションを"walking"にする
            _animator.SetBool("walking", true);

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
            //移動速度が0.0f以下であければ"walking"をやめる
            _animator.SetBool("walking", false);
        }
    }
}
