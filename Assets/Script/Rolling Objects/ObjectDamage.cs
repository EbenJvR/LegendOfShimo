using UnityEngine;
using System.Collections;

public class ObjectDamage : MonoBehaviour {

	private Health healthScript;
	private bool gotHit;

	void Start () 
	{
		healthScript = (Health)FindObjectOfType (typeof(Health));
		gotHit = false;
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{

		if(other.gameObject.tag == "Player" && gotHit == false)
		{
			Debug.Log("Touch player");
			healthScript.Damage(50);
			gotHit = true;
		}
	}
}
