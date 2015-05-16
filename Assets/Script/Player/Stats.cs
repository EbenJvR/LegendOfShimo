using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class Stats:MonoBehaviour{

	public int totalHealth = 100;
	public float currentHealth = 100;
	public int totalChi = 100;
	public float currentChi = 81;
	public int currentLevel = 0;
	public float currentXp = 0;
	public int levelPoints = 0;
	public int iceShardLevel = 0;
	public int avalanceLevel = 2;
	public int teleportLevel = 1;
	public int iceWraithLevel = 4;

	#region Health
	//Total Health
	public int getTotalHealth (){
		return totalHealth;
	}
	public void setTotalHealth(int value){
		totalHealth = value;
	}
	//Current Health
	public float getCurrentHealth (){
		return currentHealth;
	}
	public void setCurrentHealth(float value){
		currentHealth = value;
	}
	#endregion
	#region Chi
	//Total Chi
	public int getTotalChi (){
		return totalChi;
	}
	public void setTotalChi(int value){
		totalChi = value;
	}
	//Current Chi
	public float getCurrentChi (){
		return currentChi;
	}
	public void setCurrentChi(float value){
		currentChi = value;
	}
	#endregion
	#region Level_Xp_Points
	//Points gained from leveling
	public int getPoints(){
		return levelPoints;
	}
	public void setPoints(int value){
		levelPoints = value;
	}
	//Current level
	public int getLevel(){
		return currentLevel;
	}
	public void setLevel(int value){
		currentLevel = value;
	}
	//Current Xp
	public float getCurrentXp(){
		return currentXp;
	}
	public void setCurrentXp(float value){
		currentXp = value;
	}
	#endregion
	#region Upgrades
	//Ice Shard
	public int getIceShardLevel(){
		return iceShardLevel;
	}
	public void setIceShardLevel(int value){
		iceShardLevel = value;
	}
	//Avalanche
	public int getAvalanceLevel(){
		return avalanceLevel;
	}
	public void setAvalanceLevel(int value){
		avalanceLevel = value;
	}
	//Teleport
	public int getTeleportLevel(){
		return teleportLevel;
	}
	public void setTeleportLevel(int value){
		teleportLevel = value;
	}
	//Ice Wraith
	public int getIceWraithLevel(){
		return iceWraithLevel;
	}
	public void setIceWraithLevel(int value){
		iceWraithLevel = value;
	}

	#endregion



}
