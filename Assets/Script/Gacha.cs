using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    List<string> first = new List<string>();
    List<string> second = new List<string>();
    List<string> third = new List<string>();

    /*
     * 現在の設定：
     * 確率：5%,20%,35%
     * いずれの等賞が無くなったでも、他の等賞の確率に影響はしません
     * 参加賞の個数は無限
     */


    // Start is called before the first frame update
    void Start()
    {
        //ここで景品の名前を代入する
        string[] a = { "胡桃", "メダル","学校" };
        first.AddRange(a);
        string[] b = { "胡桃", "メダル", "学校" };
        second.AddRange(b);
        string[] c = { "胡桃", "メダル", "学校" };
        third.AddRange(c); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //スペースキーを押したらガチャを回す
        {
            Debug.Log(RunGacha());
            Debug.Log("1st:" + first.Count + " 2nd:" + second.Count + " 3rd:" + third.Count);　//等賞それぞれの残る個数
        }
    }

    string RunGacha()
    {
        int chance = Random.Range(0, 100);
        string result;
        if (chance < 5 && first.Count > 0) //一等賞：5パーセント
        {
            int prize = Random.Range(0,first.Count);
            result = "一等賞 " + first[prize];
            first.RemoveAt(prize); //引いたら抜きます
        }
        else if (chance < 25 && second.Count > 0) //二等賞：20パーセント
        {
            int prize = Random.Range(0,second.Count);
            result = "二等賞 " + second[prize];
            second.RemoveAt(prize);//引いたら抜きます
        }
        else if (chance < 60 &&  third.Count > 0) //三等賞：35パーセント
        {
            int prize = Random.Range (0,third.Count);
            result = "三等賞 " + third[prize];
            third.RemoveAt(prize);//引いたら抜きます
        }
        else
        {
            result = "ポケットティッシュ";
        }
        return result;
    }
}
