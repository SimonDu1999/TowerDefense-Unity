using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>
public class GameController : MonoBehaviour 
{
	//Text textGold,textIntrude;
	int gold = 400;
	void Start () 
	{
		insrance=this;
	}
	
	void Update () 
	{
		
	}

	public static GameController insrance;
	public void SetGold(int amount)
    {
		gold += amount;
    }

	public int GetGold()
    {
		return gold;
    }
}
