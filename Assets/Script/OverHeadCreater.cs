using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverHeadCreater : MonoBehaviour
{
	[SerializeField] GameObject parentObject;
	[SerializeField] Camera mainCamera;
	[SerializeField] GameObject targetObject;
	//����ɕ\�����郁�b�Z�[�WPrefab��o�^���܂�
	[SerializeField] OverHeadMsg overHeadMsgPrefab;


    void Start()
    {
        //��\���ɂ��Ă���
        overHeadMsgPrefab.gameObject.SetActive(false);
	}

    void Update()
    {

    }

    private void OnTriggerStay(Collider collision)  //�Ԃ����Ă��鎞�ɃX�y�[�X�������Ə����閽�ߕ��̎n�܂�
    {
        //Debug.Log(collision.gameObject.name); // �Ԃ���������̖��O���擾

        if (collision.gameObject.CompareTag("vegetable"))//vegetableTag�̃I�u�W�F�N�g�ɐG��Ă��鎞�̏���
        {
            overHeadMsgPrefab.gameObject.SetActive(true);//KABU��UI��\��������
        }
        else
        {
            overHeadMsgPrefab.gameObject.SetActive(false);//����ȊO�̎���KABU��UI���\���ɂ��Ă���
        }
    }
}