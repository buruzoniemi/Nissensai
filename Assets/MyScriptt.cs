using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MyScriptt : MonoBehaviour
{            
    private float speed = 3.0f;         //速度

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        //上キー
        if (transform.position.z <= 14.037f)               //プレイヤーがステージ内にいるなら
        {
            if (Input.GetKey(KeyCode.UpArrow))      //上キーを押すと上に進む
            {
                transform.position += speed * transform.forward* Time.deltaTime;
            }
        }

        //下キー
        if (transform.position.z >= -4.899f)               //プレイヤーがステージ内にいるなら
        {
            if (Input.GetKey(KeyCode.DownArrow))    //下キーを押すと下に進む
            {
                transform.position -= speed * transform.forward * Time.deltaTime;
            }
        }

        //右キー
        if (transform.position.x <= 15.539f)               //プレイヤーがステージ内にいるなら
        {
            if (Input.GetKey(KeyCode.RightArrow))   //右キーを押すと右に進む
            {
                transform.position += speed * transform.right * Time.deltaTime;
            }
        }

        //左キー
        if (transform.position.x >= -3.299f)               //プレイヤーがステージ内にいるなら
        {
            if (Input.GetKey(KeyCode.LeftArrow))    //左キーを押すと左に進む
            {
                transform.position -= speed * transform.right * Time.deltaTime;
            }
        }
    }
}
