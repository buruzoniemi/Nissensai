using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform Player;  //注視対象プレイヤー
    private float Distance = 23.0f;             //注視対象プレイヤーからカメラを離す距離
    private Quaternion Vrotation;               //カメラの垂直回転(見下ろし回転)

    void Start()
    {
        //垂直回転(X軸を軸とする回転)は、90度見下ろす回転
        Vrotation = Quaternion.Euler(90, 0, 0);

        //player位置から距離distanceだけ手前に引いた位置を設定します
        transform.position = Player.position - transform.rotation * Vector3.forward * Distance;
    }
}