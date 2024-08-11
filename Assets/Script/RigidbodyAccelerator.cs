using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyAccelerator : MonoBehaviour
{
    //加速度
    [SerializeField] private Vector3 _acceration;

    private Rigidbody _rigdbody;

    private void Awake()
    {
        _rigdbody = GetComponent<Rigidbody>();
    }

    private void FixeUpdate()
    {
        //AddForceで加速度を指定
        _rigdbody.AddForce(_acceration, ForceMode.Acceleration);
    }
}
