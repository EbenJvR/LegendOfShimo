using UnityEngine;
using System.Collections;

public class SwordDamage : MonoBehaviour {

	Stats damage;
	bool canDamage = false;
	public TrailRenderer trail;

	void Start() {
		damage = (Stats)FindObjectOfType (typeof(Stats));

	}

	void Update(){
		if (canDamage == true)
			trail.enabled = true;
		if(canDamage == false)
			trail.enabled = false;
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
