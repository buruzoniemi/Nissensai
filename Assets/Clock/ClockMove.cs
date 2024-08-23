using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMove : MonoBehaviour
{
    private float[] fVectorZ = { -0.05f, -0.01f, -0.005f };  //１分、５分、10分の場合の移動量の配列
    private int[] iIVXMinute = { 1, 5, 10 };//現在の時計が何分設定なのかをデバッグログに表示させるための配列

    //一周にかかる時間を１分にしたいときは０を代入、
    //５分の時は１を代入、10分の時は２を代入
    private int TimeNum = 0;            //一周にかかる時間を変えるための変数
    private bool MoningNight = true;    //朝夜のフラグ
    public GameObject particleObject;   //transform.RotateのZ座標を取得するためのもの


    void Start()
    {
        //現在の時計が何分設定なのかをデバッグログに表示させる
        Debug.Log(iIVXMinute[TimeNum] + "分で１周する時計");
    }


    void Update()
    {
        //Z座標を移動させ続ける
        transform.Rotate(new Vector3(0, 0, fVectorZ[TimeNum]));

        //Z座標（Rotation）が0～-180の間はtrue(朝)、１～180の間はfalse（夜）
        if (gameObject.transform.localEulerAngles.z <= 180 && MoningNight == true && gameObject.transform.localEulerAngles.z != 0)
        {
            MoningNight = false;
            Debug.Log("夜");
        }

        if (gameObject.transform.localEulerAngles.z <= 0)
        {
            MoningNight = true;
            Debug.Log("朝");
        }
    }
}
