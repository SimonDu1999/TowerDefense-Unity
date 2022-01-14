using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

///<summary>
///
///</summary>
public class Defender : MonoBehaviour 
{


	void Start () 
	{
		destination=GameObject.FindGameObjectWithTag("Destination").transform;
		spawn=GameObject.FindObjectOfType<EnemySpawn>();
		InvokeRepeating("Attack", 0,attackSpeed);
		defenderAudio=GetComponent<AudioSource>();
		defenderAnim = GetComponentInChildren<Animation>();
	}
	
	void Update () 
	{
		
	}

	//Denfender attributes
	public int atk, attackDistance;
	public float attackSpeed;
	protected Transform destination;
	protected AudioSource defenderAudio;
	protected Animation defenderAnim;
	EnemySpawn spawn;
	public int buyPrice;

	protected EnemyStatus SelectEnemy()
    {
		if (spawn.enemyList.Count > 0)
		{
			EnemyStatus[] enemyArray = spawn.enemyList.OrderBy(
				e => Vector3.Distance(e.transform.position, destination.position)).ToArray();
			//return enemies in range
			EnemyStatus enemy=enemyArray.FirstOrDefault(e => e.hp > 0 &&
			Vector3.Distance(e.transform.position, transform.position) < attackDistance);
			if (enemy != null)
				return enemy;
		}
		return null;
    }

    public int level = 1,upPirce,maxLevel,salePirce;

    private int CalculateUpPirce()
    {
        return upPirce * level;
    }

    public int CalculateSalePirce()
    {
        return salePirce * level;
    }

    public bool Upgrade()
    {
        int price= CalculateUpPirce();
        if(GameController.insrance.GetGold()>=price&&level<maxLevel)
        {
            GameController.insrance.SetGold(-price);
            level++;
            atk += 10;
            attackDistance += 10;
            return true;
        }

        return false;
    }

}
