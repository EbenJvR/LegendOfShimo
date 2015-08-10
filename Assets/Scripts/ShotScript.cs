using UnityEngine;
using System.Collections;
	
	/// <summary>
	/// Projectile behavior
	/// </summary>
public class ShotScript : MonoBehaviour {
	// 1 - Designer variables

	/// <summary>
	/// Damage inflicted
	/// </summary>
	public int damage = 1;

	/// <summary>
	/// Projectile gamage player or enemies?
	/// </summary>
	public bool isEnemyShot = false;

	void Start () {
	// 2 - Limited to live to avoid any leak
		Destroy (gameObject, 20); // 20sec
	}
}
