using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class BuyDefender : MonoBehaviour
{
	GameObject gun,rocket;
	void Start()
	{
		Hide();
		cam=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		gun=Resources.Load<GameObject>("Prefabs/DefenderMachineGun");
		rocket = Resources.Load<GameObject>("Prefabs/DefenderRocket");
	}

	void Update()
	{

	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	HolderStatus holder; Camera cam;
	public void Display(HolderStatus hs)
	{
		holder = hs;
		transform.position = RectTransformUtility.WorldToScreenPoint
			(cam, holder.transform.position);
		gameObject.SetActive(true);
	}

	public void Buy(string type)
    {
		GameObject targetClone = null;
		if(type=="gun")
        {
			targetClone = gun;
        }
		else if(type=="rocket")
        {
			targetClone = rocket;
		}

		//denfender generation and price
		int price=targetClone.GetComponent<Defender>().buyPrice;
		if(GameController.insrance.GetGold()>price)
		{
			holder.defender = GameObject.Instantiate(targetClone
			, holder.transform.position, Quaternion.identity);
			GameController.insrance.SetGold(-price);
			Hide();
		}
    }
}