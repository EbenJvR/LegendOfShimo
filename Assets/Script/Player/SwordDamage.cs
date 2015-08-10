using UnityEngine;
using System.Collections;

public class SwordDamage : MonoBehaviour {

	Stats damage;
	bool canDamage = false;

	void Start() {
		damage = (Stats)FindObjectOfType (typeof(Stats));
	}

	public void CanDamage(bool value)
	{
		canDamage = value;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (canDamage) {
			if (other.gameObject.tag == "Enemy") {
				other.transform.SendMessage ("Damage", damage.meleeDamage);
				CanDamage(false);
			}
		}
	}
}
