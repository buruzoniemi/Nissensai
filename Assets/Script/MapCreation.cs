using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    public GameObject cubePrefab;
    
    // Start is called before the first frame update
    int[,] map;
    int randomCount;
    int randomTerms;
    void Start()
    {
        map = new int[6, 6];　//マップの初期化
        randomCount = 0;
        randomTerms = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //Enterキーを押したら
        {
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Box");
            foreach (GameObject c in cubes)
            {
                Destroy(c);
            }
            int count = 0;
            float x = -4; float z = 3;
            randomCount++;
            int ran = Random.Range(randomCount, 5);
            while (!MapGenerate(ran)) count++;　//マップを生成する
            Debug.Log("Generation time: "+count++); //マップが生成された回数の表示
            string msg = string.Empty;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    msg += map[i,j] + " ";
                    if (map[i,j] == 1)
                    { 
                        GameObject c = Instantiate(cubePrefab, new Vector3(x, 0, z), Quaternion.identity);
                        MeshRenderer mr = c.GetComponent<MeshRenderer>();
                        mr.material.color = new Color(0.5f, 1, 1);
                    }
                    x += 1.5f;
                    
                }
                msg += "\n";
                z -= 1.5f;
                x = -4;
            }
            Debug.Log(msg);　//最終基準に満たしたマップを表示する

        }
    }

    bool MapGenerate(int ran)
    {
        if (ran != 4)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = Random.Range(0, 2); //マスに0か1を代入する
                }
            }
            for (int i = 0; i < map.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < map.GetLength(1) - 1; j++)
                {
                    if (map[i, j] + map[i, j + 1] + map[i + 1, j + 1] + map[i + 1, j] >= 3) //もし2*2のマスに1が設定されたマス数が3以上なら
                    {
                        return false; //ダメを返す
                    }
                }
            }
        }
        else
        {
            randomCount = 0;
            randomTerms++;
            if (randomTerms > 6) randomTerms = 1;
            switch (randomTerms)
            {
                case 1:
                    map = new int[,] 
                    {
                        {0,1,0,0,1,0},
                        {1,0,1,1,0,1},
                        {1,0,0,0,0,1},
                        {1,0,0,0,0,1},
                        {0,1,0,0,1,0},
                        {0,0,1,1,0,0}
                    };
                    break;
                case 2:
                    map = new int[,]
                    {
                        {1,1,1,1,1,1},
                        {0,0,0,1,0,0},
                        {0,0,0,1,0,0},
                        {0,0,0,1,0,0},
                        {0,1,0,1,0,0},
                        {0,0,1,1,0,0}
                    };
                    break;
                case 3:
                    map = new int[,]
                    {
                        {0,1,1,1,1,0},
                        {0,1,0,0,0,0},
                        {0,1,1,1,0,0},
                        {0,1,0,0,0,0},
                        {0,1,1,1,1,0},
                        {0,0,0,0,0,0}
                    };
                    break;
                case 4:
                    map = new int[,]
                    {
                        {0,1,1,1,1,0},
                        {1,0,0,0,0,0},
                        {1,0,0,0,0,0},
                        {1,0,0,0,0,0},
                        {1,0,0,0,0,0},
                        {0,1,1,1,1,0}
                    };
                    break;
                case 5:
                    map = new int[,]
                    {
                        {0,0,1,1,0,0},
                        {0,1,0,0,1,0},
                        {1,0,0,0,0,1},
                        {1,0,0,0,0,1},
                        {0,1,0,0,1,0},
                        {0,0,1,1,0,0}
                    };
                    break;
                case 6:
                    map = new int[,]
{
                        {0,1,0,0,1,0},
                        {0,1,0,0,1,0},
                        {0,1,0,0,1,0},
                        {1,0,0,0,0,1},
                        {1,0,0,0,0,1},
                        {0,1,1,1,1,0}
};
                    break;
                    
            }
        }
        return true;　//OKを返す
    }
}
