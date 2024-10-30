using System.Collections;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    [SerializeField]private Camera mainCamera;
    private Vector3 originalPosition;
    private bool isZooming = false;
    private PlayerFollow playerFollow; // PlayerFollow�ւ̎Q��

    private void Start()
    {
        mainCamera = Camera.main;
        originalPosition = mainCamera.transform.position;
        playerFollow = mainCamera.GetComponent<PlayerFollow>(); // PlayerFollow�X�N���v�g�̎擾
    }
    public void StartZoomIn(Transform target, float zoomDuration, float waitDuration)
    {
        if (!isZooming)
        {
            StartCoroutine(ZoomIn(target, zoomDuration, waitDuration));
        }
    }

    private IEnumerator ZoomIn(Transform target, float zoomDuration, float waitDuration)
    {
        originalPosition = mainCamera.transform.position;
        isZooming = true;

        if (playerFollow != null)
        {
            playerFollow.isFollowing = false; // �Ǐ]�𖳌���
        }

        // ���݈ʒu���班�������v���C���[�ɋ߂Â��Y�[���C���ʒu�̐ݒ�
        Vector3 directionToPlayer = (target.position - mainCamera.transform.position).normalized;
        Vector3 zoomPosition = mainCamera.transform.position + directionToPlayer * 5.0f; // 1.5���[�g���O�i
        float elapsedTime = 0f;

        while (elapsedTime < zoomDuration)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, zoomPosition, elapsedTime / zoomDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // �ŏI�ʒu�𖾎��I�ɐݒ�
        mainCamera.transform.position = zoomPosition;

        yield return new WaitForSeconds(waitDuration);
        StartCoroutine(ZoomOut(zoomDuration));
    }

    private IEnumerator ZoomOut(float zoomDuration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < zoomDuration)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, originalPosition, elapsedTime / zoomDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // �ŏI�ʒu�𖾎��I�ɐݒ�
        //mainCamera.transform.position = originalPosition;

        if (playerFollow != null)
        {
            playerFollow.isFollowing = true; // �Ǐ]���ĊJ
        }

        isZooming = false;
    }
}
