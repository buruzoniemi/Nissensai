using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PullUpAnimation : MonoBehaviour
{
    private Animator p_animator;
    private PlayerMove playerMove;
    private ObjectLifting objectLifting;
    private bool finish = false; // �A�j���[�V�������s�������ǂ����̃t���O
    private int prizeRank = 4; // �f�t�H���g��4��

    void Start()
    {
        p_animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        objectLifting = GetComponent<ObjectLifting>();
    }

    // GatyaKabu�N���X����܂̓�����ݒ肷�郁�\�b�h
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
                    StartAnimationSequence();
                }
            }
        }
    }

    private void StartAnimationSequence()
    {
        // �v���C���[�𐳖� (y = 180) �Ɍ�����
        transform.eulerAngles = new Vector3(0, 180, 0);

        p_animator.SetBool("PullUp", true);
        p_animator.SetBool("Lift", true);
        finish = true;

        SoundManager.Instance.PlaySE(SESoundData.SE.PullUp);
        SoundManager.Instance.PlaySE(SESoundData.SE.Drumroll);

        // �����ɉ�����SE���Đ�
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
