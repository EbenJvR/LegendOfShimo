using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeStats : MonoBehaviour {

	Stats upgradeStats;
	public Text healthText;
	private int health;
	public Text chiText;
	private int chi;
	public Text pointText;
	private int points;

	/*
	 * 
	 * Not Being Used
	 * 
	 * 
	 */
	// Use this for initialization
	void Start () {
		upgradeStats = GetComponent<Stats>();
		health = upgradeStats.getTotalHealth ();
		chi = upgradeStats.getTotalChi ();
		points = upgradeStats.getPoints ();
	
	}
	
	// Update is called once per frame
	void Update () {
	}


	public void Accept(){

	}

	public void resetUnits(){
		healthText.text = "Total Health: " + health.ToString();
		chiText.text = "Total Chi: " + chi.ToString();
		pointText.text = "Upgrade Points: " + points.ToString();
	}
}
