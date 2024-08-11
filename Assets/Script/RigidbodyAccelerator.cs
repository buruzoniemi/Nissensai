using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyAccelerator : MonoBehaviour
{
    //�����x
    [SerializeField] private Vector3 _acceration;

    private Rigidbody _rigdbody;

    private void Awake()
    {
        _rigdbody = GetComponent<Rigidbody>();
    }

    private void FixeUpdate()
    {
        //AddForce�ŉ����x���w��
        _rigdbody.AddForce(_acceration, ForceMode.Acceleration);
    }
}
