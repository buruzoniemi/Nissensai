using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Net;
using UnityEngine;


=======
using UnityEngine;

>>>>>>> 31613564 (引っこ抜くアニメーションを作りました。問題点も確認できていたものはすべて解決しました。)
public class PullUpAnimation : MonoBehaviour
{
    private Animator p_animator;
    void Start()
    {
        p_animator = GetComponent<Animator>();
    }

    private float sec = 0;
<<<<<<< HEAD
    public bool Finish = false; //�A�j���[�V�������s�������ǂ����̃t���O
=======
    private bool Fnish = false; //�A�j���[�V�������s�������ǂ����̃t���O
>>>>>>> 31613564 (引っこ抜くアニメーションを作りました。問題点も確認できていたものはすべて解決しました。)

    void Update()
    {
        //Fnish��ture�ɂȂ�����ܕb���false�ɖ߂�����
        sec += Time.deltaTime;
<<<<<<< HEAD
        if (Finish == true)
=======
        if (Fnish = true)
>>>>>>> 31613564 (引っこ抜くアニメーションを作りました。問題点も確認できていたものはすべて解決しました。)
        {
            if (sec >= 5f)
            {

                p_animator.SetBool("PullUp", false);
                p_animator.SetBool("Lift", false);

<<<<<<< HEAD
            
                Finish = false;

                sec = 0;

            }
        }
         
=======
                sec = 0;
            }
        }
>>>>>>> 31613564 (引っこ抜くアニメーションを作りました。問題点も確認できていたものはすべて解決しました。)
    }

    //�G�����I�u�W�F�N�g�̃^�O���J�u���������X�y�[�X�������ƁA
    //�����������A�j���[�V�������Đ�������֐�
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("kabu"))
        {
<<<<<<< HEAD
            if (Input.GetKey(KeyCode.Space) || (Input.GetKey(KeyCode.Joystick1Button1)))//�L�[�{�[�h�ƃQ�[���p�b�h�ɑΉ�
=======
            if (Input.GetKey(KeyCode.Space))
>>>>>>> 31613564 (引っこ抜くアニメーションを作りました。問題点も確認できていたものはすべて解決しました。)
            {
                p_animator.SetBool("PullUp", true);
                p_animator.SetBool("Lift", true);

                //animator��true�ɂȂ�����Finish��true������
<<<<<<< HEAD
                Finish = true;
=======
                Fnish = true;
>>>>>>> 31613564 (引っこ抜くアニメーションを作りました。問題点も確認できていたものはすべて解決しました。)
            }
            else if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                p_animator.SetBool("PullUp", true);
                p_animator.SetBool("Lift", true);

                //animator��true�ɂȂ�����Finish��true������
                Fnish = true;
            }
        }
    }
}
