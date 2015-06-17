using UnityEngine;
using System.Collections;

public class RedLotus : MonoBehaviour {

	private Health healthScript;
 	Stats stats;
	private int heal;
	public int percentageOfHeal;
	private int totalHealth;

	void Start()
	{
		healthScript = (Health)FindObjectOfType (typeof(Health));
		stats = (Stats)FindObjectOfType (typeof(Stats));
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			totalHealth = stats.totalHealth;
			heal = (totalHealth / 100) * percentageOfHeal;
			healthScript.RestoreHealth(heal);
			this.gameObject.SetActive(false);
			Debug.Log("Heal is:" + heal.ToString());
		}

	}
}
