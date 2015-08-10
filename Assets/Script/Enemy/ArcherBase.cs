using UnityEngine;
using System.Collections;

public class ArcherBase : EnemyBaseClass {

	public GameObject arrow;

	// Use this for initialization
	void Start()
	{
		PutInStart ();
		health = 1;
		xpGain = 1;
		movementSpeed = 3f;
		alertRange = 7f;
		attackRange = 7;
	}
	
	void Update(){
		PutInUpdate ();
	}
	protected override void Attack(){
		base.Attack ();
		enemy.SetBool ("Alerted", false);
		Instantiate (arrow, transform.position, Quaternion.identity);
		enemy.Play ("ArcherAttack");
		counter = 0;
		enemy.SetBool ("Alerted", true);
	}
}
