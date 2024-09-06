using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverHeadCreater : MonoBehaviour
{
	[SerializeField] GameObject parentObject;
	[SerializeField] Camera mainCamera;
	[SerializeField] GameObject targetObject;
	//頭上に表示するメッセージPrefabを登録します
	[SerializeField] OverHeadMsg overHeadMsgPrefab;

    OverHeadMsg overHeadMsg;

    void Start()
    {
        //Perfabからインスタンスを生成します
        overHeadMsg = Instantiate(overHeadMsgPrefab, parentObject.transform);

        overHeadMsg.targetTran = targetObject.transform;
		overHeadMsg.camera = mainCamera;
		//非表示にしておく
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
