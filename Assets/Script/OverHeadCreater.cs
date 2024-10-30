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


    void Start()
    {
        //非表示にしておく
        overHeadMsgPrefab.gameObject.SetActive(false);
	}

    void Update()
    {

    }

    private void OnTriggerStay(Collider collision)  //ぶつかっている時にスペースを押すと消える命令文の始まり
    {
        //Debug.Log(collision.gameObject.name); // ぶつかった相手の名前を取得

        if (collision.gameObject.CompareTag("vegetable"))//vegetableTagのオブジェクトに触れている時の処理
        {
            overHeadMsgPrefab.gameObject.SetActive(true);//KABUのUIを表示させる
        }
        else
        {
            overHeadMsgPrefab.gameObject.SetActive(false);//それ以外の時はKABUのUIを非表示にしておく
        }
    }
}