using UnityEngine;
using Cinemachine;

public class PrizeEffectController : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] prizeEffects;       // 各等級のパーティクルエフェクト
    [SerializeField] private CinemachineVirtualCamera[] prizeCameras; // 各等級のカメラ
    [SerializeField] private AudioClip[] prizeSounds;             // 各等級のサウンド
    [SerializeField] private AudioSource audioSource;             // サウンド再生用のオーディオソース

    // 引っこ抜かれた時の演出を開始するメソッド
    public void PlayPrizeEffect(int prizeRank)
    {
        // 引数のprizeRankを1～4の範囲内に制限
        if (prizeRank < 1 || prizeRank > 4)
        {
            Debug.LogWarning("prizeRankは1から4の範囲で指定してください。");
            return;
        }

        // エフェクトを再生
        PlayParticleEffect(prizeRank);

        // カメラを設定
        SetCamera(prizeRank);

        // サウンドを再生
        PlaySound(prizeRank);
    }

    // パーティクルエフェクトの再生メソッド
    private void PlayParticleEffect(int prizeRank)
    {
        if (prizeEffects[prizeRank - 1] != null)
        {
            prizeEffects[prizeRank - 1].Play();
        }
        else
        {
            Debug.LogWarning("指定された等級のパーティクルエフェクトが設定されていません。");
        }
    }

    // カメラ設定メソッド
    private void SetCamera(int prizeRank)
    {
        for (int i = 0; i < prizeCameras.Length; i++)
        {
            if (prizeCameras[i] != null)
            {
                prizeCameras[i].enabled = (i == prizeRank - 1);
            }
        }
    }

    // サウンド再生メソッド
    private void PlaySound(int prizeRank)
    {
        if (prizeSounds[prizeRank - 1] != null && audioSource != null)
        {
            audioSource.clip = prizeSounds[prizeRank - 1];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("指定された等級のサウンドが設定されていないか、AudioSourceが設定されていません。");
        }
    }
}
