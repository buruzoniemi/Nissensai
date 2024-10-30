using UnityEngine;

public class PrizeEffectController : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] prizeEffectPrefabs;  // �e�����̃p�[�e�B�N���G�t�F�N�g�̃v���n�u
    [SerializeField] private Transform handPosition;               // �G�t�F�N�g�̊J�n�ʒu (�v���C���[�̎�)

    // �����������ꂽ���̉��o���J�n���郁�\�b�h
    public void PlayPrizeEffect(int prizeRank)
    {
        if (prizeRank < 1 || prizeRank > 4)
        {
            Debug.LogWarning("prizeRank��1����4�͈̔͂Ŏw�肵�Ă��������B");
            return;
        }

        // �p�[�e�B�N���G�t�F�N�g�𐶐����čĐ�
        SpawnAndPlayParticleEffect(prizeRank);
    }

    // �p�[�e�B�N���G�t�F�N�g�̐����ƍĐ����\�b�h
    private void SpawnAndPlayParticleEffect(int prizeRank)
    {
        if (prizeEffectPrefabs[prizeRank - 1] != null)
        {
            // �p�[�e�B�N���G�t�F�N�g�̃v���n�u����̈ʒu�ɐ���
            ParticleSystem effectInstance = Instantiate(prizeEffectPrefabs[prizeRank - 1], handPosition.position, Quaternion.identity);
            effectInstance.Play();

            // �G�t�F�N�g�̏I����A�����I�ɔj��
            Destroy(effectInstance.gameObject, effectInstance.main.duration);
        }
        else
        {
            Debug.LogWarning("�w�肳�ꂽ�����̃p�[�e�B�N���G�t�F�N�g���ݒ肳��Ă��܂���B");
        }
    }
}
