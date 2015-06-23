using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	private Transform Spawn;
	void Start(){
		Spawn = GameObject.FindWithTag("Spawn").transform;
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Shimo") {
			Spawn.transform.position = transform.position;
			GameObject.Destroy (gameObject);
		}
	}
}
