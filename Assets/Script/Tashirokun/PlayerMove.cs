using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveScale = 1.0f;  // 最大移動速度
    [SerializeField] private float acceleration = 2.0f;  // 加速度
    [SerializeField] private float deceleration = 2.0f;  // 減速時の加速度

    // プレイヤーの移動速度
    [SerializeField, Header("プレイヤーの移動速度X軸")] private float m_pMove_X = 1.0f;
    [SerializeField, Header("プレイヤーの移動速度Y軸")] private float m_pMove_Y = 0.0f;  // 通常は使用しない
    [SerializeField, Header("プレイヤーの移動速度Z軸")] private float m_pMove_Z = 1.0f;

    private Vector3 moveDirection = Vector3.zero;  // 移動方向を保存する変数
    private Vector3 currentVelocity = Vector3.zero;  // 現在の移動速度
    private Rigidbody rigidbody;
    private PlayerRotation playerRotation;  // PlayerRotation クラスのインスタンス

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerRotation = GetComponent<PlayerRotation>();  // PlayerRotation クラスを取得
    }

    void Update()
    {
        // 入力による移動方向の更新
        Move(m_pMove_X, m_pMove_Y, m_pMove_Z);

        // 加速度による移動処理
        ApplyMovement();
    }

    // 移動ベクトルを計算
    void Move(float x, float y, float z)
    {
        // 初期化（移動方向）
        moveDirection = Vector3.zero;

        // 上矢印キーを押したときの処理
        if (InputManager.GetKey(KeyBoard.WKey) || InputManager.GetKey(KeyBoard.UpArrow))
        {
            moveDirection += new Vector3(0, 0, z);
        }
        // 下矢印キーを押したときの処理
        if (InputManager.GetKey(KeyBoard.SKey) || InputManager.GetKey(KeyBoard.DownArrow))
        {
            moveDirection += new Vector3(0, 0, -z);
        }
        // 左矢印キーを押したときの処理
        if (InputManager.GetKey(KeyBoard.AKey) || InputManager.GetKey(KeyBoard.LeftArrow))
        {
            moveDirection += new Vector3(-x, 0, 0);
        }
        // 右矢印キーを押したときの処理
        if (InputManager.GetKey(KeyBoard.DKey) || InputManager.GetKey(KeyBoard.RightArrow))
        {
            moveDirection += new Vector3(x, 0, 0);
        }

        // 移動ベクトルを正規化して、斜め移動での速度が速くならないようにする
        if (moveDirection.magnitude > 0.1f)
        {
            moveDirection = moveDirection.normalized;  // 正規化
        }
    }

    // 加速度を適用して移動させる処理
    void ApplyMovement()
    {
        // 目標速度を moveDirection に基づいて計算（最大速度を考慮）
        Vector3 targetVelocity = moveDirection * moveScale;

        // 現在の速度と目標速度の間を線形補間して、加速度を適用
        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity,
                                       (targetVelocity.magnitude > 0) ? acceleration * Time.deltaTime : deceleration * Time.deltaTime);

        // 実際に移動させる（Rigidbodyを使っている場合はForceやVelocityでも良い）
        transform.Translate(currentVelocity * Time.deltaTime, Space.World);

        // 回転処理をPlayerRotationクラスに委譲
        playerRotation.RotatePlayer(currentVelocity);
    }
}