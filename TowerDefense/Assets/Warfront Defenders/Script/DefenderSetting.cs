using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class DefenderSetting : MonoBehaviour 
{

	void Start () 
	{
		cam = Camera.main;
		Hide();
	}
	
	void Update () 
	{
		
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	HolderStatus holder; Camera cam;
	Defender defender;
	public void Display(HolderStatus hs)
	{
		holder = hs;

		defender=holder.defender.GetComponent<Defender>();

		transform.position = RectTransformUtility.WorldToScreenPoint
			(cam, holder.transform.position);

		gameObject.SetActive(true);
	}

    //update denfender event
    public void OnClickUp()
    {
        if (defender.Upgrade())
        {
            Hide();
        }
    }

    //sell defender
    public void OnClickSale()
    {
        GameController.insrance.SetGold(defender.CalculateSalePirce());
        Destroy(holder.defender);
        Hide();
    }

}
