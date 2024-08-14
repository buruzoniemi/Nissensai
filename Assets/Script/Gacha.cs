using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{

    public int rate;
    public int[] prob;
    public Text textbox;
    public List<string>[] prize = new List<string>[4] ;
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
            prize[i] = new List<string>();
        }
        //ここで景品の名前を代入する
        string[] a = { "胡桃", "メダル","学校" };
        prize[1].AddRange(a);
        string[] b = { "胡桃", "メダル", "学校" };
        prize[2].AddRange(b);
        string[] c = { "胡桃", "メダル", "学校" };
        prize[3].AddRange(c); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //スペースキーを押したらガチャを回す
        {
            Debug.Log(RunGacha());
            Debug.Log("1st:" + prize[1].Count + " 2nd:" + prize[2].Count + " 3rd:" + prize[3].Count);　//等賞それぞれの残る個数
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) prob[rate]++; //今選んだ等賞の確率を1％上げます
        if (Input.GetKeyDown(KeyCode.DownArrow)) prob[rate]--; //今選んだ等賞の確率を1％下げます
        if (rate != 0)
        {
            textbox.text = rate.ToString() + " 等賞の確率は：" + prob[rate].ToString() + "%\nその賞は残り " + prize[rate].Count.ToString()+" 個";
        }
        else textbox.text = "ボダンを押してください";
    }

    string RunGacha()
    {
        int chance = Random.Range(0, 100);
        int boundary = 0;
        string result;
        if (chance < (boundary += prob[1]) && prize[1].Count > 0) //一等賞：5パーセント
        {
            int present = Random.Range(0, prize[1].Count);
            result = "一等賞 " + prize[1][present];
            prize[1].RemoveAt(present); //引いたら抜きます
        }
        else if (chance < (boundary += prob[2]) && prize[2].Count > 0) //二等賞：15パーセント
        {
            int present = Random.Range(0, prize[2].Count);
            result = "二等賞 " + prize[2][present];
            prize[2].RemoveAt(present);//引いたら抜きます
        }
        else if (chance < (boundary += prob[3]) && prize[3].Count > 0) //三等賞：30パーセント
        {
            int present = Random.Range (0, prize[3].Count);
            result = "三等賞 " + prize[3][present];
            prize[3].RemoveAt(present);//引いたら抜きます
        }
        else
        {
            result = "ポケットティッシュ";
        }
        return result;
    }

    public void LoadPrize(int rank, string present)
    {
        string[] temp = { present };
        prize[rank].AddRange(temp);
    }
}
