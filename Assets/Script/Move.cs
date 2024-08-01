using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private Vector3 Velocity;           //移動方向
    private float MoveSpeed = 5.0f;     //移動速度

    // Update is called once per frame
    void Update()
    {
        //WASD入力から、XZ平面を移動する方向を得ます
        Velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            Velocity.z += 1;
        if (Input.GetKey(KeyCode.A))
            Velocity.x -= 1;
        if (Input.GetKey(KeyCode.S))
            Velocity.z -= 1;
        if (Input.GetKey(KeyCode.D))
            Velocity.x += 1;

        //速度ベクトルの長さを１秒でMoveSpeedだけ進むように調整します
        Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime;

        //いずれかの方向に移動している場合
        if(Velocity.magnitude>0)
        {
            //プレイヤーの位置(transform.position)の更新
            //移動方向ベクトルを足しこみます
            transform.position += Velocity;
        }
    }
}
