using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    //�����x
    [SerializeField] private Vector3 _acceleration;

    //�����x
    [SerializeField] private Vector3 _initialVelocity;

    //���ݑ��x
    private Vector3 _velocity;

    void Start()
    {
        //�����x�ŏ�����
        _velocity = _initialVelocity;
    }

    void Update()
    {
        //�����x�̎��Ԑϕ����瑬�x�����߂�
        _velocity += _acceleration * Time.deltaTime;

        //���x�̎��Ԑϕ�����ʒu�����߂�
        transform.position += _velocity*Time.deltaTime;
    }
}
