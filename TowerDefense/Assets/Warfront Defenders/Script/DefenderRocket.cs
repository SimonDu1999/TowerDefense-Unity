using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class DefenderRocket : Defender
{
	EnemyStatus target;
	public void Attack()
    {
        target = SelectEnemy();
        if(target!=null)
        {
            // let the denfender watch the enemies
            transform.LookAt(target.transform.position);
            defenderAnim.Play("US_R_fire");
            Invoke("Shoot", attackSpeed);
        }
        else
        {
            defenderAnim.Play("US_R_idle");
        }
    }

    public Transform shootPos;

    //shoot the rocket
    public void Shoot()
    {

        GameObject rocketBoom=Instantiate(Resources.Load("Prefabs/rocket"),
            shootPos.position, transform.rotation)as GameObject;
        Rocket instrance = rocketBoom.GetComponent<Rocket>();
        instrance.attackTarget = target.transform;
        instrance.attack = atk;
        defenderAudio.Play();
    }
}
