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
    private bool Fnish = false; //�A�j���[�V�������s�������ǂ����̃t���O

    void Update()
    {
        //Fnish��ture�ɂȂ�����ܕb���false�ɖ߂�����
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

    //�G�����I�u�W�F�N�g�̃^�O���J�u���������X�y�[�X�������ƁA
    //�����������A�j���[�V�������Đ�������֐�
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("kabu"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                p_animator.SetBool("PullUp", true);
                p_animator.SetBool("Lift", true);

                //animator��true�ɂȂ�����Finish��true������
                Fnish = true;
            }
        }
    }
}
