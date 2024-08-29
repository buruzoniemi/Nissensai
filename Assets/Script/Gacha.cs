using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{

    public int rate; //等賞の数の変数宣言（rateは1の場合、一等賞という
    public int[] prob; //それぞれの確率の変数宣言
    public Text textbox; //メッセージボックスの変数宣言
    public List<string>[] prize = new List<string>[4] ; //それぞれの等賞の賞品リスト
    GameObject canvas; //Canvasの変数宣言
    /*
     * 現在の設定：
     * 確率：5%,20%,35%
     * いずれの等賞が無くなったでも、他の等賞の確率に影響はしません
     * 参加賞の個数は無限
     */


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < prize.Length; i++)
        {
            prize[i] = new List<string>();　//賞品リストの初期化
        }
        //ここで賞品の名前を代入する
        string[] a = { "胡桃", "メダル","学校" };
        prize[1].AddRange(a);
        string[] b = { "胡桃", "メダル", "学校" };
        prize[2].AddRange(b);
        string[] c = { "胡桃", "メダル", "学校" };
        prize[3].AddRange(c); 

        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) //スペースキーを押したらガチャを回す
        {
            Debug.Log(RunGacha()); //ガチャを回す+
            Debug.Log("1st:" + prize[1].Count + " 2nd:" + prize[2].Count + " 3rd:" + prize[3].Count); //等賞それぞれの残る個数
        }
        if (Input.GetKey(KeyCode.LeftControl)) //左下のControlキーを押したら
        {
            canvas.SetActive(true); //Canvasを有効する
            if (rate != 0) //もし等賞の数を選択したら
            {
                textbox.text = rate.ToString() + " 等賞の確率は：" + prob[rate].ToString() + "%\nその賞は残り " + prize[rate].Count.ToString() + " 個";
                //その等賞の確率・残り数を表示する
            }
            else textbox.text = ""; //なにも表示しません。
        }
        else
        {
            canvas.SetActive(false); //Canvasを無効する
        }
        
    }

    string RunGacha()
    {
        int chance = Random.Range(0, 100); //0から99、ランダムな数字を設定する
        int boundary = 0; //数字の当たり範囲の初期化
        string result;　//戻り値の変数宣言
        if (chance < (boundary += prob[1]) //当たり範囲に一等賞の確率を足し、その数字は範囲内で 
            && prize[1].Count > 0) //一等賞は残っているなら
        {
            int present = Random.Range(0, prize[1].Count);　//一等賞の賞品から抽選する
            result = "一等賞 " + prize[1][present]; //戻り値の設定
            prize[1].RemoveAt(present); //引いたら抜きます
        }
        else if (chance < (boundary += prob[2]) //当たり範囲に二等賞の確率を足し、その数字は範囲内で 
            && prize[2].Count > 0) //二等賞は残っているなら
        {
            int present = Random.Range(0, prize[2].Count); //二等賞の賞品から抽選する
            result = "二等賞 " + prize[2][present]; //戻り値の設定
            prize[2].RemoveAt(present);//引いたら抜きます
        }
        else if (chance < (boundary += prob[3]) //当たり範囲に三等賞の確率を足し、その数字は範囲内で 
            && prize[3].Count > 0) //三等賞は残っているなら
        {
            int present = Random.Range (0, prize[3].Count); //三等賞の賞品から抽選する
            result = "三等賞 " + prize[3][present]; //戻り値の設定
            prize[3].RemoveAt(present);//引いたら抜きます
        }
        else //範囲外なら
        {
            result = "ポケットティッシュ"; //戻り値の設定
        }
        return result; //文字を戻す
    }

    public void LoadPrize(int rank, string present) //string型の配列からList型に変換する
    {
        string[] temp = { present };
        prize[rank].AddRange(temp);
    }
}
