using UnityEngine;
using System.Collections;

public class SelectCircle : MonoBehaviour {
	public Sprite RedSprite;
	public Sprite BlueSprite;
	public Sprite GreenSprite;
	public Sprite YellowSprite;
	bool CirclePushed = false;
	static bool PlayerTurn = true;
	
	void OnMouseDown()
	{
		if(!CirclePushed)
		{
			if(PlayerTurn) {
				GetComponent<SpriteRenderer> ().sprite = RedSprite;
				PlayerTurn = false;
			} else {
				GetComponent<SpriteRenderer> ().sprite = BlueSprite;
				PlayerTurn = true;
			}
			CirclePushed = true;
		}
	}
}
