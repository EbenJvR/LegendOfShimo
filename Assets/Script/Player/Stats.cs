using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour{

	public int totalHealth = 100; //Total Player Health
	public int currentHealth = 100; //Current Player Health
	public int totalChi = 100; //Total Player Chi
	public int currentChi = 100; //Current Player Chi
	public int currentLevel = 0; //Current Player Level
	public int currentXp = 0; //Current Player XP value
	public int levelPoints = 50; //Current Player Level Up Points
	public int iceShardLevel = 1; //Ice Shard Level
	public int avalanceLevel = 1; //Avalanche Level
	public int teleportLevel = 1; //Teleport Level
	public int iceWraithLevel = 1; //Ice Wraith Level
	private int[] statAmount = new int[15]; //Save Array

	#region Health
	//Total Health
	public int getTotalHealth (){
		return totalHealth;
	}
	public void setTotalHealth(int value){
		totalHealth = value;
	}
	//Current Health
	public int getCurrentHealth (){
		return currentHealth;
	}
	//Set Current Health
	public void setCurrentHealth(int value){
		currentHealth = value;
	}
	//Reduce Current Health
	public void reduceCurrentHealth(int value){
		currentHealth -= value;
	}
	//Increase Current Health
	public void increaseCurrentHealth(int value){
		currentHealth += value;
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
	public int getCurrentChi (){
		return currentChi;
	}
	//Set Current Chi
	public void setCurrentChi(int value){
		currentChi = value;
	}
	//Reduce Current Chi
	public void reduceCurrentChi(int value){
		currentChi -= value;
	}
	//Increase Current Chi
	public void increaseCurrentChi(int value){
		currentChi += value;
	}
	#endregion
	#region Level_Xp_Points
	//Points gained from leveling
	public int getPoints(){
		return levelPoints;
	}
	//Set Level Points
	public void setPoints(int value){
		levelPoints = value;
	}
	//Get Current level
	public int getLevel(){
		return currentLevel;
	}
	//Set Current Level
	public void setLevel(int value){
		currentLevel = value;
	}
	//Get Current Xp
	public float getCurrentXp(){
		return currentXp;
	}
	//Set Current Xp
	public void setCurrentXp(int value){
		currentXp = value;
	}
	//Increase Current Xp
	public void increaseCurrentXp(int value){
		currentXp += value;
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
	#region Save/Load
	public int[] SaveStats(){
		statAmount [0] = totalHealth;
		statAmount [1] = currentHealth;
		statAmount [2] = totalChi;
		statAmount [3] = currentChi;
		statAmount [4] = currentLevel;
		statAmount [5] = currentXp;
		statAmount [6] = levelPoints;
		statAmount [7] = iceShardLevel;
		statAmount [8] = avalanceLevel;
		statAmount [9] = teleportLevel;
		statAmount [10] = iceWraithLevel;
		return statAmount;
	}
	public void LoadStats(int[] value){
		totalHealth = value[0];
		currentHealth = value[1];
		totalChi = value[2];
		currentChi = value[3];
		currentLevel = value[4];
		currentXp = value[5];
		levelPoints = value[6];
		iceShardLevel = value[7];
		avalanceLevel = value[8];
		teleportLevel = value[9];
		iceWraithLevel = value[10];
	}
	#endregion



}
