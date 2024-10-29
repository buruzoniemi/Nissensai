using UnityEngine;

public class ShowIconOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject iconPrefab; // �A�C�R���Ƃ��ĕ\������v���n�u
    [SerializeField] private string targetTag = "Kabu"; // �^�[�Q�b�g�^�O���w��
    private GameObject iconInstance; // �A�C�R���̃C���X�^���X
    private Camera mainCamera; // �J�������擾���邽�߂̕ϐ�

    private void Start()
    {
        // �A�C�R���̃C���X�^���X�𐶐����A��\���ɐݒ�
        iconInstance = Instantiate(iconPrefab, transform);
        iconInstance.SetActive(false);

        // ���C���J�����̎Q�Ƃ��擾
        mainCamera = Camera.main;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("�J�u���ڐG���Ă��܂�"); // �f�o�b�O���O�ŐڐG���m�F

        // ����̃^�O�ƐڐG�������ɃA�C�R����\��
        if (other.CompareTag(targetTag))
        {
            iconInstance.SetActive(true);
            iconInstance.transform.position = transform.position + Vector3.up * 4.0f; // ����ɃA�C�R����z�u
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �^�[�Q�b�g���痣�ꂽ��A�C�R�����\���ɂ���
        if (other.CompareTag(targetTag))
        {
            iconInstance.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        // �A�C�R�����\������Ă���ꍇ�ɂ̂݃J�����̕���������
        if (iconInstance.activeSelf && mainCamera != null)
        {
            iconInstance.transform.LookAt(mainCamera.transform);
            iconInstance.transform.rotation = Quaternion.Euler(0, iconInstance.transform.rotation.eulerAngles.y, 0); // ������݂̂�����
        }
    }
}
