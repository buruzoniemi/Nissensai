using UnityEngine;

public class ShowIconOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject iconPrefab; // アイコンとして表示するプレハブ
    [SerializeField] private string targetTag = "Kabu"; // ターゲットタグを指定
    private Camera mainCamera; // カメラを取得するための変数

    private void Start()
    {
        // アイコンのインスタンスを生成し、非表示に設定
        iconPrefab = Instantiate(iconPrefab, transform);
        iconPrefab.SetActive(false);

        // メインカメラの参照を取得
        mainCamera = Camera.main;
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("カブが接触しています"); // デバッグログで接触を確認

        // 特定のタグと接触した時にアイコンを表示
        if (other.CompareTag(targetTag))
        {
            iconPrefab.SetActive(true);
            iconPrefab.transform.position = transform.position + Vector3.up * 4.0f; // 頭上にアイコンを配置
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ターゲットから離れたらアイコンを非表示にする
        if (other.CompareTag(targetTag))
        {
            iconPrefab.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        // アイコンが表示されている場合にのみカメラの方向を向く
        if (iconPrefab.activeSelf && mainCamera != null)
        {
            iconPrefab.transform.LookAt(mainCamera.transform);
            iconPrefab.transform.rotation = Quaternion.Euler(0, iconPrefab.transform.rotation.eulerAngles.y, 0); // 上方向のみを向く
        }
    }
}
