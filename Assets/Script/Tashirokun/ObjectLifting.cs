using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifting : MonoBehaviour
{
    [SerializeField] private Transform handTransform;      // ��̈ʒu�iUnity�Őݒ�j
    private GameObject heldObject;        // �����グ��I�u�W�F�N�g

    private bool isHolding = false;

    void Update()
    {
        // �I�u�W�F�N�g����ɒǏ]������
        if (isHolding && heldObject != null)
        {
            //Debug.Log("���������Ă�");
            heldObject.transform.position = handTransform.position;
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
        heldObject.SetActive(false);
        isHolding = false;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("vegetable"))
        {
                heldObject = collision.gameObject;
        }
    }
}
