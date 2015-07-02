using UnityEngine;
using System.Collections;

public class SoundTest : MonoBehaviour {

	AudioSource test;
	bool start;

	// Use this for initialization
	void Start () {
		test = GetComponent<AudioSource>();
		test.clip = Resources.Load ("Audio/Test") as AudioClip; //Load sound from folder and not object(has to be "Resources" folder)
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Shimo" && start == false) {
			test.Play ();
			start = true;
		} else if (other.tag == "Shimo" && start == true) {
			test.UnPause();
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		test.Pause ();
	}
}
