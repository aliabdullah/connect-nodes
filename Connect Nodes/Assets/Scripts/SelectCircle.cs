using UnityEngine;
using System.Collections;
using System;

public class SelectCircle : MonoBehaviour {
	public Sprite RedSprite;
	public Sprite BlueSprite;
	public Sprite GreenSprite;
	public Sprite YellowSprite;
    public GameObject RedArrow;
    public GameObject BlueArrow;
	static bool PlayerTurn = true;
	static GameLogic gameLogic = new GameLogic();

    void Start()
    {
        RedArrow.GetComponent<SpriteRenderer>().enabled = true;
        BlueArrow.GetComponent<SpriteRenderer>().enabled = false;
    }

	void OnMouseDown()
	{
		int pos = Int32.Parse (name);
		if(!gameLogic.CheckPosition(pos))
		{
            //print(gameLogic.CheckPosition(pos));
			if(PlayerTurn) {
				GetComponent<SpriteRenderer> ().sprite = RedSprite;
                RedArrow.GetComponent<SpriteRenderer>().enabled = false;
                BlueArrow.GetComponent<SpriteRenderer>().enabled = true;
				PlayerTurn = false;
				gameLogic.PlayRound(pos, 1);
			} else {
				GetComponent<SpriteRenderer> ().sprite = BlueSprite;
                RedArrow.GetComponent<SpriteRenderer>().enabled = true;
                BlueArrow.GetComponent<SpriteRenderer>().enabled = false;
				PlayerTurn = true;
				gameLogic.PlayRound(pos, 2);
			}
		}
	}
}
