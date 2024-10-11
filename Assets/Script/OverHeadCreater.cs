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

    OverHeadMsg overHeadMsg;

    void Start()
    {
        //Perfab����C���X�^���X�𐶐����܂�
        overHeadMsg = Instantiate(overHeadMsgPrefab, parentObject.transform);

        overHeadMsg.targetTran = targetObject.transform;
		overHeadMsg.camera = mainCamera;
		//��\���ɂ��Ă���
		overHeadMsg.gameObject.SetActive(false);
	}

    void Update()
    {

    }

    private void OnTriggerStay(Collider collision)  //�Ԃ����Ă��鎞�ɃX�y�[�X�������Ə����閽�ߕ��̎n�܂�
    {
        Debug.Log(collision.gameObject.name); // �Ԃ���������̖��O���擾

        if (collision.gameObject.CompareTag("kabu"))//kabuTag�̃I�u�W�F�N�g�ɐG��Ă��鎞�̏���
        {
            overHeadMsg.gameObject.SetActive(true);//KABU��UI��\��������

            if (Input.GetKey(KeyCode.Space))
            {
                Destroy(collision.gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
            }
            else if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                Destroy(collision.gameObject);//���̃Q�[���I�u�W�F�N�g�����ł�����
            }
        }

        else
        {
            overHeadMsg.gameObject.SetActive(false);//����ȊO�̎���KABU��UI���\���ɂ��Ă���
        }
    }
}