using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTrriger : MonoBehaviour
{
	private void OnCollisionStay(Collision collision)  //ぶつかっている時にスペースを押すと消える命令文の始まり
	{
		Debug.Log(collision.gameObject.name); // ぶつかった相手の名前を取得
	}
}
