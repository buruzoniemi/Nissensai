using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatyaKabu : MonoBehaviour
{

    public int rate; //���܂̐��̕ϐ��錾�irate��1�̏ꍇ�A�ꓙ�܂Ƃ���
    public int[] prob; //���ꂼ��̊m���̕ϐ��錾
    public Text textbox; //���b�Z�[�W�{�b�N�X�̕ϐ��錾
    public List<string>[] prize = new List<string>[4]; //���ꂼ��̓��܂̏ܕi���X�g
    GameObject canvas; //Canvas�̕ϐ��錾


    PlayerAnimation playerAnimation;

    /*
     * ���݂̐ݒ�F
     * �m���F5%,20%,35%
     * ������̓��܂������Ȃ����ł��A���̓��܂̊m���ɉe���͂��܂���
     * �Q���܂̌��͖���
     */


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < prize.Length; i++)
        {
            prize[i] = new List<string>();�@//�ܕi���X�g�̏�����
        }
        //�����ŏܕi�̖��O��������
        string[] a = { "�ӓ�", "���_��", "�w�Z" };
        prize[1].AddRange(a);
        string[] b = { "�ӓ�", "���_��", "�w�Z" };
        prize[2].AddRange(b);
        string[] c = { "�ӓ�", "���_��", "�w�Z" };
        prize[3].AddRange(c);

        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) //�X�y�[�X�L�[����������K�`������
        {
            Debug.Log(RunGacha()); //�K�`������+
            Debug.Log("1st:" + prize[1].Count + " 2nd:" + prize[2].Count + " 3rd:" + prize[3].Count); //���܂��ꂼ��̎c���
        }
        if (Input.GetKey(KeyCode.LeftControl)) //������Control�L�[����������
        {
            canvas.SetActive(true); //Canvas��L������
            if (rate != 0) //�������܂̐���I��������
            {
                textbox.text = rate.ToString() + " ���܂̊m���́F" + prob[rate].ToString() + "%\n���̏܂͎c�� " + prize[rate].Count.ToString() + " ��";
                //���̓��܂̊m���E�c�萔��\������
            }
            else textbox.text = ""; //�Ȃɂ��\�����܂���B
        }
        else
        {
            canvas.SetActive(false); //Canvas�𖳌�����
        }

    }

    string RunGacha()
    {
        int chance = Random.Range(0, 100); //0����99�A�����_���Ȑ�����ݒ肷��
        int boundary = 0; //�����̓�����͈͂̏�����
        string result;�@//�߂�l�̕ϐ��錾
        if (chance < (boundary += prob[1]) //������͈͂Ɉꓙ�܂̊m���𑫂��A���̐����͔͈͓��� 
            && prize[1].Count > 0) //�ꓙ�܂͎c���Ă���Ȃ�
        {
            int present = Random.Range(0, prize[1].Count);�@//�ꓙ�܂̏ܕi���璊�I����
            result = "�ꓙ�� " + prize[1][present]; //�߂�l�̐ݒ�
            prize[1].RemoveAt(present); //�������甲���܂�
        }
        else if (chance < (boundary += prob[2]) //������͈͂ɓ񓙏܂̊m���𑫂��A���̐����͔͈͓��� 
            && prize[2].Count > 0) //�񓙏܂͎c���Ă���Ȃ�
        {
            int present = Random.Range(0, prize[2].Count); //�񓙏܂̏ܕi���璊�I����
            result = "�񓙏� " + prize[2][present]; //�߂�l�̐ݒ�
            prize[2].RemoveAt(present);//�������甲���܂�
        }
        else if (chance < (boundary += prob[3]) //������͈͂ɎO���܂̊m���𑫂��A���̐����͔͈͓��� 
            && prize[3].Count > 0) //�O���܂͎c���Ă���Ȃ�
        {
            int present = Random.Range(0, prize[3].Count); //�O���܂̏ܕi���璊�I����
            result = "�O���� " + prize[3][present]; //�߂�l�̐ݒ�
            prize[3].RemoveAt(present);//�������甲���܂�
        }
        else //�͈͊O�Ȃ�
        {
            result = "�|�P�b�g�e�B�b�V��"; //�߂�l�̐ݒ�
        }
        return result; //������߂�
    }

    public void LoadPrize(int rank, string present) //string�^�̔z�񂩂�List�^�ɕϊ�����
    {
        string[] temp = { present };
        prize[rank].AddRange(temp);
    }
}
