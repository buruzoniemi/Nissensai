using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinctionJudgment : MonoBehaviour
{
    private bool contact = false;       //�v���C���[�ɐG��Ă��邩�G��Ă��Ȃ���

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")   //�v���C���[���d�Ȃ��Ă��鎞
        {
            contact = true;                     //�v���C���[�ɐG��Ă���

        }
    }


    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (contact == true)                    //�v���C���[���G��Ă���Ƃ�
        {
            if (Input.GetKey(KeyCode.Space))    //�X�y�[�X�������ƃJ�u��������
            {
                Destroy(this.gameObject);
            }
        }
    }
}
