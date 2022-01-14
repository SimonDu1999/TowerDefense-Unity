using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class DefenderMachineGun : Defender
{
	public void Attack()
    {
        EnemyStatus target= SelectEnemy();
        if(target!=null)
        {
            transform.LookAt(target.transform.position);
            target.GetComponent<EnemyStatus>().Damage(atk);
            defenderAudio.Play();
            defenderAnim.Play("MG");
        }
        else
        {
            defenderAnim.Play("idle");
        }
        
    }
	
}
