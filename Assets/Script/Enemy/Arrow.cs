using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	
	private Transform player;
	private GameObject health;
	private Health healthScript;
	public float speed = 0.5f;
	private bool isLeft;
	private int randomShot;
	// Use this for initialization
	void Start () {
		randomShot = Random.Range (1, 10);
		transform.Translate (Vector3.up * 10 * Time.deltaTime);
		GameObject.Destroy (gameObject, 2);
		health = GameObject.Find ("Health_Bar");
		healthScript = (Health)health.GetComponent (typeof(Health));
		player = GameObject.FindWithTag("Player").transform;

		//Shoot lower
		if (randomShot >= 1 && randomShot <= 3) {
			transform.Translate (Vector3.down * 10 * Time.deltaTime);
		}

		if (player.position.x < transform.position.x) {
			isLeft = true;
			transform.Translate (Vector3.left * 150 * Time.deltaTime);
		}
		else {
			isLeft = false;
			transform.Translate (Vector3.right * 150 * Time.deltaTime);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isLeft == true) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			transform.rotation = Quaternion.Euler(0,0,0);
		}
		else {
			transform.position += Vector3.right * speed * Time.deltaTime;
			transform.rotation = Quaternion.Euler(0,180,0);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			GameObject.Destroy (gameObject);
			healthScript.Damage(10f);
		}
	}
}
