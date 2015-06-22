using UnityEngine;
using System.Collections;

public class BlizzardScript : MonoBehaviour {

	private float distance = 1;
	private bool activated;
	public float blizzardDamage = 40;
	private Transform player;
	Vector3 mousePosition;
	Abilities ability;
	BoxCollider2D blizzardCollider;
	Rigidbody2D datRigidBody;
	float ColliderY;
	float ColliderX;

	void Start()
	{
		activated = false;
		ability = (Abilities)FindObjectOfType (typeof(Abilities));
		blizzardCollider = GetComponent<BoxCollider2D>();
		datRigidBody = GetComponent<Rigidbody2D> ();
		ColliderY = blizzardCollider.size.y;
		ColliderX = blizzardCollider.size.x;
		player = GameObject.FindWithTag("Player").transform;
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Destroy (gameObject, 2);
		if (player.position.x < mousePosition.x) {
			transform.position += Vector3.right * distance;
		} else {
			transform.position += Vector3.left * distance;
		}
	}
	void Update()
	{
		if (ability.activatedIceWraith == true)
		blizzardDamage = ability.iceShardUpgrades [0, ability.iceShardLevel] + ability.iceWraithUpgrades[0,ability.iceWraithLevel];
		else
			blizzardDamage = ability.iceShardUpgrades [0, ability.iceShardLevel];
		if (activated == true)
			datRigidBody.gravityScale = 0;

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ground") {
			Debug.Log ("Collision");
			activated = true;
			blizzardCollider.isTrigger = true;
			blizzardCollider.size = new Vector2 (ColliderX + 50f, ColliderY + 3f);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") {
			Debug.Log ("Trigger");
			other.transform.SendMessage ("Damage", blizzardDamage);
		}
	}

}
