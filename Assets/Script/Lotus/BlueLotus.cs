using UnityEngine;
using System.Collections;

public class BlueLotus : MonoBehaviour {

	private Chi chiScript;
	Stats stats;
	private float restoreChi;
	public float percentageOfRestoreChi;
	private float totalChi;
	
	void Start()
	{
		chiScript = (Chi)FindObjectOfType (typeof(Chi));
		stats = (Stats)FindObjectOfType (typeof(Stats));
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Shimo") 
		{
			totalChi = stats.totalChi;
			restoreChi = (totalChi / 100) * percentageOfRestoreChi;
			chiScript.RestoreChi((int)restoreChi);
			this.gameObject.SetActive(false);
		}
		
	}
}
