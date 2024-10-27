using UnityEngine;
using Cinemachine;

public class PrizeEffectController : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] prizeEffects;       // �e�����̃p�[�e�B�N���G�t�F�N�g
    [SerializeField] private CinemachineVirtualCamera[] prizeCameras; // �e�����̃J����
    [SerializeField] private AudioClip[] prizeSounds;             // �e�����̃T�E���h
    [SerializeField] private AudioSource audioSource;             // �T�E���h�Đ��p�̃I�[�f�B�I�\�[�X

    // �����������ꂽ���̉��o���J�n���郁�\�b�h
    public void PlayPrizeEffect(int prizeRank)
    {
        // ������prizeRank��1�`4�͈͓̔��ɐ���
        if (prizeRank < 1 || prizeRank > 4)
        {
            Debug.LogWarning("prizeRank��1����4�͈̔͂Ŏw�肵�Ă��������B");
            return;
        }

        // �G�t�F�N�g���Đ�
        PlayParticleEffect(prizeRank);

        // �J������ݒ�
        SetCamera(prizeRank);

        // �T�E���h���Đ�
        PlaySound(prizeRank);
    }

    // �p�[�e�B�N���G�t�F�N�g�̍Đ����\�b�h
    private void PlayParticleEffect(int prizeRank)
    {
        if (prizeEffects[prizeRank - 1] != null)
        {
            prizeEffects[prizeRank - 1].Play();
        }
        else
        {
            Debug.LogWarning("�w�肳�ꂽ�����̃p�[�e�B�N���G�t�F�N�g���ݒ肳��Ă��܂���B");
        }
    }

    // �J�����ݒ胁�\�b�h
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

    // �T�E���h�Đ����\�b�h
    private void PlaySound(int prizeRank)
    {
        if (prizeSounds[prizeRank - 1] != null && audioSource != null)
        {
            audioSource.clip = prizeSounds[prizeRank - 1];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("�w�肳�ꂽ�����̃T�E���h���ݒ肳��Ă��Ȃ����AAudioSource���ݒ肳��Ă��܂���B");
        }
    }
}
