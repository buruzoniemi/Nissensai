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
    public bool Finish = false; //�A�j���[�V�������s�������ǂ����̃t���O

    void Update()
    {
        //Fnish��ture�ɂȂ�����ܕb���false�ɖ߂�����
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


    //�G�����I�u�W�F�N�g�̃^�O���J�u���������X�y�[�X�������ƁA
    //�����������A�j���[�V�������Đ�������֐�
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("vegetable"))
        {

            if (Input.GetKey(KeyCode.Space) || (Input.GetKey(KeyCode.Joystick1Button1)))//�L�[�{�[�h�ƃQ�[���p�b�h�ɑΉ�
            {
                p_animator.SetBool("PullUp", true);
                p_animator.SetBool("Lift", true);

                SoundManager.Instance.PlaySE(SESoundData.SE.PullUp);        //�l���������̃|���Ƃ�����
                SoundManager.Instance.PlaySE(SESoundData.SE.Drumroll);      //�h�������[��

                //�l����������SE�A����2.4�b���炢�Ԃ��󂯂�ƒ��x�ǂ�
                //�ꓙ�̏�����
                
                SoundManager.Instance.PlaySE(SESoundData.SE.Get1);      //2.4�b�̊Ԋu�󂯍ς�

                //�ꓙ���Ȃ��Ă��鎞�ɗ�������
                //SoundManager.Instance.PlaySE(SESoundData.SE.Hakusyu);      //2.4�܂�


                //�񓙂̏�����
                //SoundManager.Instance.PlaySE(SESoundData.SE.Get2);    //2.4�܂�


                //�O���̏�����
                //SoundManager.Instance.PlaySE(SESoundData.SE.Get3);    //2.4�܂�


                //�l���̏�����
                //SoundManager.Instance.PlaySE(SESoundData.SE.Get4);    //2.4�܂�



                //animator��true�ɂȂ�����Finish��true������
                Finish = true;
            }
            else if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                p_animator.SetBool("PullUp", true);
                p_animator.SetBool("Lift", true);

                //animator��true�ɂȂ�����Finish��true������
                Finish = true;
            }
        }
    }
}
