using UnityEngine;
using System.Collections;

public class BlizzardScript : MonoBehaviour {
	
	public float speed;
	public GameObject thisWave;
	public float blizzardDamage = 40;
	private Transform player;
	Vector3 mousePosition;

	void Start()
	{
		player = GameObject.FindWithTag("Player").transform;
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//		Vector2 v = new Vector2 (speed, 0);
//		GetComponent<Rigidbody2D> ().velocity = v;
		Destroy (gameObject, 2);
	}
	void Update()
	{
		if (player.position.x < mousePosition.x) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		else {
			transform.position += Vector3.left * speed * Time.deltaTime;
			transform.rotation = Quaternion.Euler(0,180,0);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			Debug.Log ("Yuuuh");
			other.transform.SendMessage("Damage", blizzardDamage);
		}
	}

}
