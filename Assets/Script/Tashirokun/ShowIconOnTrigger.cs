using UnityEngine;

public class ShowIconOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject iconPrefab; // �A�C�R���Ƃ��ĕ\������v���n�u
    [SerializeField] private string targetTag = "Kabu"; // �^�[�Q�b�g�^�O���w��
    private Camera mainCamera; // �J�������擾���邽�߂̕ϐ�

    private void Start()
    {
        // �A�C�R���̃C���X�^���X�𐶐����A��\���ɐݒ�
        iconPrefab = Instantiate(iconPrefab, transform);
        iconPrefab.SetActive(false);

        // ���C���J�����̎Q�Ƃ��擾
        mainCamera = Camera.main;
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("�J�u���ڐG���Ă��܂�"); // �f�o�b�O���O�ŐڐG���m�F

        // ����̃^�O�ƐڐG�������ɃA�C�R����\��
        if (other.CompareTag(targetTag))
        {
            iconPrefab.SetActive(true);
            iconPrefab.transform.position = transform.position + Vector3.up * 4.0f; // ����ɃA�C�R����z�u
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �^�[�Q�b�g���痣�ꂽ��A�C�R�����\���ɂ���
        if (other.CompareTag(targetTag))
        {
            iconPrefab.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        // �A�C�R�����\������Ă���ꍇ�ɂ̂݃J�����̕���������
        if (iconPrefab.activeSelf && mainCamera != null)
        {
            iconPrefab.transform.LookAt(mainCamera.transform);
            iconPrefab.transform.rotation = Quaternion.Euler(0, iconPrefab.transform.rotation.eulerAngles.y, 0); // ������݂̂�����
        }
    }
}
