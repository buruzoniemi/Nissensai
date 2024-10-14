using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    private PlayerAnimation playerAnimation;

    void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

         private void OnTriggerStay(Collider collision)  //ぶつかっている時にスペースを押すと消える命令文の始まり
    {
        Debug.Log(collision.gameObject.name); // ぶつかった相手の名前を取得

        if (collision.gameObject.CompareTag("kabu"))//kabuTagのオブジェクトに触れている時の処理
        {

            if (InputManager.GetKey(KeyBoard.SpaceKey))
            {
                playerAnimation.PlayPullUpAnim();
            }
        }
    }
}
