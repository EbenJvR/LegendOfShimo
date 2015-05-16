using UnityEngine;
using System.Collections;

public class Abilities : MonoBehaviour {

	#region VariableDeclarations
	private Chi chiScript;
	private Stats stats;
	public GameObject iceShard;
	public GameObject teleportOutline;
	public GameObject cursor;
	public GameObject avalanche;
	private Transform player;
	public float teleportLength = 5f;
	private float chiAmount;
	private float counter;
	private int iceShardLevel;
	private int avalancheLevel;
	private int teleportLevel;
	private int iceWraithLevel;
	private bool activatedTeleport = false;
	private bool activatedIceWraith = false;
	private bool abilityLock = false;
	Vector3 mousePosition;
	GameObject teleportSelection;
	GameObject iceShardSelection;
	GameObject iceWraithSelection;
	GameObject avalancheSelection;
	#endregion

	#region Ability_Upgrades
	private float[,] iceShardUpgrades = new float[,]{
		{10,20,30,40,50},//damage
		{5,10,15,20,25}//cost
	};
	private float[,] avalancheUpgrades = new float[,]{
		{15,30,45,60,75},//damage
		{10,20,30,40,50}//cost
	};
	private float[,] teleportUpgrades = new float[,]{
		{5,15,25,35,45},//drain cost
		{2,3,4,5,6}//range
	};
	private float[,] iceWraithUpgrades = new float[,]{
		{10,15,20,25,30},//drain cost
		{10,15,20,25,30}//damage increase
	};
	#endregion



	// Use this for initialization
	void Start () {
		chiScript = GetComponent<Chi>();
		stats = GetComponent<Stats>();
		//Cursor.visible = false;
		Instantiate (cursor, mousePosition, Quaternion.identity);
		findObjects ();
		Reset ();
	}


	// Update is called once per frame
	void Update () {
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
		if(chiAmount >= iceShardUpgrades[1,iceShardLevel]){
			Instantiate(iceShard, player.position, Quaternion.identity);
			chiScript.reduceChi(iceShardUpgrades[1,iceShardLevel]);
		}
	}
	#endregion

	#region SecondMethods
	//Second ability
	private void activateSecond()
	{
		if(chiAmount >= avalancheUpgrades[1,avalancheLevel]){
			Instantiate(avalanche, player.position, Quaternion.identity);
			chiScript.reduceChi(avalancheUpgrades[1,avalancheLevel]);
		}
	}
	#endregion

	#region ThirdMethods
	//third ability
	private void activateThird(){
		abilityLock = true;
		Instantiate (teleportOutline, mousePosition, Quaternion.identity);
		Time.timeScale = 0.2F;
		activatedTeleport = true;
		GameObject cursorClone = (GameObject)GameObject.Find ("Cursor(Clone)");
		GameObject.Destroy (cursorClone);
	}
	private void deactivateThird(){
		abilityLock = false;
		player.position = Vector3.MoveTowards (player.position, mousePosition, 100);
		player.transform.position = new Vector3 (player.position.x, player.position.y, -1);
		Time.timeScale = 1F;
		activatedTeleport = false;
		GameObject outlineClone = (GameObject)GameObject.Find ("Outline(Clone)");
		GameObject.Destroy (outlineClone);
		Instantiate (cursor, mousePosition, Quaternion.identity);
	} 
	private void removeThird(){
		abilityLock = false;
		Time.timeScale = 1F;
		activatedTeleport = false;
		GameObject outlineCloneTime = (GameObject)GameObject.Find ("Outline(Clone)");
		GameObject.Destroy (outlineCloneTime);
		Instantiate (cursor, mousePosition, Quaternion.identity);
	}
	//Fourth ability drain
	private void teleportDrain(){
		chiScript.reduceChi (teleportUpgrades[0,teleportLevel]);
	}
	#endregion

	#region FourthMethods
	//Fourth ability
	private void activateFourth(){
		activatedIceWraith = true;
	}
	private void deactivateFourth(){
		activatedIceWraith = false;
		counter = 0;
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
	}

	//Find Objects
	private void findObjects(){
		player = GameObject.FindWithTag("Player").transform;
		teleportSelection = GameObject.Find("Teleport/Teleport_Select");
		iceShardSelection = GameObject.Find("Shards/Shards_Select");
		iceWraithSelection = GameObject.Find("Archon/Archon_Select");
		avalancheSelection = GameObject.Find("Blizzard/Blizzard_Select");
	}
	#endregion
}
