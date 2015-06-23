using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonsActive : MonoBehaviour {

	Stats buttonStat;
	public Button[] Ice;
	public Text[] IceText;
	private int iceShardLevel;
	public Button[] Avalanche;
	public Text[] AvalancheText;
	private int avalancheLevel;
	public Button[] Teleport;
	public Text[] TeleportText;
	private int teleportLevel;
	public Button[] IceWraith;
	private int iceWraithLevel;
	public Text[] IceWraithText;
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
			if(iceShardLevel != 0){
				if(i < iceShardLevel){
					IceText[i].color = Color.white;
					Ice[i].image.color = Color.cyan;
				}
				if(i == iceShardLevel)
					Ice[i].interactable = true;
				else 
					Ice[i].interactable = false;
			}
		}
		//Avalanche
		for (int i = 0; i < 4; i++) {
			if(avalancheLevel != 0){
				if(i < avalancheLevel){
					AvalancheText[i].color = Color.white;
					Avalanche[i].image.color = Color.cyan;
				}
				if(i == avalancheLevel)
					Avalanche[i].interactable = true;
				else 
					Avalanche[i].interactable = false;
			}
		}
		//Teleport
		for (int i = 0; i < 4; i++) {
			if(teleportLevel != 0){
				if(i < teleportLevel){
					TeleportText[i].color = Color.white;
					Teleport[i].image.color = Color.cyan;
				}
				if(i == teleportLevel)
					Teleport[i].interactable = true;
				else 
					Teleport[i].interactable = false;
			}
		}
		//Ice Wraith
		for (int i = 0; i < 4; i++) {
			if(iceWraithLevel != 0){
				if(i < iceWraithLevel){
					IceWraithText[i].color = Color.white;
					IceWraith[i].image.color = Color.cyan;
				}
				if(i == iceWraithLevel)
					IceWraith[i].interactable = true;
				else 
					IceWraith[i].interactable = false;
			}
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
