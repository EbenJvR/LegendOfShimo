using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour{

	public int totalHealth = 100;
	public int currentHealth = 100;
	public int totalChi = 100;
	public int currentChi = 100;
	public int currentLevel = 0;
	public int currentXp = 0;
	public int levelPoints = 50;
	public int iceShardLevel = 1;
	public int avalanceLevel = 1;
	public int teleportLevel = 1;
	public int iceWraithLevel = 1;
	private int[] statAmount = new int[15];

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
	public void setCurrentHealth(int value){
		currentHealth = value;
	}
	public void reduceCurrentHealth(int value){
		currentHealth -= value;
	}
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
	public void setCurrentChi(int value){
		currentChi = value;
	}
	public void reduceCurrentChi(int value){
		currentChi -= value;
	}
	public void increaseCurrentChi(int value){
		currentChi += value;
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
	public void setCurrentXp(int value){
		currentXp = value;
	}
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
