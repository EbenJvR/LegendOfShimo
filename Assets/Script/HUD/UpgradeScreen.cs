using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour {

	Stats stats;
	Abilities abilities;
	XP xpStats;
	Menus menu;
	public Text[] currentStats;
	public Text[] abilityStats;
	int ability;
	int level;
	int currentMenu = 1;
	public GameObject IceShard;
	Vector3 IceShardStart;
	public GameObject Avalanche;
	Vector3 AvalancheStart;
	public GameObject Teleport;
	Vector3 TeleportStart;
	public GameObject IceWraith;
	Vector3 IceWraithStart;


	void Start () {
		IceShardStart = new Vector3 (IceShard.gameObject.transform.position.x, 
		                             IceShard.gameObject.transform.position.y, IceShard.gameObject.transform.position.z);
		AvalancheStart = new Vector3 (Avalanche.gameObject.transform.position.x, 
		                              Avalanche.gameObject.transform.position.y, Avalanche.gameObject.transform.position.z);
		TeleportStart = new Vector3 (Teleport.gameObject.transform.position.x, 
		                             Teleport.gameObject.transform.position.y, Teleport.gameObject.transform.position.z);
		IceWraithStart = new Vector3 (IceWraith.gameObject.transform.position.x, 
		                              IceWraith.gameObject.transform.position.y, IceWraith.gameObject.transform.position.z);
		stats = GetComponent<Stats> ();
		abilities = GetComponent<Abilities> ();
		xpStats = GetComponent<XP> ();
		menu = GetComponent<Menus> ();
		RefreshStats ();
		IceShard.gameObject.transform.position = IceShardStart;
		Avalanche.gameObject.transform.position = new Vector3(AvalancheStart.x + 1000,AvalancheStart.y,AvalancheStart.z);
		Teleport.gameObject.transform.position = new Vector3(TeleportStart.x + 1000,TeleportStart.y,TeleportStart.z);
		IceWraith.gameObject.transform.position = new Vector3(IceWraithStart.x + 1000,IceWraithStart.y,IceWraithStart.z);
	}
	
	void Update () {
	}
	public void HoverInfo(string numbers) {
		string[] info;
		info = numbers.Split (","[0]);
		ability = int.Parse (info [0]);
		level = int.Parse(info [1]);
		DisplayInfo ();
	}
	public void DisplayInfo() {
		if (ability == 0)
			abilityStats [ability].text = "Level " + stats.iceShardLevel + " -> " + level + "\nCurrent Damage : " + abilities.iceShardUpgrades [0, stats.iceShardLevel] + "\nDamage at lv " + level + " : " + abilities.iceShardUpgrades [0, level] + 
				"\n\nCurrent Cost : " + abilities.iceShardUpgrades [1, stats.iceShardLevel] + "\nCost at lv " + level + " : "  + abilities.iceShardUpgrades [1, level] + 
				"\n\nCurrent Cooldown : " + abilities.iceShardUpgrades [2, stats.iceShardLevel] + "\nCooldown at lv " + level + " : " + abilities.iceShardUpgrades [2, level];
		if (ability == 1)
			abilityStats [ability].text = "Level " + stats.avalanceLevel + " -> " + level + "\nCurrent Damage : " + abilities.avalancheUpgrades [0, stats.avalanceLevel] + "\nDamage at lv " + level + " : " + abilities.avalancheUpgrades [0, level] + 
				"\n\nCurrent Cost : " + abilities.avalancheUpgrades [1, stats.avalanceLevel] + "\nCost at lv " + level + " : "  + abilities.avalancheUpgrades [1, level] + 
				"\n\nCurrent Cooldown : " + abilities.avalancheUpgrades [2, stats.avalanceLevel] + "\nCooldown at lv " + level + " : " + abilities.avalancheUpgrades [2, level];
		if (ability == 2)
			abilityStats [ability].text = "Level " + stats.teleportLevel + " -> " + level + "\nCurrent Damage : " + abilities.teleportUpgrades [0, stats.teleportLevel] + "\nRange at lv " + level + " : " + abilities.teleportUpgrades [0, level] + 
				"\n\nCurrent Cost : " + abilities.teleportUpgrades [1, stats.teleportLevel] + "\nCost at lv " + level + " : "  + abilities.teleportUpgrades [1, level] + 
				"\n\nCurrent Cooldown : " + abilities.teleportUpgrades [2, stats.teleportLevel] + "\nCooldown at lv " + level + " : " + abilities.teleportUpgrades [2, level];
		if (ability == 3)
			abilityStats [ability].text = "Level " + stats.iceWraithLevel + " -> " + level + "\nCurrent Damage Increse : " + abilities.iceWraithUpgrades [0, stats.iceWraithLevel] + "\nDamage Increase at lv " + level + " : " + abilities.iceWraithUpgrades [0, level] + 
				"\n\nCurrent Drain Cost : " + abilities.iceWraithUpgrades [1, stats.iceWraithLevel] + "\nDrain Cost at lv " + level + " : "  + abilities.iceWraithUpgrades [1, level] + 
				"\n\nCurrent Cooldown : " + abilities.iceWraithUpgrades [2, stats.iceWraithLevel] +  "\nCooldown at lv " + level + " : "  + abilities.iceWraithUpgrades [2, level];

	}

	public void ResetDisplayInfo(){
		abilityStats [ability].text = "";
		RefreshStats ();
	}

	public void RefreshStats(){
//		for(int i = 1; i < 4; i++)
//			currentStats[i].text = "Health : " + stats.currentHealth + "/" + stats.totalHealth + "\nChi : " + stats.currentChi + "/" + stats.totalChi + "\nMelee Damage : " + stats.meleeDamage + "\nXP : " + stats.currentXp + "/" + xpStats.ReturnMaxXP() + 
//				"\nUpgrade Points : " + stats.levelPoints;
//		abilityStats [ability].text = "";
	}

	public void MoveScreenLeft(){
		if (currentMenu == 1) {
			IceShard.gameObject.transform.position = new Vector3 (IceShardStart.x - 1000, IceShardStart.y, IceShardStart.z);
			Avalanche.gameObject.transform.position = new Vector3 (AvalancheStart.x, AvalancheStart.y, AvalancheStart.z);
		}
		if (currentMenu == 2) {
			Avalanche.gameObject.transform.position = new Vector3 (AvalancheStart.x - 1000, AvalancheStart.y, AvalancheStart.z);
			Teleport.gameObject.transform.position = new Vector3 (TeleportStart.x, TeleportStart.y, TeleportStart.z);
		}
		if (currentMenu == 3) {
			Teleport.gameObject.transform.position = new Vector3 (TeleportStart.x - 1000, TeleportStart.y, TeleportStart.z);
			IceWraith.gameObject.transform.position = new Vector3 (IceWraithStart.x, IceWraithStart.y, IceWraithStart.z);
		}
		currentMenu ++;
	}
	public void MoveScreenRight(){
		if (currentMenu == 2) {
			IceShard.gameObject.transform.position = new Vector3 (IceShardStart.x, IceShardStart.y, IceShardStart.z);
			Avalanche.gameObject.transform.position = new Vector3 (AvalancheStart.x + 1000, AvalancheStart.y, AvalancheStart.z);
		}
		if (currentMenu == 3) {
			Avalanche.gameObject.transform.position = new Vector3 (AvalancheStart.x, AvalancheStart.y, AvalancheStart.z);
			Teleport.gameObject.transform.position = new Vector3 (TeleportStart.x + 1000, TeleportStart.y, TeleportStart.z);
		}
		if (currentMenu == 4) {
			Teleport.gameObject.transform.position = new Vector3 (TeleportStart.x, TeleportStart.y, TeleportStart.z);
			IceWraith.gameObject.transform.position = new Vector3 (IceWraithStart.x + 1000, IceWraithStart.y, IceWraithStart.z);
		}
		currentMenu --;
	}

	public void FindObjects(){
		IceShard = GameObject.Find("IceShardScreen");
		Avalanche = GameObject.Find ("AvalancheScreen");
		Teleport = GameObject.Find ("TeleportScreen");
		IceWraith = GameObject.Find ("IceWraithScreen");
	}

	public void JumpToPage(int page){
		if (page == 1) {
			IceShard.gameObject.transform.position = new Vector3 (IceShardStart.x, IceShardStart.y, IceShardStart.z);
			Avalanche.gameObject.transform.position = new Vector3 (AvalancheStart.x + 1000, AvalancheStart.y, AvalancheStart.z);
			Teleport.gameObject.transform.position = new Vector3 (TeleportStart.x + 1000, TeleportStart.y, TeleportStart.z);
			IceWraith.gameObject.transform.position = new Vector3 (IceWraithStart.x + 1000, IceWraithStart.y, IceWraithStart.z);
			currentMenu = 1;
		}
		if (page == 2) {
			IceShard.gameObject.transform.position = new Vector3 (IceShardStart.x - 1000, IceShardStart.y, IceShardStart.z);
			Avalanche.gameObject.transform.position = new Vector3 (AvalancheStart.x, AvalancheStart.y, AvalancheStart.z);
			Teleport.gameObject.transform.position = new Vector3 (TeleportStart.x + 1000, TeleportStart.y, TeleportStart.z);
			IceWraith.gameObject.transform.position = new Vector3 (IceWraithStart.x + 1000, IceWraithStart.y, IceWraithStart.z);
			currentMenu = 2;
		}
		if (page == 3) {
			IceShard.gameObject.transform.position = new Vector3 (IceShardStart.x - 1000, IceShardStart.y, IceShardStart.z);
			Avalanche.gameObject.transform.position = new Vector3 (AvalancheStart.x - 1000, AvalancheStart.y, AvalancheStart.z);
			Teleport.gameObject.transform.position = new Vector3 (TeleportStart.x, TeleportStart.y, TeleportStart.z);
			IceWraith.gameObject.transform.position = new Vector3 (IceWraithStart.x + 1000, IceWraithStart.y, IceWraithStart.z);
			currentMenu = 3;
		}
		if (page == 4) {
			IceShard.gameObject.transform.position = new Vector3 (IceShardStart.x - 1000, IceShardStart.y, IceShardStart.z);
			Avalanche.gameObject.transform.position = new Vector3 (AvalancheStart.x - 1000, AvalancheStart.y, AvalancheStart.z);
			Teleport.gameObject.transform.position = new Vector3 (TeleportStart.x - 1000, TeleportStart.y, TeleportStart.z);
			IceWraith.gameObject.transform.position = new Vector3 (IceWraithStart.x, IceWraithStart.y, IceWraithStart.z);
			currentMenu = 4;
		}
	}

	public void ChoosePoint(int number){
		if (number == 1) {
			int health = stats.getTotalHealth() + 10;
			stats.setTotalHealth(health);
			stats.decreasePoints(1);
			menu.ChoosePoints.SetActive(false);
			menu.Upgrades();
		}
		if (number == 2) {
			int chi = stats.getTotalChi() + 10;
			stats.setTotalChi(chi);
			stats.decreasePoints(1);
			menu.ChoosePoints.SetActive(false);
			menu.Upgrades();
		}
		if (number == 3) {
			stats.increaseMeleeDamage(10);
			stats.decreasePoints(1);
			menu.ChoosePoints.SetActive(false);
			menu.Upgrades();
		}
	}

}
