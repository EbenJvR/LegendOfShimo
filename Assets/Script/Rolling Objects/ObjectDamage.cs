using UnityEngine;
using System.Collections;

public class ObjectDamage : MonoBehaviour {

	private Health healthScript;

	void Start () 
	{
		healthScript = (Health)FindObjectOfType (typeof(Health));
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{

		if(other.gameObject.tag == "Player")
		{
			healthScript.Damage(50);
		}
	}
}
