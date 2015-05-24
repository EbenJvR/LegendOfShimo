using UnityEngine;
using System.Collections;

public class EnemyBaseClass : MonoBehaviour {

	Transform player = null;
	float movementSpeed;
	float movementRange;
	float attackSpeed;
	float attackRange;
	public float health;
	int xpGain;
	bool dead;
	float alertRange = 50f;
	private XP xpScript;
	public GameObject alert;
	bool playerInRange;
	public GameObject rayOrigin;
	Ray2D rangeRay;
	RaycastHit2D rayHit;

	void Start () {
		xpScript = (XP)FindObjectOfType (typeof(XP));
		alert.SetActive (false);
	}
	void Update () 
	{
		player = GameObject.FindWithTag("Player").transform;

		Debug.DrawRay (rayOrigin.transform.position, (player.transform.position-rayOrigin.transform.position), Color.red); 
		if(Physics2D.Raycast(rayOrigin.transform.position, (player.transform.position-rayOrigin.transform.position), alertRange))
		{
			if(rayHit)
			{
				Debug.Log ("Player In Range");
				playerInRange = true;
				alert.SetActive(true);
			}
		}
		if (health <= 0 && dead == false)
		{
			Die ();
		}
	}
	void Move()
	{

	}
	void Patrol()
	{

	}
	public void Die()
	{
		GameObject.Destroy (gameObject);
		dead = true;
		xpScript.increaseXP (xpGain);
	}
	void Damage(float value)
	{
		health -= value;
	}
}
