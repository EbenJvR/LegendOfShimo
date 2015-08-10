using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;

public class Abilities : MonoBehaviour {

	#region VariableDeclarations
	MovementMk2 teleportParticle;
	private Chi chiScript; //Abilities Use Chi
	private Stats stats; //Ability Levels
	private Menus menu; //Check If Game Is Paused
	public GameObject cursor; //Remove and Insert Cursor Because Of Teleport
	public bool playing; //Is The Game Paused
	private Transform player; //Teleport Player
	private float chiAmount; //Don't use ability if Chi is too low
	private float counter; //Used For Time Check
	private bool abilityLock = false; //Can't Use Other Abilities While One Is Active
	Vector3 mousePosition; //Put Cursor Back On Mouse Position After Teleport Is Deactivated
	Vector3 direction; //Teleport Direction

	#endregion
	#region Ability_Upgrades
	public int[,] iceShardUpgrades = new int[,]{
		{0,30,40,50,60},//damage
		{0,15,30,45,50},//cost
		{0,7,6,5,4}//cooldown
	};
	public int[,] avalancheUpgrades = new int[,]{
		{0,30,40,50,60},//damage
		{0,45,55,65,75},//cost
		{0,10,9,8,7}//cooldown
	};
	public int[,] teleportUpgrades = new int[,]{
		{0,4,5,6,7},//range
		{0,10,15,20,25},//cost
		{0,8,7,6,5}//cooldown
	};
	public int[,] iceWraithUpgrades = new int[,]{
		{0,20,25,30,35},//damage increase
		{0,10,12,14,16},//drain cost
		{0,25,22,19,16}//cooldown
	};
	#endregion
	#region IceShard
	private Stopwatch iceShardTimer; //Ice Shard Cooldown
	public GameObject iceShard; //Ice Shard Object
	GameObject iceShardSelection; //Ice Shard HUD Selection
	public Slider iceShardCooldown; //Ice Shard Cooldown Visual
	public int iceShardLevel; //Ice Shard Level
	#endregion
	#region Avalanche
	private Stopwatch avalancheTimer; //Avalanche Cooldown
	public GameObject avalanche; //Avalanche Object
	GameObject avalancheSelection; //Avalanche HUD Selection
	public Slider avalancheCooldown; //Avalanche Cooldown Visual
	private int avalancheLevel; //Avalanche Level
	#endregion
	#region Teleport
	private Stopwatch teleportTimer; //Teleport Cooldown
	private GameObject teleport; //Teleport Object
	GameObject teleportSelection; //Teleport HUD Selection
	public Slider teleportCooldown; //Teleport Cooldown Visual
	private int teleportLevel; //Teleport Level
	private bool activatedTeleport = false; //Move Player The Second Time Teleport Is Activated 
	#endregion
	#region IceWraith
	private Stopwatch iceWraithTimer; //Ice Wraith Cooldown
	GameObject iceWraithSelection; //Ice Wraith HUD Selection
	public Slider iceWraithCooldown; //Ice Wraith Cooldown Visual
	public int iceWraithLevel; //Ice Wraith Level
	public bool activatedIceWraith = false; //Drain And Deactivate Ability When This Is True
	#endregion

	void Start () {
		menu = GetComponent<Menus> ();
		chiScript = GetComponent<Chi>();
		stats = GetComponent<Stats>();
		teleportParticle = (MovementMk2)FindObjectOfType (typeof(MovementMk2));
		//Cursor.visible = false;
		Instantiate (cursor, mousePosition, Quaternion.identity); //Add Game Cursor
		findObjects (); //Find Objects In Hierarchy
		Reset (); //Reset Ability Selection
		timers (); //Instantiate Cooldown timers 
		iceShardCooldown.value = 0; //Reset Ice Shard Cooldown Visual
		avalancheCooldown.value = 0; //Reset Avalanche Cooldown Visual
		teleportCooldown.value = 0; //Reset Teleport Cooldown Visual
		iceWraithCooldown.value = 0; //Reset Ice Wraith Cooldown Visual
	}


