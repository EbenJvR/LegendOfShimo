using UnityEngine;
using System.Collections;

public class BuildCheckpoint : MonoBehaviour {

	private Animator checkpoint;
	private Transform Spawn;

	// Use this for initialization
	void Start () {
		checkpoint = GetComponent<Animator> ();
		Spawn = GameObject.FindWithTag("Spawn").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Shimo") {
			checkpoint.SetBool ("Building", true);
			Spawn.transform.position = transform.position;
		}
	}
}
