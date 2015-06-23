using UnityEngine;
using System.Collections;

public class DeathFromAbove : MonoBehaviour {

	Health damage;
	
	void Start () {
		damage = (Health)FindObjectOfType(typeof(Health));
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Shimo")
		{
			damage.Damage(90);
			Destroy(transform.parent.gameObject);
		}
		if (other.tag == "Ground") {
			Destroy(transform.parent.gameObject);
		}
	}
}
