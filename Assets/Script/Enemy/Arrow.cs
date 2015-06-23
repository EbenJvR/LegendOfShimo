using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	
	private Transform player;
	private GameObject health;
	Vector3 movement;
	private Health healthScript;
	public float speed = 0.5f;
	private bool isLeft;
	private int randomShot;
	// Use this for initialization
	void Start () {
		randomShot = Random.Range (1, 10);
		transform.Translate (Vector3.up * 10 * Time.deltaTime);
		GameObject.Destroy (gameObject, 2);
		healthScript = (Health)FindObjectOfType (typeof(Health));
		player = GameObject.FindWithTag("Player").transform;
		movement = player.position - transform.position;
		movement.x = movement.x * 100;
		movement.y = movement.y * 100;
		if (movement != Vector3.zero)
			movement.Normalize ();

		//Shoot lower
		if (randomShot >= 1 && randomShot <= 3) {
			transform.Translate (Vector3.down * 10 * Time.deltaTime);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += movement * speed * Time.deltaTime;
		float rot_z = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z-180);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Shimo")
		{
			GameObject.Destroy (gameObject);
			healthScript.Damage(10);
		}
	}
}
