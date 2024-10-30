using UnityEngine;

public class PrizeEffectController : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] prizeEffectPrefabs;  // 各等級のパーティクルエフェクトのプレハブ
    [SerializeField] private Transform handPosition;               // エフェクトの開始位置 (プレイヤーの手)

    // 引っこ抜かれた時の演出を開始するメソッド
    public void PlayPrizeEffect(int prizeRank)
    {
        if (prizeRank < 1 || prizeRank > 4)
        {
            Debug.LogWarning("prizeRankは1から4の範囲で指定してください。");
            return;
        }

        // パーティクルエフェクトを生成して再生
        SpawnAndPlayParticleEffect(prizeRank);
    }

    // パーティクルエフェクトの生成と再生メソッド
    private void SpawnAndPlayParticleEffect(int prizeRank)
    {
        if (prizeEffectPrefabs[prizeRank - 1] != null)
        {
            // パーティクルエフェクトのプレハブを手の位置に生成
            ParticleSystem effectInstance = Instantiate(prizeEffectPrefabs[prizeRank - 1], handPosition.position, Quaternion.identity);
            effectInstance.Play();

            // エフェクトの終了後、自動的に破棄
            Destroy(effectInstance.gameObject, effectInstance.main.duration);
        }
        else
        {
            Debug.LogWarning("指定された等級のパーティクルエフェクトが設定されていません。");
        }
    }
}
