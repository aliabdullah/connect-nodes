using UnityEngine;
using System.Collections;

public class PlayerScores : MonoBehaviour {
	public GameObject ScoreP1;
	public GameObject ScoreP2;
	int Player1_Score = 0;
	int Player2_Score = 0;
	public void IncrementScoreP1(int value)
	{
		Player1_Score += value;
		ScoreP1.GetComponent<TextMesh> ().text = Player1_Score.ToString ();
	}
	public void IncrementScoreP2(int value)
	{
		Player2_Score += value;
		ScoreP2.GetComponent<TextMesh> ().text = Player2_Score.ToString ();
	}
}
