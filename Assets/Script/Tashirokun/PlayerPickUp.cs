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

         private void OnTriggerStay(Collider collision)  //�Ԃ����Ă��鎞�ɃX�y�[�X�������Ə����閽�ߕ��̎n�܂�
    {
        Debug.Log(collision.gameObject.name); // �Ԃ���������̖��O���擾

        if (collision.gameObject.CompareTag("kabu"))//kabuTag�̃I�u�W�F�N�g�ɐG��Ă��鎞�̏���
        {

            if (InputManager.GetKey(KeyBoard.SpaceKey))
            {
                playerAnimation.PlayPullUpAnim();
            }
        }
    }
}
