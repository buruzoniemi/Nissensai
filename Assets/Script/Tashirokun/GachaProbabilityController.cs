using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GachaProbabilityController : MonoBehaviour
{
	private GatyaKabu gachaKabu;

	// Start is called before the first frame update
	void Start()
	{
		gachaKabu = GetComponent<GatyaKabu>();
	}

	// 確率を上げるメソッド
	public void IncreaseProbability(int rank, float adjustmentValue)
	{
		gachaKabu.AdjustProbability(rank, adjustmentValue);
	}

	// 確率を下げるメソッド
	public void DecreaseProbability(int rank, float adjustmentValue)
	{
		gachaKabu.AdjustProbability(rank, -adjustmentValue);
	}
}
