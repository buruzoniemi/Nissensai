using System.Collections;
using UnityEngine;

public class PullUpAnimation : MonoBehaviour
{
    private Animator p_animator;
    private PlayerMove playerMove;
    private ObjectLifting objectLifting;
    private bool finish = false; // アニメーションを行ったかどうかのフラグ
    private int prizeRank = 4; // デフォルトは4等

    [SerializeField] private PrizeEffectController prizeEffectController; // PrizeEffectControllerの参照を追加

    void Start()
    {
        p_animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        objectLifting = GetComponent<ObjectLifting>();
    }

    // GatyaKabuクラスから賞の等数を設定するメソッド
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
                }
            }
        }
    }

    public void StartAnimationSequence()  // メソッドをpublicに
    {
        transform.eulerAngles = new Vector3(0, 180, 0);

        p_animator.SetBool("PullUp", true);
        p_animator.SetBool("Lift", true);
        finish = true;

        SoundManager.Instance.PlaySE(SESoundData.SE.PullUp);
        SoundManager.Instance.PlaySE(SESoundData.SE.Drumroll);

        prizeEffectController.PlayPrizeEffect(prizeRank);
        Debug.Log($"{prizeRank}");

        switch (prizeRank)
        {
            case 1:
                SoundManager.Instance.PlaySE(SESoundData.SE.Get1);
                SoundManager.Instance.PlaySE(SESoundData.SE.Hakusyu);
                Debug.Log("1等Sound");
                break;
            case 2:
                SoundManager.Instance.PlaySE(SESoundData.SE.Get2);
                Debug.Log("2等");
                break;
            case 3:
                SoundManager.Instance.PlaySE(SESoundData.SE.Get3);
                Debug.Log("3等");
                break;
            default:
                SoundManager.Instance.PlaySE(SESoundData.SE.Get4);
                Debug.Log("4等");
                break;
        }

        StartCoroutine(ResetAnimationAfterDelay(4f));
    }

    private IEnumerator ResetAnimationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        p_animator.SetBool("PullUp", false);
        p_animator.SetBool("Lift", false);
        objectLifting.StopHolding();
        finish = false;
    }
}
