using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    // Start is called before the first frame update
    int[,] map;
    void Start()
    {
        map = new int[6, 6];　//マップの初期化
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //Enterキーを押したら
        {
            int count = 0;
            while (!MapGenerate()) count++;　//マップを生成する
            Debug.Log("Generation time: "+count++); //マップが生成された回数の表示
            string msg = string.Empty;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    msg += map[i,j] + " ";
                }
                msg += "\n";
            }
            Debug.Log(msg);　//最終基準に満たしたマップを表示する
        }
    }

    bool MapGenerate()
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j] = Random.Range(0, 2);　//マスに0か1を代入する
            }
        }
        for (int i = 0; i < map.GetLength(0)-1; i++)
        {
            for (int j = 0; j < map.GetLength(1)-1; j++)
            {
                if (map[i,j] + map[i,j+1] + map[i+1,j+1] + map[i+1,j] >= 3)　//もし2*2のマスに1が設定されたマス数が3以上なら
                {
                    return false;　//ダメを返す
                }
            }
        }
        return true;　//OKを返す
    }
}
