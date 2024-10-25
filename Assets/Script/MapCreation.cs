using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VegetableType
{
    Empty,
    Carrot,
    Onion
}

public class MapCreation : MonoBehaviour
{
    public GameObject[] vegetablePrefab;

    private int[,] map;
    private int randomCount;
    private int randomTerms;

    [SerializeField] private float onionY = -0.82f;
    [SerializeField] private float carrotY = -1.37f;

    // ランダムな位置の変動の範囲
    [SerializeField] private Vector2 positionRandomRange = new Vector2(0.5f, 0.5f);

    // オブジェクト間の最小距離
    [SerializeField] private float minDistanceBetweenVegetables = 1.0f;

    // 生成したオブジェクトの位置を追跡するリスト
    private List<Vector3> placedVegetablePositions = new List<Vector3>();

    void Start()
    {
        map = new int[6, 6]; // マップの初期化
        randomCount = 0;
        randomTerms = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enterキーを押したら
        {
            GenerateMap();
        }
    }

    // マップ生成処理
    void GenerateMap()
    {
        // 既存の野菜オブジェクトを削除
        RemoveExistingVegetables();
        placedVegetablePositions.Clear(); // 配置された野菜の位置リストをクリア

        randomCount++;
        int randomPattern = Random.Range(randomCount, 5);
        int generationAttempts = 0;

        while (!MapGenerate(randomPattern)) generationAttempts++;
        Debug.Log("Generation attempts: " + generationAttempts);

        // マップに基づきオブジェクトを生成
        InstantiateVegetablesFromMap();
    }

    // 既存の野菜を削除する処理
    void RemoveExistingVegetables()
    {
        GameObject[] existingVegetables = GameObject.FindGameObjectsWithTag("vegetable");
        foreach (GameObject vegetable in existingVegetables)
        {
            Destroy(vegetable);
        }
    }

    // 野菜の生成処理
    void InstantiateVegetablesFromMap()
    {
        float x = -8;
        float z = 6;
        string mapLog = string.Empty;

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                mapLog += map[i, j] + " ";
                Vector3 basePosition = new Vector3(x, 0, z);

                if (map[i, j] == (int)VegetableType.Carrot)
                {
                    basePosition.y = carrotY;
                    TryPlaceVegetable(VegetableType.Carrot, basePosition);
                }
                else if (map[i, j] == (int)VegetableType.Onion)
                {
                    basePosition.y = onionY;
                    TryPlaceVegetable(VegetableType.Onion, basePosition);
                }

                x += 2.5f;
            }

            mapLog += "\n";
            z -= 3f;
            x = -6;
        }

        Debug.Log(mapLog);
    }

    // 指定された野菜を配置する試みを行う
    void TryPlaceVegetable(VegetableType type, Vector3 basePosition)
    {
        Vector3 position;
        bool positionValid = false;
        int attempts = 0;

        do
        {
            // ランダムに位置を変動させる
            position = new Vector3(
                basePosition.x + Random.Range(-positionRandomRange.x, positionRandomRange.x),
                basePosition.y,
                basePosition.z + Random.Range(-positionRandomRange.y, positionRandomRange.y)
            );

            // 他の野菜との距離が十分か確認
            positionValid = IsPositionValid(position);

            attempts++;
            if (attempts > 10) break; // 10回試行しても場所が見つからない場合は強制終了
        } while (!positionValid);

        if (positionValid)
        {
            // 配置が決まったらリストに位置を追加し、オブジェクトを生成
            placedVegetablePositions.Add(position);
            InstantiateVegetable(type, position);
        }
    }

    // 他の野菜との距離が十分かを確認する
    bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 placedPosition in placedVegetablePositions)
        {
            float distance = Vector3.Distance(position, placedPosition);
            if (distance < minDistanceBetweenVegetables)
            {
                return false; // 他のオブジェクトに近すぎる
            }
        }
        return true; // 距離が十分
    }

    // 野菜をインスタンス化する処理
    void InstantiateVegetable(VegetableType type, Vector3 position)
    {
        GameObject prefab = vegetablePrefab[(int)type];
        GameObject vegetable = Instantiate(prefab, position, Quaternion.identity);
        vegetable.transform.localScale = new Vector3(vegetable.transform.localScale.x * 1.5f, vegetable.transform.localScale.y * 1.5f, vegetable.transform.localScale.z * 1.5f);
    }

    // マップの生成処理
    bool MapGenerate(int randomPattern)
    {
        if (randomPattern != 4)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = Random.Range(0, 3); // マスに0, 1, 2を代入
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
                    map = new int[,] {
                        {0,1,0,2,1,2}, {1,0,1,1,2,1}, {1,0,2,2,0,1},
                        {1,2,2,0,2,1}, {0,1,0,2,1,2}, {2,2,1,1,0,0}
                    };
                    break;
                case 2:
                    map = new int[,] {
                        {1,2,1,2,1,1}, {2,0,2,1,0,2}, {0,2,0,1,2,0},
                        {2,0,0,1,0,2}, {0,1,2,1,0,2}, {2,0,1,1,2,0}
                    };
                    break;
                case 3:
                    map = new int[,] {
                        {1,2,1,1,1,0}, {0,1,0,2,0,0}, {0,1,1,1,0,2},
                        {2,1,0,2,0,0}, {0,1,2,1,1,2}, {0,2,0,1,2,0}
                    };
                    break;
                case 4:
                    map = new int[,] {
                        {0,1,1,1,1,0}, {1,0,0,2,0,0}, {1,0,2,0,2,0},
                        {1,0,0,1,0,0}, {1,0,2,0,0,2}, {0,1,1,1,1,0}
                    };
                    break;
                case 5:
                    map = new int[,] {
                        {2,0,1,1,0,2}, {0,1,2,0,1,0}, {1,0,2,2,0,1},
                        {1,0,0,2,2,1}, {2,1,2,0,1,0}, {0,2,1,1,0,2}
                    };
                    break;
                case 6:
                    map = new int[,] {
                        {0,1,2,0,1,0}, {2,1,0,2,1,0}, {2,1,2,0,1,2},
                        {1,0,2,0,0,1}, {1,0,2,0,2,1}, {0,1,1,1,1,0}
                    };
                    break;
            }
        }
        return true;
    }
}
