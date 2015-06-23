using UnityEngine;
using System.Collections;

public class EnemySwordDamage : MonoBehaviour {

	bool canDamage = false;
	public void CanDamage(bool value)
	{
		canDamage = value;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (canDamage) {
			if (other.gameObject.tag == "Shimo") {
				other.transform.SendMessage ("Damage", 10);
				CanDamage(false);
			}
		}
	}
}
