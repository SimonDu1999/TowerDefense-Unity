using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class EnemySpawn : MonoBehaviour 
{

	void Start () 
	{
		enemyList = new List<EnemyStatus>();
		StartCoroutine(Spawn());
		
	}

	void Update () 
	{
		
	}

	//Enemy
	public GameObject[] enemyArray;
	public float spawnInterval=2,batchInterval=8;
	public int enemyCount=0,btachCount=10;
	private int enemyID;
	public List<EnemyStatus> enemyList;
	private IEnumerator Spawn()
    {
        do
        {
			
			int number=Random.Range(1,11);
			if(number>9)
            {
				enemyID = 1;//tank
            }
            else
            {
				enemyID = 0;//sodier
			}
			if(enemyCount%btachCount==0)
            {
				yield return new WaitForSeconds(batchInterval);
            }
			else
            {
				yield return new WaitForSeconds(spawnInterval);
			}

			GameObject enemy=Instantiate(enemyArray[enemyID], transform.position, Quaternion.identity);
			EnemyStatus enemyStatus = enemy.GetComponent<EnemyStatus>();
			enemyStatus.moveSpeed = Random.Range(10, 16);
			enemyList.Add(enemyStatus);
			enemyCount++;
        } while (true);

    }

}
