using UnityEngine;
using UnityEngine.UI;

public class OverHeadMsg : MonoBehaviour
{

    //���b�Z�[�W��\������Q�[���I�u�W�F�N�g�������邽�߂̃t�B�[���h
    public Transform targetTran;
    public Camera camera;

    void Update()
    {

		//���[���h���W����X�N���[���̍��W�ɕϊ����Ă����Ɉړ����܂�
		//�������A�J�����I�u�W�F�N�g��n���܂�
		//�������A���b�Z�[�W��\���������I�u�W�F�N�g�̍��W��n���܂�
		transform.position = RectTransformUtility.WorldToScreenPoint(
			camera,
		    targetTran.position
        );
	}
}
