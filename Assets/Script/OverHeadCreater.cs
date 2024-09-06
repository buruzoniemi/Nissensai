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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            overHeadMsg.gameObject.SetActive(true);
        }
    }
}
