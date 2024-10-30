using System.Collections;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    [SerializeField]private Camera mainCamera;
    private Vector3 originalPosition;
    private bool isZooming = false;
    private PlayerFollow playerFollow; // PlayerFollowへの参照

    private void Start()
    {
        mainCamera = Camera.main;
        originalPosition = mainCamera.transform.position;
        playerFollow = mainCamera.GetComponent<PlayerFollow>(); // PlayerFollowスクリプトの取得
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
            playerFollow.isFollowing = false; // 追従を無効化
        }

        // 現在位置から少しだけプレイヤーに近づくズームイン位置の設定
        Vector3 directionToPlayer = (target.position - mainCamera.transform.position).normalized;
        Vector3 zoomPosition = mainCamera.transform.position + directionToPlayer * 5.0f; // 1.5メートル前進
        float elapsedTime = 0f;

        while (elapsedTime < zoomDuration)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, zoomPosition, elapsedTime / zoomDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // 最終位置を明示的に設定
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
        // 最終位置を明示的に設定
        //mainCamera.transform.position = originalPosition;

        if (playerFollow != null)
        {
            playerFollow.isFollowing = true; // 追従を再開
        }

        isZooming = false;
    }
}
