﻿using UnityEngine;
using System.Collections;

public class Shards : MonoBehaviour {

	public float shardDamage = 0;
	public float speed = 30;
	private Transform player;
	Vector3 mousePosition;
	Vector3 movement;
	Abilities ability;

	// Use this for initialization
	void Start () {
		ability = (Abilities)FindObjectOfType (typeof(Abilities));
		player = GameObject.FindWithTag("Shimo").transform;
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		movement = mousePosition - player.position;
		movement.x = movement.x * 100;
		movement.y = movement.y * 100;
		if (movement != Vector3.zero)
			movement.Normalize ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ability.activatedIceWraith == true)
			shardDamage = ability.iceShardUpgrades [0, ability.iceShardLevel] + ability.iceWraithUpgrades[0,ability.iceWraithLevel];
		else
			shardDamage = ability.iceShardUpgrades [0, ability.iceShardLevel];


		GameObject.Destroy (gameObject, 2);
		transform.position += movement * speed * Time.deltaTime;
		float rot_z = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			other.transform.SendMessage ("Damage", shardDamage);
			GameObject.Destroy (gameObject);
		} else if (other.gameObject.tag == "Ground") {
			GameObject.Destroy (gameObject);
		} else if (other.gameObject.tag == "Ladder") {
			GameObject.Destroy (gameObject);
		}else if (other.gameObject.tag == "Break")
			GameObject.Destroy (gameObject);
	}
}
