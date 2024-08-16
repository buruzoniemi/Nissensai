using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RateChange : MonoBehaviour
{
    Gacha gacha;
    PopupManager pm;
    public Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        gacha = GetComponent<Gacha>();
        pm = GameObject.Find("Canvas").GetComponent<PopupManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            int range;
            if (dropdown.value == 0) range = 1;
            else range = 5 * dropdown.value;
            if (Input.GetKeyDown(KeyCode.UpArrow))//今選んだ等賞の確率をx％上げます
            {
                int total = 0;
                for (int i = 0; i < gacha.prob.Length; i++)
                {
                    total += gacha.prob[i];
                }
                if (total + range > 100)
                {
                    pm.ShowPopup("エラー：全ての等賞の確率は100超えることはならない。");
                }
                else gacha.prob[gacha.rate] += range;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))//今選んだ等賞の確率をx％下げます
            {
                if (gacha.prob[gacha.rate] < range)
                {
                    pm.ShowPopup("エラー：等賞の確率はマイナスにならない。");
                }
                else gacha.prob[gacha.rate] -= range;
            }
        }
        

    }
}
