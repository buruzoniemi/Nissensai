using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine;

public class PullUpAnimation : MonoBehaviour
{
    private Animator p_animator;
    void Start()
    {
        p_animator = GetComponent<Animator>();
    }

    private float FlagSec = 0;
    private float GetSec = 0;
    public bool Finish = false; //アニメーションを行ったかどうかのフラグ

    void Update()
    {
        //Fnishがtureになったら五秒後にfalseに戻す処理
        FlagSec += Time.deltaTime;
        if (Finish == true)
        {
            if (FlagSec >= 4f)
            {

                p_animator.SetBool("PullUp", false);
                p_animator.SetBool("Lift", false);

                Finish = false;

                FlagSec = 0;

            }
        }
    }


    //触ったオブジェクトのタグがカブだった時スペースを押すと、
    //引っこ抜くアニメーションを再生させる関数
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("vegetable"))
        {

            if (Input.GetKey(KeyCode.Space) || (Input.GetKey(KeyCode.Joystick1Button1)))//キーボードとゲームパッドに対応
            {
                p_animator.SetBool("PullUp", true);
                p_animator.SetBool("Lift", true);

                SoundManager.Instance.PlaySE(SESoundData.SE.PullUp);        //獲得した時のポンという音
                SoundManager.Instance.PlaySE(SESoundData.SE.Drumroll);      //ドラムロール

                //獲得した時のSE、頭に2.4秒くらい間を空けると丁度良い
                //一等の条件式
                
                SoundManager.Instance.PlaySE(SESoundData.SE.Get1);      //2.4秒の間隔空け済み

                //一等がなっている時に流す拍手
                //SoundManager.Instance.PlaySE(SESoundData.SE.Hakusyu);      //2.4まだ


                //二等の条件式
                //SoundManager.Instance.PlaySE(SESoundData.SE.Get2);    //2.4まだ


                //三等の条件式
                //SoundManager.Instance.PlaySE(SESoundData.SE.Get3);    //2.4まだ


                //四等の条件式
                //SoundManager.Instance.PlaySE(SESoundData.SE.Get4);    //2.4まだ



                //animatorがtrueになったらFinishもtrueを入れる
                Finish = true;
            }
            else if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                p_animator.SetBool("PullUp", true);
                p_animator.SetBool("Lift", true);

                //animatorがtrueになったらFinishもtrueを入れる
                Finish = true;
            }
        }
    }
}
