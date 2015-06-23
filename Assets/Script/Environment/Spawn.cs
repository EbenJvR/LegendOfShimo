using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject Player;
	private Transform playerPosition;
	private float currentHealth;
	Health health;

	// Use this for initialization
	void Start () {
		health = (Health)FindObjectOfType(typeof(Health));
	}
	
	// Update is called once per frame
	void Update () {
		playerPosition = GameObject.FindWithTag("Shimo").transform;
		currentHealth = health.checkHealth ();
		if (currentHealth <= 0) {
			playerPosition.transform.position = transform.position;
			health.increaseHealth();
		}
	}
}
