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

    }

    private void OnTriggerStay(Collider collision)  //ぶつかっている時にスペースを押すと消える命令文の始まり
    {
        Debug.Log(collision.gameObject.name); // ぶつかった相手の名前を取得

        if (collision.gameObject.CompareTag("kabu"))//kabuTagのオブジェクトに触れている時の処理
        {
            overHeadMsg.gameObject.SetActive(true);//KABUのUIを表示させる

            if (Input.GetKey(KeyCode.Space))
            {
                Destroy(collision.gameObject);//このゲームオブジェクトを消滅させる
            }
            else if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                Destroy(collision.gameObject);//このゲームオブジェクトを消滅させる
            }
        }

        else
        {
            overHeadMsg.gameObject.SetActive(false);//それ以外の時はKABUのUIを非表示にしておく
        }
    }
}