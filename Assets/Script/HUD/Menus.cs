using UnityEngine;
using System.Collections;

public class Menus : MonoBehaviour {
	
	//private Health healthScript;
	ButtonsActive buttons;
	Stats save;
	public GameObject health;
	public GameObject gameOver;
	public GameObject pause;
	public GameObject upgradeMenu;
	public bool playing = true;
	public bool upgrades = false;
	private int healthAmount;

	void Start () {
		FindObjects ();
		buttons = GetComponent<ButtonsActive>();
		save = GetComponent<Stats>();
		gameOver.SetActive (false);
		pause.SetActive (false);
		upgradeMenu.SetActive (false);
		Time.timeScale = 1F;
	}

	void Update () {
		//Died
//		if (health != null) {
//			healthAmount = healthScript.checkHealth ();
//			if (healthAmount <= 0) {
//				gameOver.SetActive(true);
//			}
//		}

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
		Debug.Log ("Clicked");
		//Application.LoadLevel ("Test");
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
		buttons.SetValues ();
		upgradeMenu.SetActive(true);
		upgrades = true;
	}

	public void CancelUpgrades(){
		upgradeMenu.SetActive (false);
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
		upgradeMenu = GameObject.Find ("Upgrades");
	}
}
