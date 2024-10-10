using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private float rotationSpeed = 0.1f; // ��]���x�i�X���[�Y�ȉ�]�̂��߁j

    // �v���C���[���ړ������ɉ�]�����郁�\�b�h
    public void RotatePlayer(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero) // �ړ����Ă���ꍇ�̂݉�]
        {
            // ���݂̉�](transform.rotation)���ړ������Ɍ������](Quaternion.LookRotation)�ɋ߂Â���
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
        }
    }
}
