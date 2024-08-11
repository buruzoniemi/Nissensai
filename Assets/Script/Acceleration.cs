using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    //加速度
    [SerializeField] private Vector3 _acceleration;

    //初速度
    [SerializeField] private Vector3 _initialVelocity;

    //現在速度
    private Vector3 _velocity;

    void Start()
    {
        //初速度で初期化
        _velocity = _initialVelocity;
    }

    void Update()
    {
        //加速度の時間積分から速度を求める
        _velocity += _acceleration * Time.deltaTime;

        //速度の時間積分から位置を求める
        transform.position += _velocity*Time.deltaTime;
    }
}
