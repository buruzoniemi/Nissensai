using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeChoice : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button; //ボダンの宣言
    void Start()
    {
        if (button != null) button.onClick.AddListener(OnButtonClick); //クリック判定の設定
    }


    void OnButtonClick() //このボダンをクリックしたら
    {
        string name = button.gameObject.name; //クリックされたボダンの名前を取る
        Gacha mc = GameObject.Find("Main Camera").GetComponent<Gacha>();
        if (name == "first") mc.rate = 1; //一等賞のボダンを押したら等賞の数を1に設定
        if (name == "second") mc.rate = 2; //二等賞のボダンを押したら等賞の数を1に設定
        if (name == "third") mc.rate = 3; //三等賞のボダンを押したら等賞の数を1に設定
        if (name == "Close") //閉じるのボダンを押したら
        {
            PopupManager pm = GameObject.Find("Canvas").GetComponent<PopupManager>();   
            if (pm != null)
            {
                pm.HidePopup(); //メッセージボックスを隠す
            }
        }
    }
}
