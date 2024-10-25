using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeChoice : MonoBehaviour
{
	public Button button; // ボタンの宣言
	public Button EnterButton;
	public InputField inputField; // 確率を入力するためのInputField
	public int prizeRank; // ボタンが対応する等賞のランク
	private GatyaKabu gatyaKabu; // GatyaKabuのインスタンス

	void Start()
	{
		// GatyaKabuを取得
		gatyaKabu = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GatyaKabu>(); // 適切なGameObject名に変更してください
		if (button != null) button.onClick.AddListener(OnButtonClick); // クリック判定の設定
		if (EnterButton != null) EnterButton.onClick.AddListener(SubmitProbability); //クリック判定
	}

	void OnButtonClick() // このボタンをクリックしたら
	{
		string name = button.gameObject.name; // クリックされたボタンの名前を取得

		// 入力フィールドを表示
		inputField.gameObject.SetActive(true);
		inputField.placeholder.GetComponent<Text>().text = "確率を入力"; // プレースホルダーの設定
		inputField.text = ""; // 入力フィールドをクリア

		// ボタン名に応じてランクを設定
		if (name == "first") prizeRank = 0; // 1等賞
		else if (name == "second") prizeRank = 1; // 2等賞
		else if (name == "third") prizeRank = 2; // 3等賞
	}

	public void SubmitProbability() // 確率を確定するメソッド
	{
		float probability;
		if (float.TryParse(inputField.text, out probability))
		{
			// 確率を設定
			gatyaKabu.prob[prizeRank] = probability;
			Debug.Log($"Rank: {prizeRank + 1}, Probability set to: {probability}%");

			// 入力フィールドを非表示
			inputField.gameObject.SetActive(false);
		}
		else
		{
			Debug.LogWarning("無効な確率値です。");
		}
	}
}