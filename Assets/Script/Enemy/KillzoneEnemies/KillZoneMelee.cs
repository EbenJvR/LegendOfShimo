using UnityEngine;
using System.Collections;

public class KillZoneMelee : EnemyBaseClass {

	EnemySwordDamage sDmg;
	//	private XP xpScript;
	void Start()
	{
		PutInStart ();
		health = 1;
		xpGain = 1;
		movementSpeed = 4f;
		alertRange = 5000f;
		attackRange = 0.5f;
		sDmg = (EnemySwordDamage)FindObjectOfType(typeof(EnemySwordDamage));
		//		attackSpeed = 2;
		//		attackRange = 2;
	}
	
	void Update(){
		PutInUpdate ();
	}
	protected override void Attack(){
		base.Attack ();
		sDmg.CanDamage(true);
		enemy.Play ("MeleeAttack");
		counter = 0;
	}
}
