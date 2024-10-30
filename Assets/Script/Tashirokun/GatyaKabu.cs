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
    public float[] prob; // 各等賞の確率（整数または小数）
    public Text textbox; // メッセージボックスの変数宣言
    public List<string>[] prize = new List<string>[4]; // 各等賞の賞品リスト
    private bool bDebugMenu;
    private PopupManager pm;
    private GameObject canvas; // Canvasの変数宣言
    private PlayableDirector playableDirector; // Timelineの処理
    [SerializeField] private List<TimelineAsset> timelineAsset;
    [SerializeField] private GameObject mainCamera;
    private Transform playerTransform;

    private CameraZoomController cameraZoomController;

    /*
     * 確率の仕様：
     * prob[0] = 5   -> 5% (整数で書かれている場合、パーセンテージとして扱う)
     * prob[1] = 0.02 -> 0.02% (小数の場合はそのまま少数として扱う)
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
        // CameraZoomController のセットアップ
        cameraZoomController = gameObject.AddComponent<CameraZoomController>();

        for (int i = 0; i < prize.Length; i++)
        {
            prize[i] = new List<string>(); // 賞品リストの初期化
        }

        // ここで賞品の名前を代入する
        string[] a = { "胡桃", "メダル", "学校" };
        prize[1].AddRange(a);
        string[] b = { "胡桃", "メダル", "学校" };
        prize[2].AddRange(b);
        string[] c = { "胡桃", "メダル", "学校" };
        prize[3].AddRange(c);


    }

    void Start()
    {
        textbox.text = "各等賞の確率：1等 = " + DisplayProbability(prob[0]) + "%, 2等 = " + DisplayProbability(prob[1]) + "%, 3等 = " + DisplayProbability(prob[2]) + "%";
        canvas.SetActive(false);
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("vegetable"))
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                RunGacha(); // ガチャを回す
                Debug.Log("1st:" + prize[1].Count + " 2nd:" + prize[2].Count + " 3rd:" + prize[3].Count); // 等賞の残り数を表示
            }
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) // 左下のControlキーを押したら
        {
            if (bDebugMenu)
            {
                canvas.SetActive(true); //Canvasを有効する
                bDebugMenu = false;
                textbox.text = "各等賞の確率：1等 = " + DisplayProbability(prob[0]) + "%, 2等 = " + DisplayProbability(prob[1]) + "%, 3等 = " + DisplayProbability(prob[2]) + "%";
                
                
            }
            else if (!bDebugMenu)
            {
                canvas.SetActive(false); //Canvasを無効する
                bDebugMenu = true;
            }
        }

    }

    // ガチャを実行する処理
    void RunGacha()
    {
        float chance = Random.Range(0f, 100f); // 0.0 から 100.0 の間のランダムな値を生成
        float cumulativeProbability = 0f; // 累積確率
        int prizeRank = 4; // デフォルトは4等
        //Debug.Log("ガチャしたよ");
        cameraZoomController.StartZoomIn(this.transform, 1f, 2f); // ズームイン: 1秒, 待機: 2秒

        // 1等賞の抽選
        if (chance < (cumulativeProbability += ConvertToPercentage(prob[0])) && prize[1].Count > 0)
        {
            //PlayTimeline(GatyaNum.firstRank); // Timelineの再生
            GivePrize(1); // 1等賞の賞品を渡す
            prizeRank = 1;
            Debug.Log("1等");
        }
        // 2等賞の抽選
        else if (chance < (cumulativeProbability += ConvertToPercentage(prob[1])) && prize[2].Count > 0)
        {
            //PlayTimeline(GatyaNum.secondRank); // Timelineの再生
            GivePrize(2); // 2等賞の賞品を渡す
            prizeRank = 2;
            Debug.Log("2等");
        }
        // 3等賞の抽選
        else if (chance < (cumulativeProbability += ConvertToPercentage(prob[2])) && prize[3].Count > 0)
        {
            //PlayTimeline(GatyaNum.thirdRank); // Timelineの再生
            GivePrize(3); // 3等賞の賞品を渡す
            prizeRank = 3;
            Debug.Log("3等");
        }
        else
        {
            //PlayTimeline(GatyaNum.forthRank); // Timelineの再生
            Debug.Log("4等（参加賞）");
        }

        // PullUpAnimationのインスタンスに等数を通知
        GetComponent<PullUpAnimation>().SetPrizeRank(prizeRank);
    }

    // 確率をパーセンテージに変換する処理
    float ConvertToPercentage(float probability)
    {
        return probability;
    }

    // 表示用に確率をフォーマットするメソッド
    public string DisplayProbability(float probability)
    {
        return probability.ToString("F2"); // 例: "5.00" と表示
    }

    // Timelineを再生する処理
    void PlayTimeline(GatyaNum rank)
    {
        if (timelineAsset[(int)rank] != null)
        {
            playableDirector.playableAsset = timelineAsset[(int)rank];
            playableDirector.Play();
            //Debug.Log(rank.ToString() + " 等のTimelineを再生しました。");
        }
    }

    // 賞品を渡す処理
    void GivePrize(int rank)
    {
        if (prize[rank].Count > 0)
        {
            int presentIndex = Random.Range(0, prize[rank].Count); // 賞品リストからランダムに選ぶ
            string present = prize[rank][presentIndex];
            prize[rank].RemoveAt(presentIndex); // 選んだ賞品をリストから削除

            Debug.Log(rank.ToString() + " 等賞！賞品：" + present);
        }
        else
        {
            Debug.Log(rank.ToString() + " 等賞は在庫切れです。");
        }
    }

    // 賞品を追加する処理
    public void LoadPrize(int rank, string present)
    {
        prize[rank].Add(present);
    }

    public void AdjustProbability(int rank, float adjustmentValue)
    {
        // 確率を調整するロジックをここに追加
        // 例: rankに基づいて確率を変更
        Debug.Log($"Rank: {rank}, Adjustment: {adjustmentValue}");
    }
}
