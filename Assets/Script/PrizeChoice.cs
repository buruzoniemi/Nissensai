using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeChoice : MonoBehaviour
{
	public Button button; // ボタンの宣言
	public Button[] EnterButton;
	public InputField inputField; // 確率を入力するためのInputField
	public int prizeRank; // ボタンが対応する等賞のランク
	private GatyaKabu gatyaKabu; // GatyaKabuのインスタンス

	void Start()
	{
		// ボタン名に応じてランクを設定
		if (name == "first") prizeRank = 0; // 1等賞
		else if (name == "second") prizeRank = 1; // 2等賞
		else if (name == "third") prizeRank = 2; // 3等賞

		// GatyaKabuを取得
		gatyaKabu = GameObject.FindGameObjectWithTag("Player").GetComponent<GatyaKabu>(); // 適切なGameObject名に変更してください
		if (button != null) button.onClick.AddListener(OnButtonClick); // クリック判定の設定
		if (EnterButton[prizeRank] != null) EnterButton[prizeRank].onClick.AddListener(SubmitProbability); //クリック判定
	}

	void OnButtonClick() // このボタンをクリックしたら
	{
		string name = button.gameObject.name; // クリックされたボタンの名前を取得

		// 入力フィールドを表示
		inputField.gameObject.SetActive(true);
		EnterButton[prizeRank].gameObject.SetActive(true);
		inputField.placeholder.GetComponent<Text>().text = "確率を入力"; // プレースホルダーの設定
		inputField.text = ""; // 入力フィールドをクリア

		hide(prizeRank);
	}

	public void SubmitProbability() // 確率を確定するメソッド
	{
		float probability;
		if (float.TryParse(inputField.text, out probability))
		{
			// 確率を設定
			gatyaKabu.prob[prizeRank] = probability;
			gatyaKabu.textbox.text = "各等賞の確率：1等 = " + gatyaKabu.DisplayProbability(gatyaKabu.prob[0]) + "%, 2等 = " + gatyaKabu.DisplayProbability(gatyaKabu.prob[1]) + "%, 3等 = " + gatyaKabu.DisplayProbability(gatyaKabu.prob[2]) + "%";
			// 入力フィールドを非表示
			inputField.gameObject.SetActive(false);
			EnterButton[prizeRank].gameObject.SetActive(false);
		}
		else
		{
			Debug.LogWarning("無効な確率値です。");
		}
	}

	private void hide(int Rank)
    {
		if(Rank == 0)
        {
			EnterButton[prizeRank + 1].gameObject.SetActive(false);
			EnterButton[prizeRank + 2].gameObject.SetActive(false);
        }
		else if(Rank == 1)
        {
			EnterButton[prizeRank - 1].gameObject.SetActive(false);
			EnterButton[prizeRank + 1].gameObject.SetActive(false);
		}
		else if (Rank == 2)
		{
			EnterButton[prizeRank - 1].gameObject.SetActive(false);
			EnterButton[prizeRank - 2].gameObject.SetActive(false);
		}
	}
}