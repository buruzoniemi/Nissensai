using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifting : MonoBehaviour
{
    [SerializeField] private Transform handTransform;      // 手の位置（Unityで設定）
    [SerializeField] private GameObject heldObject;        // 持ち上げるオブジェクト

    private bool isHolding = false;

    void Update()
    {
        // オブジェクトを手に追従させる
        if (isHolding && heldObject != null)
        {
            heldObject.transform.position = handTransform.position;
            heldObject.transform.rotation = handTransform.rotation;
        }
    }

    // アニメーションイベントで呼び出し（持ち上げ開始時）
    public void StartHolding()
    {
        isHolding = true;
    }

    // アニメーションイベントで呼び出し（持ち上げ終了時）
    public void StopHolding()
    {
        isHolding = false;
    }
}
