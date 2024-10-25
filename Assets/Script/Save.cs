using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    PopupManager pm;
	private void Awake()
	{
        pm = GameObject.Find("Canvas").GetComponent<PopupManager>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.S)) SaveData(); //保存はSキー
            if (Input.GetKeyDown(KeyCode.L)) LoadData(); //読込はLキー
        }
        

    }

    void SaveData()
    {
        if (Application.isPlaying)
        {
            Gacha gacha = GetComponent<Gacha>();
            for(int i = 1;i<4;i++)
            {
                for (int j = 0; j < gacha.prize[i].Count; j++)
                {
                    PlayerPrefs.SetString("prize" + i.ToString() + j.ToString(), gacha.prize[i][j]);
                }
                PlayerPrefs.SetInt("prizeCount" + i.ToString(), gacha.prize[i].Count);
                PlayerPrefs.SetInt("prob" + i.ToString(), gacha.prob[i]);
            }
            PlayerPrefs.Save();
            pm.ShowPopup("保存しました。");
        }
    }

    void LoadData()
    {
        if (Application.isPlaying)
        {
            Gacha gacha = GetComponent<Gacha>();
            for (int i=1;i<4;i++)
            {
                gacha.prize[i].Clear();
                for (int j=0;j < PlayerPrefs.GetInt("prizeCount" + i.ToString());j++)
                {
                    gacha.LoadPrize(i, PlayerPrefs.GetString("prize" + i.ToString() + j.ToString()));
                }
                gacha.prob[i] = PlayerPrefs.GetInt("prob" + i.ToString());
            }
            pm.ShowPopup("読込完了しました");
        }
    }
}
