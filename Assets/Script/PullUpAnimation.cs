using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullUpAnimation : MonoBehaviour
{
    private Animator p_animator;
    void Start()
    {
        p_animator = GetComponent<Animator>();
    }

    private float sec = 0;
    private bool Fnish = false; //アニメーションを行ったかどうかのフラグ

    void Update()
    {
        //Fnishがtureになったら五秒後にfalseに戻す処理
        sec += Time.deltaTime;
        if (Fnish = true)
        {
            if (sec >= 5f)
            {

                p_animator.SetBool("PullUp", false);
                p_animator.SetBool("Lift", false);

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
            if (Input.GetKey(KeyCode.Space))
            {
                p_animator.SetBool("PullUp", true);
                p_animator.SetBool("Lift", true);

                //animatorがtrueになったらFinishもtrueを入れる
                Fnish = true;
            }
        }
    }
}
