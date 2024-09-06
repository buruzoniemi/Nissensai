using UnityEngine;
using UnityEngine.UI;

public class OverHeadMsg : MonoBehaviour
{

    //メッセージを表示するゲームオブジェクトを代入するためのフィールド
    public Transform targetTran;
    public Camera camera;

    void Update()
    {

		//ワールド座標からスクリーンの座標に変換してそこに移動します
		//第一引数、カメラオブジェクトを渡します
		//第二引数、メッセージを表示したいオブジェクトの座標を渡します
		transform.position = RectTransformUtility.WorldToScreenPoint(
			camera,
		    targetTran.position
        );
	}
}
