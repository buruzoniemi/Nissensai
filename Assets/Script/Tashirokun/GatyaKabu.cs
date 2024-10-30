using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public enum GatyaNum
{
    firstRank,
    secondRank,
    thirdRank,
    forthRank
}

public class GatyaKabu : MonoBehaviour
{
    public float[] prob; // �e���܂̊m���i�����܂��͏����j
    public Text textbox; // ���b�Z�[�W�{�b�N�X�̕ϐ��錾
    public List<string>[] prize = new List<string>[4]; // �e���܂̏ܕi���X�g
    private bool bDebugMenu;
    private PopupManager pm;
    private GameObject canvas; // Canvas�̕ϐ��錾
    private PlayableDirector playableDirector; // Timeline�̏���
    [SerializeField] private List<TimelineAsset> timelineAsset;
    [SerializeField] private GameObject mainCamera;
    private Transform playerTransform;

    private CameraZoomController cameraZoomController;

    /*
     * �m���̎d�l�F
     * prob[0] = 5   -> 5% (�����ŏ�����Ă���ꍇ�A�p�[�Z���e�[�W�Ƃ��Ĉ���)
     * prob[1] = 0.02 -> 0.02% (�����̏ꍇ�͂��̂܂܏����Ƃ��Ĉ���)
     */
    private void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
        pm = GameObject.Find("Canvas").GetComponent<PopupManager>();
        canvas = GameObject.Find("Canvas");
        textbox = GameObject.Find("Textbox").GetComponent<Text>();
        mainCamera = GameObject.FindWithTag("MainCamera");
        cameraZoomController = mainCamera.GetComponent<CameraZoomController>();
        bDebugMenu = true;
        // CameraZoomController �̃Z�b�g�A�b�v
        cameraZoomController = gameObject.AddComponent<CameraZoomController>();

        for (int i = 0; i < prize.Length; i++)
        {
            prize[i] = new List<string>(); // �ܕi���X�g�̏�����
        }

        // �����ŏܕi�̖��O��������
        string[] a = { "�ӓ�", "���_��", "�w�Z" };
        prize[1].AddRange(a);
        string[] b = { "�ӓ�", "���_��", "�w�Z" };
        prize[2].AddRange(b);
        string[] c = { "�ӓ�", "���_��", "�w�Z" };
        prize[3].AddRange(c);


    }

    void Start()
    {
        textbox.text = "�e���܂̊m���F1�� = " + DisplayProbability(prob[0]) + "%, 2�� = " + DisplayProbability(prob[1]) + "%, 3�� = " + DisplayProbability(prob[2]) + "%";
        canvas.SetActive(false);
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("vegetable"))
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                RunGacha(); // �K�`������
                Debug.Log("1st:" + prize[1].Count + " 2nd:" + prize[2].Count + " 3rd:" + prize[3].Count); // ���܂̎c�萔��\��
            }
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) // ������Control�L�[����������
        {
            if (bDebugMenu)
            {
                canvas.SetActive(true); //Canvas��L������
                bDebugMenu = false;
                textbox.text = "�e���܂̊m���F1�� = " + DisplayProbability(prob[0]) + "%, 2�� = " + DisplayProbability(prob[1]) + "%, 3�� = " + DisplayProbability(prob[2]) + "%";
                
                
            }
            else if (!bDebugMenu)
            {
                canvas.SetActive(false); //Canvas�𖳌�����
                bDebugMenu = true;
            }
        }

    }

    // �K�`�������s���鏈��
    void RunGacha()
    {
        float chance = Random.Range(0f, 100f); // 0.0 ���� 100.0 �̊Ԃ̃����_���Ȓl�𐶐�
        float cumulativeProbability = 0f; // �ݐϊm��
        int prizeRank = 4; // �f�t�H���g��4��
        //Debug.Log("�K�`��������");
        cameraZoomController.StartZoomIn(this.transform, 1f, 2f); // �Y�[���C��: 1�b, �ҋ@: 2�b

        // 1���܂̒��I
        if (chance < (cumulativeProbability += ConvertToPercentage(prob[0])) && prize[1].Count > 0)
        {
            //PlayTimeline(GatyaNum.firstRank); // Timeline�̍Đ�
            GivePrize(1); // 1���܂̏ܕi��n��
            prizeRank = 1;
            Debug.Log("1��");
        }
        // 2���܂̒��I
        else if (chance < (cumulativeProbability += ConvertToPercentage(prob[1])) && prize[2].Count > 0)
        {
            //PlayTimeline(GatyaNum.secondRank); // Timeline�̍Đ�
            GivePrize(2); // 2���܂̏ܕi��n��
            prizeRank = 2;
            Debug.Log("2��");
        }
        // 3���܂̒��I
        else if (chance < (cumulativeProbability += ConvertToPercentage(prob[2])) && prize[3].Count > 0)
        {
            //PlayTimeline(GatyaNum.thirdRank); // Timeline�̍Đ�
            GivePrize(3); // 3���܂̏ܕi��n��
            prizeRank = 3;
            Debug.Log("3��");
        }
        else
        {
            //PlayTimeline(GatyaNum.forthRank); // Timeline�̍Đ�
            Debug.Log("4���i�Q���܁j");
        }

        // PullUpAnimation�̃C���X�^���X�ɓ�����ʒm
        GetComponent<PullUpAnimation>().SetPrizeRank(prizeRank);
    }

    // �m�����p�[�Z���e�[�W�ɕϊ����鏈��
    float ConvertToPercentage(float probability)
    {
        return probability;
    }

    // �\���p�Ɋm�����t�H�[�}�b�g���郁�\�b�h
    public string DisplayProbability(float probability)
    {
        return probability.ToString("F2"); // ��: "5.00" �ƕ\��
    }

    // Timeline���Đ����鏈��
    void PlayTimeline(GatyaNum rank)
    {
        if (timelineAsset[(int)rank] != null)
        {
            playableDirector.playableAsset = timelineAsset[(int)rank];
            playableDirector.Play();
            //Debug.Log(rank.ToString() + " ����Timeline���Đ����܂����B");
        }
    }

    // �ܕi��n������
    void GivePrize(int rank)
    {
        if (prize[rank].Count > 0)
        {
            int presentIndex = Random.Range(0, prize[rank].Count); // �ܕi���X�g���烉���_���ɑI��
            string present = prize[rank][presentIndex];
            prize[rank].RemoveAt(presentIndex); // �I�񂾏ܕi�����X�g����폜

            Debug.Log(rank.ToString() + " ���܁I�ܕi�F" + present);
        }
        else
        {
            Debug.Log(rank.ToString() + " ���܂͍݌ɐ؂�ł��B");
        }
    }

    // �ܕi��ǉ����鏈��
    public void LoadPrize(int rank, string present)
    {
        prize[rank].Add(present);
    }

    public void AdjustProbability(int rank, float adjustmentValue)
    {
        // �m���𒲐����郍�W�b�N�������ɒǉ�
        // ��: rank�Ɋ�Â��Ċm����ύX
        Debug.Log($"Rank: {rank}, Adjustment: {adjustmentValue}");
    }
}
