using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

///<summary>
///
///</summary>
public class InputDeteciont : MonoBehaviour 
{

	void Awake () 
	{
		buyDefender=FindObjectOfType<BuyDefender>();
		cam=Camera.main;
		setting=FindObjectOfType<DefenderSetting>();
	}
	
	void Update () 
	{
		DisplayButton();
	}

	Camera cam;
	BuyDefender buyDefender;
	DefenderSetting setting;
	public LayerMask layer;
	//display button at the position of defender
	private void DisplayButton()
    {
		if (Input.GetMouseButtonDown(0) &&
			EventSystem.current.IsPointerOverGameObject() == false)
		{
			buyDefender.Hide();
			setting.Hide();

			Ray ray=cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit,1000,layer))
            {
				HolderStatus hs=hit.transform.GetComponent<HolderStatus>();
				if (hs.defender == null)
					buyDefender.Display(hs);
				else
					setting.Display(hs);

            }
		}
    }
}
