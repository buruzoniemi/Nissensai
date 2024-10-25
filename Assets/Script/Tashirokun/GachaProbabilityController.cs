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

	// �m�����グ�郁�\�b�h
	public void IncreaseProbability(int rank, float adjustmentValue)
	{
		gachaKabu.AdjustProbability(rank, adjustmentValue);
	}

	// �m���������郁�\�b�h
	public void DecreaseProbability(int rank, float adjustmentValue)
	{
		gachaKabu.AdjustProbability(rank, -adjustmentValue);
	}
}
