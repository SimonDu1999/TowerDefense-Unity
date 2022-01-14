using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class EnemyStatus : MonoBehaviour 
{

	void Start () 
	{
		CalculatePoint();
		transform.LookAt(wayPoints[0]);
		anim = GetComponentInChildren<Animation>();
	}
	
	void Update () 
	{
		Movement();
	}

	public Transform wayPointRoot;
	
	Vector3[] wayPoints;//waypoint container
	//calculate the way point
	private void CalculatePoint()
    {
		wayPoints = new Vector3[wayPointRoot.childCount];
        for (int i = 0; i < wayPointRoot.childCount; i++)
        {
			wayPoints[i] = wayPointRoot.GetChild(i).position;
        }
    }

	public int moveSpeed = 10;
	int index = 0;
	private void Movement()
    {
		if (hp <= 0) return;
		//1 move
		transform.position=Vector3.MoveTowards(transform.position, wayPoints[index], Time.deltaTime * moveSpeed);
		//2 find the way point 
		if(Vector3.Distance(transform.position,wayPoints[index])<0.1f)
        {
			if(index < wayPoints.Length - 1)
            {
				index++;
				transform.LookAt(wayPoints[index]);//让小兵注视每一个路点
			}
			else
            {
				Destroy(gameObject);
				FindObjectOfType<EnemySpawn>().enemyList.Remove(this);
            }
			
        }
		//3 disappear
		

	}

	public int hp;

	public void Damage(int atk)
    {
		hp -= atk;
		if (hp<=0)
        {
			Dead();//soldier die
        }
    }

	Animation anim;
	public void Dead()
    {
		//play animation
		if(this.name.StartsWith("Soldier"))
        {
			anim.Play("die");
        }
		Destroy(gameObject,1);
		FindObjectOfType<EnemySpawn>().enemyList.Remove(this);
    }
}
