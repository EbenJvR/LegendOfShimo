using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	private Transform player;
	Vector3 mousePosition;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindWithTag("Shimo").transform;
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (player.position.x < mousePosition.x) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
		else {
			transform.rotation = Quaternion.Euler(0,180,0);
		}
	}
}
