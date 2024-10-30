using UnityEngine;

public class ShowIconOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject iconPrefab;
    [SerializeField] private string targetTag = "Kabu";
    public bool bPullUp;
    private Camera mainCamera;

    private void Start()
    {
        iconPrefab = Instantiate(iconPrefab, transform);
        iconPrefab.SetActive(false);
        mainCamera = Camera.main;
        bPullUp = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!bPullUp) return;

        if (other.CompareTag(targetTag))
        {
            iconPrefab.SetActive(true);
            iconPrefab.transform.position = transform.position + Vector3.up * 4.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            iconPrefab.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        if (iconPrefab.activeSelf && mainCamera != null)
        {
            iconPrefab.transform.LookAt(mainCamera.transform);
            iconPrefab.transform.rotation = Quaternion.Euler(0, iconPrefab.transform.rotation.eulerAngles.y, 0);
        }
    }

    // アイコンの表示/非表示を制御するメソッド
    public void SetIconActive(bool isActive)
    {
        iconPrefab.SetActive(isActive);
        bPullUp = isActive;
    }
}
