using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;


public class PullUpAnimation : MonoBehaviour
{
    private Animator p_animator;
    void Start()
    {
        p_animator = GetComponent<Animator>();
    }

    private float sec = 0;
    public bool Finish = false; //アニメーションを行ったかどうかのフラグ

    void Update()
    {
        //Fnishがtureになったら五秒後にfalseに戻す処理
        sec += Time.deltaTime;
        if (Finish == true)
        {
            if (sec >= 5f)
            {

                p_animator.SetBool("PullUp", false);
                p_animator.SetBool("Lift", false);

            
                Finish = false;

                sec = 0;

            }
        }
         
    }

    //触ったオブジェクトのタグがカブだった時スペースを押すと、
    //引っこ抜くアニメーションを再生させる関数
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("kabu"))
        {
            if (Input.GetKey(KeyCode.Space) || (Input.GetKey(KeyCode.Joystick1Button1)))//キーボードとゲームパッドに対応
            {
                p_animator.SetBool("PullUp", true);
                p_animator.SetBool("Lift", true);

                //animatorがtrueになったらFinishもtrueを入れる
                Finish = true;
            }
            else if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                p_animator.SetBool("PullUp", true);
                p_animator.SetBool("Lift", true);

                //animatorがtrueになったらFinishもtrueを入れる
                Fnish = true;
            }
        }
    }
}
