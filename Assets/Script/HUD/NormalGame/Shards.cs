using UnityEngine;
using System.Collections;

public class Shards : MonoBehaviour {

	public float shardDamage = 20;
	public float speed = 30;
	private Transform player;
	Vector3 mousePosition;
	Vector3 movement;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").transform;
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		movement = mousePosition - player.position;
		movement.x = movement.x * 100;
		movement.y = movement.y * 100;
		if (movement != Vector3.zero)
			movement.Normalize ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Destroy (gameObject, 2);
		transform.position += movement * speed * Time.deltaTime;
//		if (player.position.x < mousePosition.x) {
//			transform.position += Vector3.right * speed * Time.deltaTime;
//		}
//		else {
//			transform.position += Vector3.left * speed * Time.deltaTime;
//			transform.rotation = Quaternion.Euler(0,180,0);
//		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") {
			other.transform.SendMessage("Damage",shardDamage);
			GameObject.Destroy (gameObject);
		}
	}
}
