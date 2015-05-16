using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	Health damage;

	void Start () {
		damage = (Health)FindObjectOfType(typeof(Health));
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			damage.Damage(1000000f);
		}
		if (other.tag == "Enemy") {
			other.transform.SendMessage("Damage",10000f);
		}
	}
}
