using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	private Transform Spawn;
	void Start(){
		Spawn = GameObject.FindWithTag("Spawn").transform;
	}
	void OnTriggerEnter2D(Collider2D other){
		Spawn.transform.position = transform.position;
		GameObject.Destroy (gameObject);
	}
}
