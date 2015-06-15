using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;

public class Abilities : MonoBehaviour {

	#region VariableDeclarations
	private Chi chiScript;
	private Stats stats;
	private Menus menu;
	public GameObject cursor;
	public bool playing;
	private Transform player;
	private float chiAmount;
	private float counter;
	private bool abilityLock = false;
	Vector3 mousePosition;
	Vector3 direction;

	#endregion
	#region Ability_Upgrades
	private int[,] iceShardUpgrades = new int[,]{
		{0,30,40,50,60},//damage
		{0,0,30,45,50},//cost
		{0,7,6,5,4}//cooldown
	};
	private int[,] avalancheUpgrades = new int[,]{
		{0,30,40,50,60},//damage
		{0,45,55,65,75},//cost
		{0,10,9,8,7}//cooldown
	};
	private int[,] teleportUpgrades = new int[,]{
		{0,2,3,4,5},//range
		{0,25,30,35,40},//cost
		{0,8,7,6,5}//cooldown
	};
	private int[,] iceWraithUpgrades = new int[,]{
		{0,20,25,30,35},//damage increase
		{0,10,12,14,16},//drain cost
		{0,25,22,19,16}//cooldown
	};
	#endregion
	#region IceShard
	private Stopwatch iceShardTimer;
	public GameObject iceShard;
	GameObject iceShardSelection;
	public Slider iceShardCooldown;
	private int iceShardLevel;
	#endregion
	#region Avalanche
	private Stopwatch avalancheTimer;
	public GameObject avalanche;
	GameObject avalancheSelection;
	public Slider avalancheCooldown;
	private int avalancheLevel;
	#endregion
	#region Teleport
	private Stopwatch teleportTimer;
	private GameObject teleport;
	GameObject teleportSelection;
	public Slider teleportCooldown;
	private int teleportLevel;
	private bool activatedTeleport = false;
	public float teleportLength = 5f;
	#endregion
	#region IceWraith
	private Stopwatch iceWraithTimer;
	GameObject iceWraithSelection;
	public Slider iceWraithCooldown;
	private int iceWraithLevel;
	private bool activatedIceWraith = false;
	#endregion

	// Use this for initialization
	void Start () {
		menu = GetComponent<Menus> ();
		chiScript = GetComponent<Chi>();
		stats = GetComponent<Stats>();
		//Cursor.visible = false;
		Instantiate (cursor, mousePosition, Quaternion.identity);
		findObjects ();
		Reset ();
		timers ();
		iceShardCooldown.value = 0;
		avalancheCooldown.value = 0;
		teleportCooldown.value = 0;
		iceWraithCooldown.value = 0;
	}


	// Update is called once per frame
	void Update () {
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
		if ((float)iceShardTimer.ElapsedMilliseconds == 0) {
			iceShardCooldown.value = 0;
		} else {
			iceShardCooldown.value = iceShardUpgrades [2, iceShardLevel] - (float)iceShardTimer.ElapsedMilliseconds / 1000;
		}
		if ((float)avalancheTimer.ElapsedMilliseconds == 0) {
			avalancheCooldown.value = 0;
		} else {
			avalancheCooldown.value = avalancheUpgrades[2,avalancheLevel] - (float)avalancheTimer.ElapsedMilliseconds / 1000;
		}
		if ((float)teleportTimer.ElapsedMilliseconds == 0) {
			teleportCooldown.value = 0;
		} else {
			teleportCooldown.value = teleportUpgrades [2, teleportLevel] - (float)teleportTimer.ElapsedMilliseconds / 1000;
		}
		if((float)iceWraithTimer.ElapsedMilliseconds == 0){
			iceWraithCooldown.value = 0;
		} else {
			iceWraithCooldown.value = iceWraithUpgrades[2,iceWraithLevel] - (float)iceWraithTimer.ElapsedMilliseconds / 1000;
		}
		#endregion

		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
		//chiScript.reduceChi (teleportUpgrades[1, teleportLevel]);
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
		player = GameObject.FindWithTag("Player").transform;
		iceShardSelection = GameObject.Find("Shards/Shards_Select");
		avalancheSelection = GameObject.Find("Blizzard/Blizzard_Select");
		teleportSelection = GameObject.Find("Teleport/Teleport_Select");
		iceWraithSelection = GameObject.Find("Archon/Archon_Select");
		teleport = GameObject.Find ("StickmanTeleport");

	}

	private void timers(){
		iceShardTimer = new Stopwatch ();
		avalancheTimer = new Stopwatch ();
		teleportTimer = new Stopwatch ();
		iceWraithTimer = new Stopwatch ();
	}
	#endregion
}
