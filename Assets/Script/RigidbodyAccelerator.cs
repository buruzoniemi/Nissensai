using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyAccelerator : MonoBehaviour
{
    //‰Á‘¬“x
    [SerializeField] private Vector3 _acceration;

    private Rigidbody _rigdbody;

    private void Awake()
    {
        _rigdbody = GetComponent<Rigidbody>();
    }

    private void FixeUpdate()
    {
        //AddForce‚Å‰Á‘¬“x‚ðŽw’è
        _rigdbody.AddForce(_acceration, ForceMode.Acceleration);
    }
}
