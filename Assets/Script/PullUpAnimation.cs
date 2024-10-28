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
    public bool Finish = false; //�A�j���[�V�������s�������ǂ����̃t���O

    void Update()
    {
        //Fnish��ture�ɂȂ�����ܕb���false�ɖ߂�����
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

    //�G�����I�u�W�F�N�g�̃^�O���J�u���������X�y�[�X�������ƁA
    //�����������A�j���[�V�������Đ�������֐�
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("kabu"))
        {
            if (Input.GetKey(KeyCode.Space) || (Input.GetKey(KeyCode.Joystick1Button1)))//�L�[�{�[�h�ƃQ�[���p�b�h�ɑΉ�
            {
                p_animator.SetBool("PullUp", true);
                p_animator.SetBool("Lift", true);

                //animator��true�ɂȂ�����Finish��true������
                Finish = true;
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
