using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MyScriptt : MonoBehaviour
{            
    private float speed = 3.0f;         //���x

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        //��L�[
        if (transform.position.z <= 14.037f)               //�v���C���[���X�e�[�W���ɂ���Ȃ�
        {
            if (Input.GetKey(KeyCode.UpArrow))      //��L�[�������Ə�ɐi��
            {
                transform.position += speed * transform.forward* Time.deltaTime;
            }
        }

        //���L�[
        if (transform.position.z >= -4.899f)               //�v���C���[���X�e�[�W���ɂ���Ȃ�
        {
            if (Input.GetKey(KeyCode.DownArrow))    //���L�[�������Ɖ��ɐi��
            {
                transform.position -= speed * transform.forward * Time.deltaTime;
            }
        }

        //�E�L�[
        if (transform.position.x <= 15.539f)               //�v���C���[���X�e�[�W���ɂ���Ȃ�
        {
            if (Input.GetKey(KeyCode.RightArrow))   //�E�L�[�������ƉE�ɐi��
            {
                transform.position += speed * transform.right * Time.deltaTime;
            }
        }

        //���L�[
        if (transform.position.x >= -3.299f)               //�v���C���[���X�e�[�W���ɂ���Ȃ�
        {
            if (Input.GetKey(KeyCode.LeftArrow))    //���L�[�������ƍ��ɐi��
            {
                transform.position -= speed * transform.right * Time.deltaTime;
            }
        }
    }
}
