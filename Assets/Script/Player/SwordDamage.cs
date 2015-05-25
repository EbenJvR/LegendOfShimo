using UnityEngine;
using System.Collections;

public class SwordDamage : MonoBehaviour {

	bool canDamage = false;
	public void CanDamage(bool value)
	{
		canDamage = value;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (canDamage) {
			if (other.gameObject.tag == "Enemy") {
				other.transform.SendMessage ("Damage", 10);
				CanDamage(false);
			}
		}
	}
}
