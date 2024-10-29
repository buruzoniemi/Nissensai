using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifting : MonoBehaviour
{
    [SerializeField] private Transform handTransform;      // ��̈ʒu�iUnity�Őݒ�j
    [SerializeField] private GameObject heldObject;        // �����グ��I�u�W�F�N�g

    private bool isHolding = false;

    void Update()
    {
        // �I�u�W�F�N�g����ɒǏ]������
        if (isHolding && heldObject != null)
        {
            heldObject.transform.position = handTransform.position;
            heldObject.transform.rotation = handTransform.rotation;
        }
    }

    // �A�j���[�V�����C�x���g�ŌĂяo���i�����グ�J�n���j
    public void StartHolding()
    {
        isHolding = true;
    }

    // �A�j���[�V�����C�x���g�ŌĂяo���i�����グ�I�����j
    public void StopHolding()
    {
        isHolding = false;
    }
}
