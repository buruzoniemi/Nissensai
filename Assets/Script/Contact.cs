using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)  //�Ԃ����Ă��鎞�ɃX�y�[�X�������Ə����閽�ߕ��̎n�܂�
    {
        Debug.Log(collision.gameObject.name); // �Ԃ���������̖��O���擾



        if (Input.GetKey(KeyCode.Space))
            {
                Destroy(gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
            }
    }
}