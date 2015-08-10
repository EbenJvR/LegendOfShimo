using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menus : MonoBehaviour {
	
	//private Health healthScript;
	ButtonsActive buttons;
	Stats save;
	UpgradeScreen upgradeScreen;
	public GameObject gameOver;
	public GameObject pause;
	public GameObject upgradeMenu;
	public GameObject upgradeWarning;
	public GameObject ChoosePoints;
	public bool playing = true;
	public bool upgrades = false;
	private int healthAmount;
	private int warningStats;
	string[] ability = new string[]{"","Ice Shard","Avalanche","Teleport","Ice Wraith"};
	public Text warningText;
	public Text Points;

	void Start () {
		FindObjects ();
		buttons = GetComponent<ButtonsActive>();
		save = GetComponent<Stats>();
		upgradeScreen = GetComponent<UpgradeScreen> ();
		upgradeScreen.FindObjects ();
		gameOver.SetActive (false);
		pause.SetActive (false);
		upgradeWarning.SetActive (false);
		upgradeMenu.SetActive (false);
		ChoosePoints.SetActive (false);
		Time.timeScale = 1F;
	}

	void Update () {

		//Pause game
		if (gameOver.activeSelf == false && playing == true) {
			if (Input.GetKeyDown (KeyCode.Escape)) { 
				pause.SetActive (true);
				playing = false;
				Time.timeScale = 0F;
			}
		} else if (gameOver.activeSelf == false && playing == false && upgrades == false) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				pause.SetActive (false);
				playing = true;
				Time.timeScale = 1F;
			}
		}
		//Remove Upgrades menu
		if (upgrades == true) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				upgradeMenu.SetActive (false);
				upgrades = false;
			}
		}
	}

	public void StartLevel(){
		Application.LoadLevel ("Stage1Level1");
	}

	public void Quit(){
		Application.Quit ();
	}

	public void Retry(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void Continue(){
		pause.SetActive (false);
		playing = true;
		Time.timeScale = 1F;
	}

	public void Upgrades (){
		if (save.points > 0) {
			ChoosePoints.SetActive (true);
			if(save.points > 1)
			Points.text = "You have " + save.points + " points left";
			else
				Points.text = "You have " + save.points + " point left";
		}
		else{
			buttons.SetValues ();
			upgradeScreen.RefreshStats ();
			upgradeMenu.SetActive(true);
		}
		upgrades = true;
	}

	public void CancelUpgrades(){
		upgradeMenu.SetActive (false);
		upgrades = false;
	}

	public void UpgradeWarningShow(int abilityNumber,int currentLevel){
		warningStats = abilityNumber;
		warningText.text = "Are you sure you want to upgrade " + ability [warningStats] + " to Level " + (currentLevel + 1);
		upgradeWarning.SetActive (true);
	}

	public void UpgradeWarningAccept(){
		if (warningStats == 1) {
			save.iceShardLevel ++;
			save.levelPoints --;
			buttons.iceShardLevel++;
			buttons.points --;
		} else if (warningStats == 2) {
			save.avalanceLevel ++;
			save.levelPoints --;
			buttons.avalancheLevel++;
			buttons.points --;
		} else if (warningStats == 3) {
			save.teleportLevel ++;
			save.levelPoints --;
			buttons.teleportLevel++;
			buttons.points --;
		} else if (warningStats == 4) {
			save.iceWraithLevel ++;
			save.levelPoints --;
			buttons.iceWraithLevel++;
			buttons.points --;
		}
		upgradeWarning.SetActive (false);
		upgradeScreen.ResetDisplayInfo ();
	}

	public void UpgradeWarningClose(){
		upgradeWarning.SetActive (false);
	}

	public void MainMenu(){
		Application.LoadLevel ("MainMenu");
	}

	public void SaveGame(){
		int[] value = save.SaveStats ();
		SaveLoad.Save (value);
	}

	public void LoadGame(){
		int[] value = SaveLoad.Load ();
		save.LoadStats (value);
	}

	private void FindObjects(){
		pause = GameObject.Find("Pause");
		upgradeMenu = GameObject.Find ("Upgrades2.0");
		upgradeWarning = GameObject.Find ("Warning");
		ChoosePoints = GameObject.Find ("UpgradeSelection");
	}

	public bool GetPlaying(){
		return playing;
	}
}
