using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

///<summary>
///script for rocket to trace the enemies
///</summary>
public class Rocket : MonoBehaviour 
{

	void Start () 
	{
		
	}
	
	void Update () 
	{
		Movement();
	}
	//movement speed, target, explosion range, attack damage
	public float moveSpeed;
	public int attack,explodeRange;
	public Transform attackTarget;

	public void Movement()
    {
		if(attackTarget==null)
        {
			Destroy(gameObject);
        }
		else
        {
			//注视目标
			transform.LookAt(attackTarget.position);
			transform.position=Vector3.MoveTowards(transform.position,
				attackTarget.position+new Vector3(0,1.5f,0), moveSpeed * Time.deltaTime);

        }
    }

	private void Explode()
    {
		
		EnemyStatus[] enemyArray=FindObjectOfType<EnemySpawn>().enemyList.Where(e => e.hp > 0 &&
		Vector3.Distance(e.transform.position, transform.position) < explodeRange).ToArray();

		// lose HP when in explosion range
		foreach(var item in enemyArray)
        {
			item.Damage(attack);
        }
		Destroy(gameObject);//eliminate the rocket
		//special effect of rocket
		Destroy(Instantiate(Resources.Load("Prefabs/Explosion02"),
			transform.position, Quaternion.identity), 1.5f);
    }
	public void OnTriggerEnter(Collider other)
    {
		if(other.tag=="target")
        {
			Explode();
        }
    }


}
