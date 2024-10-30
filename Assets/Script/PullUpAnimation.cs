using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PullUpAnimation : MonoBehaviour
{
    private Animator p_animator;
    private PlayerMove playerMove;
    private ObjectLifting objectLifting;
    private ShowIconOnTrigger showIconOnTrigger;
    private bool finish = false;
    private int prizeRank = 4;

    [SerializeField] private PrizeEffectController prizeEffectController;
    [SerializeField] private Image[] prizeImages;
     private float fadeDuration = 1.5f;

    private void Start()
    {
        p_animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        objectLifting = GetComponent<ObjectLifting>();
        showIconOnTrigger = GetComponent<ShowIconOnTrigger>();

        foreach (Image img in prizeImages)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
            img.gameObject.SetActive(false);
        }
    }

    public void SetPrizeRank(int rank)
    {
        prizeRank = rank;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("vegetable"))
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                if (!p_animator.GetBool("PullUp") && !p_animator.GetBool("Lift"))
                {
                    objectLifting.StartHolding();
                    playerMove.RunStop();
                    showIconOnTrigger?.SetIconActive(false); // 持ち上げ開始時にアイコンを非表示
                }
            }
        }
    }

    public void StartAnimationSequence()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);

        p_animator.SetBool("PullUp", true);
        p_animator.SetBool("Lift", true);
        finish = true;

        SoundManager.Instance.PlaySE(SESoundData.SE.PullUp);
        SoundManager.Instance.PlaySE(SESoundData.SE.Drumroll);

        prizeEffectController.PlayPrizeEffect(prizeRank);
        Debug.Log($"{prizeRank}");

        showIconOnTrigger?.SetIconActive(false); // アニメーション開始時にもアイコンを非表示

        switch (prizeRank)
        {
            case 1:
                SoundManager.Instance.PlaySE(SESoundData.SE.Get1);
                SoundManager.Instance.PlaySE(SESoundData.SE.Hakusyu);
                break;
            case 2:
                SoundManager.Instance.PlaySE(SESoundData.SE.Get2);
                break;
            case 3:
                SoundManager.Instance.PlaySE(SESoundData.SE.Get3);
                break;
            default:
                SoundManager.Instance.PlaySE(SESoundData.SE.Get4);
                break;
        }

        StartCoroutine(WaitForDrumrollEnd());
    }

    private IEnumerator WaitForDrumrollEnd()
    {
        // ドラムロールの音が再生中かを確認するための仮のフラグ
        float drumrollDuration = 2.0f; // ドラムロールの長さを設定 (実際の音の長さに合わせて調整)
        yield return new WaitForSeconds(drumrollDuration);

        // フェードインを開始
        StartCoroutine(FadeInAndScaleImage(prizeRank));
        StartCoroutine(ResetAnimationAfterDelay(4f));
    }

    private IEnumerator FadeInAndScaleImage(int rank)
    {
        if (rank < 1 || rank > prizeImages.Length) yield break;

        Image prizeImage = prizeImages[rank - 1];
        prizeImage.gameObject.SetActive(true);

        float elapsedTime = 0f;
        Color targetColor = new Color(prizeImage.color.r, prizeImage.color.g, prizeImage.color.b, 1);
        Vector3 targetScale = Vector3.one * 3f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            prizeImage.color = Color.Lerp(prizeImage.color, targetColor, elapsedTime / fadeDuration);
            prizeImage.transform.localScale = Vector3.Lerp(Vector3.one, targetScale, elapsedTime / fadeDuration);
            yield return null;
        }

        prizeImage.color = targetColor;
        prizeImage.transform.localScale = targetScale;
    }

    private IEnumerator ResetAnimationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        p_animator.SetBool("PullUp", false);
        p_animator.SetBool("Lift", false);
        objectLifting.StopHolding();
        finish = false;

        foreach (Image img in prizeImages)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
            img.gameObject.SetActive(false);
            img.transform.localScale = Vector3.one;
        }

        showIconOnTrigger?.SetIconActive(true); // アニメーション終了後にアイコンを再表示
    }
}
