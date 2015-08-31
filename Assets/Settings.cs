using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {

	public GameObject settings;
	public Slider masterSlider;
	public Slider musicSlider;
	public GameObject qualityComboBox;
	public Text qualityButtonText;
	//public Button qualityButtonText;
//	public AudioSource audio;
	
	void Start () {
		FindObjects ();

		DisplayQuality ();

		settings.SetActive (false);
		qualityComboBox.SetActive (false);



		Time.timeScale = 1F;

	}
	
	void Update () 
	{

	}
	

	//public void SaveGame(){
		//int[] value = save.SaveStats ();
		//SaveLoad.Save (value);
	//}
	
	//public void LoadGame(){
		//int[] value = SaveLoad.Load ();
		//save.LoadStats (value);
	//}
	
	private void FindObjects(){

		settings = GameObject.Find ("Settings");
		qualityComboBox = GameObject.Find ("QualityComboBox");

		//audio = GameObject.Find ();

		//qualityButtonText = GameObject.Find ("QualityButtonText").GetComponent<Text> ();
		//qualityButtonText = gameObject.GetComponent<Text> ();
		//qualityButtonText = transform.FindChild("Text").GetComponent<Text>();
	}

	public void CloseSettings()
	{
		settings.SetActive (false);
	}

	public void OpenSettings()
	{
		settings.SetActive (true);
		DisplayQuality ();

	}


	public void FastSet()
	{
		QualitySettings.SetQualityLevel (0, true);
		DisplayQuality ();
	}

	public void LowSet()
	{
		QualitySettings.SetQualityLevel (1, true);
		DisplayQuality ();
	}

	public void MedSet()
	{
		QualitySettings.SetQualityLevel (2, true);
		DisplayQuality ();
	}

	public void HighSet()
	{
		QualitySettings.SetQualityLevel (3, true);
		DisplayQuality ();
	}

	public void UltraHighSet()
	{
		QualitySettings.SetQualityLevel (4, true);
		DisplayQuality ();
	}



	public void Apply()
	{

	}

	public void ShowQuality()
	{
		qualityComboBox.SetActive (true);
	}



	public void Default()
	{
		float masterSound = -20;
		float musicSound = -40;

		masterSlider.value = masterSound;
		musicSlider.value = musicSound;

		QualitySettings.SetQualityLevel (2, true);
		DisplayQuality ();

		//mainMixer.SetFloat ("MasterVol", masterSound);
		//mainMixer.SetFloat ("MusicVol", musicSound);

	}

	public void DisplayQuality()
	{
		int qualityLevel = QualitySettings.GetQualityLevel ();

		if (qualityLevel == 0) 
		{
			qualityButtonText.text = "Fast";

		} 

		else if (qualityLevel == 1)
		{
			qualityButtonText.text = "Low";

		} 

		else if (qualityLevel == 2) 
		{
			qualityButtonText.text = "Medium";

		} 

		else if (qualityLevel == 3) 
		{
			qualityButtonText.text = "High";

		} 

		else if (qualityLevel == 4) 
		{
			qualityButtonText.text = "Ultra High";
		}
	}

//	public void Mute(AudioSource audio)
//	{
//		if(audio.mute)
//		{
//			audio.mute = false;
//		}
//
//		else
//		{
//			audio.mute = true;
//		}
//	}

}
