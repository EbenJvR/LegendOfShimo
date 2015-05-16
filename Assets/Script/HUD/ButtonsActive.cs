using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonsActive : MonoBehaviour {

	Stats buttonStat;
	UpgradeStats upgrades;
	public Button[] Ice;
	private int iceShardLevel;
	public Button[] Avalanche;
	private int avalancheLevel;
	public Button[] Teleport;
	private int teleportLevel;
	public Button[] IceWraith;
	private int iceWraithLevel;
	public Button Health;
	public Text healthText;
	private int health;
	public Button Chi;
	public Text chiText;
	private int chi;
	public Text pointText;
	private int points;

	
	void Start () {
		buttonStat = GetComponent<Stats>();
		upgrades = GetComponent<UpgradeStats>();
	}
	// Update is called once per frame
	void Update () {
		healthText.text = "Total Health: " + health.ToString();
		chiText.text = "Total Chi: " + chi.ToString();
		pointText.text = "Upgrade Points: " + points.ToString();
		if (points > 0) {
			SetInteractable ();
		} else {
			RemoveInteractable ();
		}
	}

	//Use gets and sets from upgrade stats
	//!this

	public void SetValues(){
		points = buttonStat.getPoints ();
		health = buttonStat.getTotalHealth ();
		chi = buttonStat.getTotalChi ();
		iceShardLevel = buttonStat.getIceShardLevel ();
		avalancheLevel = buttonStat.getAvalanceLevel ();
		teleportLevel = buttonStat.getTeleportLevel ();
		iceWraithLevel = buttonStat.getIceWraithLevel ();
	}

	void SetInteractable(){
		//Ice Shard
		for (int i = 0; i < 4; i++) {
			if(i != iceShardLevel)
				Ice[i].interactable = false;
			else 
				Ice[i].interactable = true;
		}
		//Avalanche
		for (int i = 0; i < 4; i++) {
			if(i!= avalancheLevel)
				Avalanche[i].interactable = false;
			else 
				Avalanche[i].interactable = true;
		}
		//Teleport
		for (int i = 0; i < 4; i++) {
			if(i!= teleportLevel)
				Teleport[i].interactable = false;
			else 
				Teleport[i].interactable = true;
		}
		//Ice Wraith
		for (int i = 0; i < 4; i++) {
			if(i!= iceWraithLevel)
				IceWraith[i].interactable = false;
			else 
				IceWraith[i].interactable = true;
		}
		//Health
		Health.interactable = true;
		//Chi
		Chi.interactable = true;
	}

	void RemoveInteractable(){
		//Ice Shard
		for (int i = 0; i < 4; i++) {
			Ice[i].interactable = false;
		}
		//Avalanche
		for (int i = 0; i < 4; i++) {
			Avalanche[i].interactable = false;
		}
		//Teleport
		for (int i = 0; i < 4; i++) {
			Teleport[i].interactable = false;
		}
		//Ice Wraith
		for (int i = 0; i < 4; i++) {
			IceWraith[i].interactable = false;
		}
		//Health
		Health.interactable = false;
		//Chi
		Chi.interactable = false;
	}

	public void LevelIceShard(){
		iceShardLevel++;
		points--;
	}
	public void LevelAvalanche(){
		avalancheLevel++;
		points--;
	}
	public void LevelTeleport(){
		teleportLevel++;
		points--;
	}
	public void LevelIceWraith(){
		iceWraithLevel++;
		points--;
	}
	public void LevelHealth(){
		health += 10;
		points--;
	}
	public void LevelChi(){
		chi += 10;
		points--;
	}



	public void SaveStats(){
		buttonStat.setIceShardLevel (iceShardLevel);
		buttonStat.setAvalanceLevel (avalancheLevel);
		buttonStat.setTeleportLevel (teleportLevel);
		buttonStat.setIceWraithLevel (iceWraithLevel);
		buttonStat.setTotalHealth (health);
		buttonStat.setTotalChi (chi);
		buttonStat.setPoints (points);
	}
}
