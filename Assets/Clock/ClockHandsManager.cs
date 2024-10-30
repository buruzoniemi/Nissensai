using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMove : MonoBehaviour
{
    [SerializeField] private int TimeNum = 10;            //一周にかかる時間を変えるための変数、単位は 分 。
   
    private float TimeCalculate = 0;    //タイマーの計算に使う値を渡す変数
    private bool MoningNight = true;    //朝夜のフラグ
    public GameObject particleObject;   //transform.RotateのZ座標を取得するためのもの

    public Material[] sky;
    int num = 0; 


    void Start()
    {
        // VSyncCount を Dont Sync に変更
        QualitySettings.vSyncCount = 0;

        //60fpsを目標に設定
        Application.targetFrameRate = 60;

        //現在の時計が何分設定なのかをデバッグログに表示させる
        //Debug.Log(TimeNum + "分で１周する時計");

        //フラグが朝の状態のことを1度だけ表示
        if (MoningNight == true)
        {
            //Debug.Log("朝");
        }

        //TimeNumに入力された値に
        TimeCalculate = -1.0f / (TimeNum * 10.0f);
    }


    void Update()
    {
        
        //Z座標を移動させ続ける
        transform.Rotate(new Vector3(0, 0, TimeCalculate));


        //Z座標（Rotation）が0～-180の間はtrue(朝)、１～180の間はfalse（夜）
        if (gameObject.transform.localEulerAngles.z <= 180 && MoningNight == true && gameObject.transform.localEulerAngles.z != 0)
        {

            num = 1;


            MoningNight = false;
            //Debug.Log("夜");
        }

        if (gameObject.transform.localEulerAngles.z <= 0)
        {
            num = 0;

            MoningNight = true;
            //Debug.Log("朝");
        }

        RenderSettings.skybox = sky[num];
    }
}
