using UnityEngine;
using System.Collections;

public class BlueLotus : MonoBehaviour {

	private Chi chiScript;
	Stats stats;
	private int restoreChi;
	public int percentageOfRestoreChi;
	private int totalChi;
	
	void Start()
	{
		chiScript = (Chi)FindObjectOfType (typeof(Chi));
		stats = (Stats)FindObjectOfType (typeof(Stats));
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			totalChi = stats.totalChi;
			restoreChi = (totalChi / 100) * percentageOfRestoreChi;
			chiScript.RestoreChi(restoreChi);
			this.gameObject.SetActive(false);
			Debug.Log("Restore chi is:" + restoreChi.ToString());
		}
		
	}
}
