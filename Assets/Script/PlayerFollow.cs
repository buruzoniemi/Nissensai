using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private float Distance = 15.0f;

    private Quaternion Vrotation;
    public Quaternion Hrotation;

    // 追従を制御するフラグ
    public bool isFollowing = true;

    void Start()
    {
        Vrotation = Quaternion.Euler(60, 0, 0);
        Hrotation = Quaternion.identity;
        transform.rotation = Hrotation * Vrotation;
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();

        transform.position = Player.position - transform.rotation * Vector3.forward * Distance;
    }

    void Update()
    {
        // 追従が有効な場合のみ、位置と回転を更新
        if (isFollowing)
        {
            transform.rotation = Hrotation * Vrotation;
            transform.position = Player.position + new Vector3(0, 3, 0) - transform.rotation * Vector3.forward * Distance;
        }
    }
}
