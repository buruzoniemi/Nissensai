using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;          // 注視対象プレイヤー

    private float Distance = 10.0f;     // 注視対象プレイヤーからカメラを離す距離
    private float TurnSpeed = 7.5f;     //回転速度

    //合成回転を行うためQuaternionで制御する
    private Quaternion Vrotation;       // カメラの垂直回転(見下ろし回転)
    public Quaternion Hrotation;        // カメラの水平回転

    void Start()
    {
        //回転の初期化
        Vrotation = Quaternion.Euler(60, 0, 0);         // 垂直回転(X軸を軸とする回転)は、45度見下ろす回転
        Hrotation = Quaternion.identity;                // 水平回転(Y軸を軸とする回転)は、無回転
        transform.rotation = Hrotation * Vrotation;     // 最終的なカメラの回転は、垂直回転してから水平回転する合成回転

        //位置の初期化
        //player位置から距離distanceだけ手前に引いた位置を設定します
        transform.position = Player.position - transform.rotation * Vector3.forward * Distance;
    }

    void Update()
    {
        // マウスを使用した水平回転の更新
        if (Input.GetMouseButton(0))
        {
            Hrotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * TurnSpeed, 0);
        }

        // カメラの回転(transform.rotation)の更新
        // 方法1 : 垂直回転してから水平回転する合成回転とします
        transform.rotation = Hrotation * Vrotation;

        // カメラの位置(transform.position)の更新
        // player位置から距離distanceだけ手前に引いた位置を設定します
        transform.position = Player.position + new Vector3(0, 3, 0) - transform.rotation * Vector3.forward * Distance;
    }
}