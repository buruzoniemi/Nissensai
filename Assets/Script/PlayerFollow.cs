using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private float Distance = 15.0f;

    private Quaternion Vrotation;
    public Quaternion Hrotation;

    // �Ǐ]�𐧌䂷��t���O
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
        // �Ǐ]���L���ȏꍇ�̂݁A�ʒu�Ɖ�]���X�V
        if (isFollowing)
        {
            transform.rotation = Hrotation * Vrotation;
            transform.position = Player.position + new Vector3(0, 3, 0) - transform.rotation * Vector3.forward * Distance;
        }
    }
}
