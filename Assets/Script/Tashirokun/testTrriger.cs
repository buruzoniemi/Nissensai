using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTrriger : MonoBehaviour
{
	private void OnCollisionStay(Collision collision)  //�Ԃ����Ă��鎞�ɃX�y�[�X�������Ə����閽�ߕ��̎n�܂�
	{
		Debug.Log(collision.gameObject.name); // �Ԃ���������̖��O���擾
	}
}