	void Update () {
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		direction = player.position - mousePosition;
		teleport.transform.position = (player.position - (direction.normalized * teleportUpgrades [0, teleportLevel]));
		playing = menu.GetPlaying ();
		#region PauseTimers
		//IceShard
		if (playing == false) {
			iceShardTimer.Stop ();
		} else if (playing == true && (float)iceShardTimer.ElapsedMilliseconds != 0) {
			iceShardTimer.Start ();
		}
		//Avalanche
		if (playing == false) {
			avalancheTimer.Stop ();
		} else if (playing == true && (float)avalancheTimer.ElapsedMilliseconds != 0) {
			avalancheTimer.Start ();
		}
		//Teleport
		if (playing == false) {
			teleportTimer.Stop ();
		} else if (playing == true && (float)teleportTimer.ElapsedMilliseconds != 0) {
			teleportTimer.Start ();
		}
		//IceWraith
		if (playing == false) {
			iceWraithTimer.Stop ();
		} else if (playing == true && (float)iceWraithTimer.ElapsedMilliseconds != 0) {
			iceWraithTimer.Start ();
		}
		#endregion
		#region Timers
		//IceShard timer
		if ((int)iceShardTimer.ElapsedMilliseconds / 1000 >= iceShardUpgrades[2,iceShardLevel]) {
			iceShardTimer.Stop();
			iceShardTimer.Reset();
		}
		//Avalanche timer
		if ((int)avalancheTimer.ElapsedMilliseconds / 1000 >= avalancheUpgrades[2,avalancheLevel]) {
			avalancheTimer.Stop();
			avalancheTimer.Reset();
		}
		//Teleport
		if ((int)teleportTimer.ElapsedMilliseconds / 1000 >= teleportUpgrades[2,teleportLevel]) {
			teleportTimer.Stop();
			teleportTimer.Reset();
		}
		//IceWraith
		if ((int)iceWraithTimer.ElapsedMilliseconds / 1000 >= iceWraithUpgrades[2,iceWraithLevel]) {
			iceWraithTimer.Stop();
			iceWraithTimer.Reset();
		}
		#endregion
		#region Cooldown

		//Ice Shard Cooldown Visual
		if ((float)iceShardTimer.ElapsedMilliseconds == 0) {
			iceShardCooldown.value = 0;
		} else {
			iceShardCooldown.value = iceShardUpgrades [2, iceShardLevel] - (float)iceShardTimer.ElapsedMilliseconds / 1000;
		}
		//Avalanche Cooldown Visual
		if ((float)avalancheTimer.ElapsedMilliseconds == 0) {
			avalancheCooldown.value = 0;
		} else {
			avalancheCooldown.value = avalancheUpgrades[2,avalancheLevel] - (float)avalancheTimer.ElapsedMilliseconds / 1000;
		}
		//Teleport Cooldown Visual
		if ((float)teleportTimer.ElapsedMilliseconds == 0) {
			teleportCooldown.value = 0;
		} else {
			teleportCooldown.value = teleportUpgrades [2, teleportLevel] - (float)teleportTimer.ElapsedMilliseconds / 1000;
		}
		//Ice Wraith Cooldown Visual
		if((float)iceWraithTimer.ElapsedMilliseconds == 0){
			iceWraithCooldown.value = 0;
		} else {
			iceWraithCooldown.value = iceWraithUpgrades[2,iceWraithLevel] - (float)iceWraithTimer.ElapsedMilliseconds / 1000;
		}
		#endregion

		chiAmount = chiScript.checkChi ();
		iceShardLevel = stats.getIceShardLevel ();
		avalancheLevel = stats.getAvalanceLevel ();
		teleportLevel = stats.getTeleportLevel ();
		iceWraithLevel = stats.getIceWraithLevel ();

		#region FirstAbility_Select_Activate
		//Select first ability
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			if(iceShardSelection.activeSelf == false && abilityLock == false){
				Reset ();
				iceShardSelection.SetActive(true);
			}
		}
		//Activate First Ability
		if (iceShardSelection.activeSelf == true && Input.GetMouseButtonDown (1)) {
			activateFirst();
		}
		#endregion
		#region SecondAbility_Select_Activate_Drain
		//Select second ability
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			if(avalancheSelection.activeSelf == false && abilityLock == false){
				Reset ();
				avalancheSelection.SetActive(true);
			}
		}
		//Activate second ability
		if (avalancheSelection.activeSelf == true && Input.GetMouseButtonDown (1)) {
			activateSecond();
		}
		#endregion
		#region ThirdAbility_Select_Activate
		//Select third ability
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			if(teleportSelection.activeSelf == false && abilityLock == false){
				Reset ();
				teleportSelection.SetActive(true);
			}
		}
		//Activate third ability
		if (activatedTeleport == false && teleportSelection.activeSelf == true) {
			if (Input.GetMouseButtonDown (1)) {
				activateThird();
			}
		} else if (activatedTeleport == true && teleportSelection.activeSelf == true) {
			if (Input.GetMouseButtonDown (1)) {
				deactivateThird();
			}
		}
		//Drain third ability
		if (activatedTeleport == true) {
			counter += Time.fixedDeltaTime;
			if (counter > 1 && counter < 2 && chiAmount > 0) {
				teleportDrain ();
				counter = 0;
			} else if (counter > 2)
				counter = 0;
			if(chiAmount <= 20){
				removeThird();
			}
		}
		#endregion
		#region FourthAbility_Select_Activate_Drain
		//Select fourth ability
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			if(iceWraithSelection.activeSelf == false && abilityLock == false){
				Reset ();
				iceWraithSelection.SetActive(true);
			}
		}
		//Activate fourth ability
		if (activatedIceWraith == false && iceWraithSelection.activeSelf == true) {
			if (Input.GetMouseButtonDown (1)) {
				activateFourth();
			}
		} else if (activatedIceWraith == true && iceWraithSelection.activeSelf == true) {
			if (Input.GetMouseButtonDown (1)) {
				deactivateFourth();
			}
		}
		//Drain fourth ability
		if (activatedIceWraith == true) {
			counter += Time.fixedDeltaTime;
			if (counter > 1 && counter < 2 && chiAmount > 0) {
				archonDrain ();
				counter = 0;
			} else if (counter > 2)
				counter = 0;
			if(chiAmount <= 0){
				deactivateFourth();
			}
		}
		#endregion
	}
	#region FirstMethods
	//First ability
	private void activateFirst(){
		if(chiAmount >= iceShardUpgrades[1,iceShardLevel] && iceShardTimer.ElapsedMilliseconds == 0 && playing == true){
			Instantiate(iceShard, player.position, Quaternion.identity);
			chiScript.reduceChi(iceShardUpgrades[1,iceShardLevel]);
			iceShardTimer.Start();
			iceShardCooldown.maxValue = iceShardUpgrades [2, iceShardLevel];
		}
	}
	#endregion

	#region SecondMethods
	//Second ability
	private void activateSecond()
	{
		if(chiAmount >= avalancheUpgrades[1,avalancheLevel] && avalancheTimer.ElapsedMilliseconds == 0 && playing == true){
			Instantiate(avalanche, player.position, Quaternion.identity);
			chiScript.reduceChi(avalancheUpgrades[1,avalancheLevel]);
			avalancheTimer.Start ();
			avalancheCooldown.maxValue = avalancheUpgrades [2, avalancheLevel];
		}
	}
	#endregion

	#region ThirdMethods
	//third ability
	private void activateThird(){
		if (teleportTimer.ElapsedMilliseconds == 0 && playing == true) {
			abilityLock = true;
			teleport.SetActive(true);
			Time.timeScale = 0.2F;
			activatedTeleport = true;
			GameObject cursorClone = (GameObject)GameObject.Find ("Cursor(Clone)");
			GameObject.Destroy (cursorClone);
		}
	}
	private void deactivateThird(){
		teleportTimer.Start ();
		teleportCooldown.maxValue = teleportUpgrades [2, teleportLevel];
		abilityLock = false;
		player.position = Vector3.MoveTowards (player.position, teleport.transform.position, 100);
		player.transform.position = new Vector3 (player.position.x, player.position.y, -1);
		teleportParticle.PlayTeleport ();
		Time.timeScale = 1F;
		teleport.SetActive(false);
		activatedTeleport = false;
		Instantiate (cursor, mousePosition, Quaternion.identity);
	} 
	private void removeThird(){
		abilityLock = false;
		Time.timeScale = 1F;
		teleport.SetActive(false);
		activatedTeleport = false;
		Instantiate (cursor, mousePosition, Quaternion.identity);
	}
	//third ability drain
	private void teleportDrain(){
		chiScript.reduceChi (teleportUpgrades[1, teleportLevel]);
	}
	#endregion

	#region FourthMethods
	//Fourth ability
	private void activateFourth(){
		if (chiAmount >= iceWraithUpgrades [1, iceWraithLevel] && iceWraithTimer.ElapsedMilliseconds == 0 && playing == true) {
			activatedIceWraith = true;
			iceWraithCooldown.maxValue = iceWraithUpgrades [2, iceWraithLevel];
		}
	}
	private void deactivateFourth(){
		activatedIceWraith = false;
		counter = 0;
		iceWraithTimer.Start();
	}
	//Fourth ability drain
	private void archonDrain(){
		chiScript.reduceChi (iceWraithUpgrades[0,iceWraithLevel]);
	}
	#endregion

	#region MainMethods
	//Reset selection
	private void Reset(){
		teleportSelection.SetActive (false);
		iceShardSelection.SetActive (false);
		iceWraithSelection.SetActive (false);
		avalancheSelection.SetActive (false);
		teleport.SetActive (false);
	}

	//Find Objects
	private void findObjects(){
		player = GameObject.FindWithTag("Shimo").transform;
		iceShardSelection = GameObject.Find("Shards/Shards_Select");
		avalancheSelection = GameObject.Find("Blizzard/Blizzard_Select");
		teleportSelection = GameObject.Find("Teleport/Teleport_Select");
		iceWraithSelection = GameObject.Find("Archon/Archon_Select");
		teleport = GameObject.Find ("ShimoTeleport");

	}

	private void timers(){
		iceShardTimer = new Stopwatch ();
		avalancheTimer = new Stopwatch ();
		teleportTimer = new Stopwatch ();
		iceWraithTimer = new Stopwatch ();
	}
	#endregion
}
