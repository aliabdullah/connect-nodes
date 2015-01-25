using UnityEngine;
using System.Collections;

#region Pair_Structure

public class Pair<T, U> {
	public Pair() {
	}
	
	public Pair(T first, U second) {
		this.First = first;
		this.Second = second;
	}
	
	public T First { get; set; }
	public U Second { get; set; }
};
#endregion

public class GameLogic : MonoBehaviour {

	const int MaxLength = 6;
	bool [,] GameBoard = new bool[MaxLength, MaxLength];
	static int Rounds;
	static int MaxRounds;
	PlayerScores playerScores = new PlayerScores();

	// Use this for initialization
	void Start () {
		Rounds = 0;
		MaxRounds = (MaxLength + 1) * MaxLength / 2;
		InitializeGameBoard ();
	}

	private void InitializeGameBoard() {
		for (int i = 0; i < MaxLength; i++) 
		{
			for (int j = 0; j < MaxLength; j++)
			{
				GameBoard[i, j] = false;
			}
		}
	}

	private Pair<int, int> ActualPosition(int pos) {
		int counter = 0;
		Pair<int, int> ReturnPos = new Pair<int, int>(-1, -1);
		for (int i = 0; i < MaxLength; i++) 
		{
			for (int j = 0; j < MaxLength - i; j++)
			{
				if(pos == counter)
				{
					ReturnPos.First = i;
					ReturnPos.Second = j;
					return ReturnPos;
				}
				counter++;
			}
		}
		return ReturnPos;
	}

	public bool CheckPosition(int pos) {
		Pair<int, int> Position = new Pair<int, int> ();
		Position = ActualPosition (pos);
		return GameBoard [Position.First, Position.Second];
	}

	public void PlayRound(int pos, int player) {
		Pair<int, int> Position = new Pair<int, int> ();
		Position = PlayRoundAux (pos);
        //print(Position.First.ToString() + "," + Position.Second.ToString());
		int TotalWonScore = CheckScore (Position);
        //print(TotalWonScore.ToString());
        if(player == 1)
			playerScores.IncrementScoreP1(TotalWonScore);
		else
			playerScores.IncrementScoreP2(TotalWonScore);
	}

	private int CheckScore(Pair<int, int> pos) {
		int totalScore = 0;
		int checkRow, checkCol, checkDiagonal;
		checkRow = checkCol = checkDiagonal = 0;
		// check row dimension
		for(int i = 0; i < MaxLength - pos.First; i++)
		{
			if (GameBoard[pos.First, i] == true) checkRow++;
		}
		if (checkRow == MaxLength - pos.First)
			totalScore += checkRow;

		// check column dimension
		for(int i = 0; i < MaxLength - pos.Second; i++)
		{
			if (GameBoard[i, pos.Second] == true) checkCol++;
		}
		if (checkCol == MaxLength - pos.Second)
			totalScore += checkCol;

		// check diagonal dimension
		int counter = 0;
		for(int i = pos.First + pos.Second, j = 0; i >= 0; i--, j++)
		{
			counter++;
			if(GameBoard[i, j] == true) checkDiagonal++;
		}
		if(checkDiagonal == counter)
			totalScore += checkDiagonal;
        //print(checkRow.ToString() + "," + checkCol.ToString() + "," + checkDiagonal.ToString());
		return totalScore;
	}

	private Pair<int, int> PlayRoundAux(int pos) {
		Pair<int, int> ReturnPos = ActualPosition (pos);
		GameBoard [ReturnPos.First, ReturnPos.Second] = true;
		return ReturnPos;
	}
	
	private bool IsGameFinished() {
		if (Rounds <= MaxRounds)
			return false;
		else
			return true;
	}
}
