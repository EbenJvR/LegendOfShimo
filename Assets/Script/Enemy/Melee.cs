using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {

	private Transform player;
	public GameObject Head;
	private float movementSpeed = 3f;
	private float distance;
	private float idealDistance = 2f;//When the melee will start attacking
	private float maxDistance = 15;//Where the melee will stop following you
	private float heightDifference;
	private float idealHeight = 3f;//Are you in melee range?
	private float health = 100;
	private int xpGain = 1;//XP amount the player will gain from killing the melee
	private float meleeDamage = 10;
	private bool dead = false;
	private float counter = 0;
	private Health healthScript;
	private XP xpScript;

	// Use this for initialization
	void Start () {
		healthScript = (Health)FindObjectOfType (typeof(Health));
		xpScript = (XP)FindObjectOfType (typeof(XP));
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindWithTag("Player").transform;
		RaycastHit2D hit = Physics2D.Raycast (Head.transform.position,(player.position - Head.transform.position));
		if (hit != null && hit.collider.tag == "Player") {
			Debug.Log ("Player Hit");
		}
		Debug.DrawRay(Head.transform.position, (player.position - Head.transform.position), Color.green);
		//Move melee to player
		if (player.position.x < transform.position.x) {
			distance = transform.position.x - player.position.x;
			transform.rotation = Quaternion.Euler (0, 0, 0);
			if (distance > idealDistance && distance < maxDistance) {
				transform.position += Vector3.left * movementSpeed * Time.deltaTime;
			}
		} else if (player.position.x > transform.position.x) {
			distance = player.position.x - transform.position.x;
			transform.rotation = Quaternion.Euler (0, 180, 0);
			if (distance > idealDistance && distance < maxDistance) {
				transform.position += Vector3.right * movementSpeed * Time.deltaTime;
			}
		}
		//Find height and attack if in range
		if (player.position.y < transform.position.y) {
			heightDifference = transform.position.y - player.position.y;
		} else if (player.position.y > transform.position.y) {
			heightDifference = player.position.y - transform.position.y;
		}
		if(distance <= idealDistance && heightDifference < idealHeight){
			counter += Time.deltaTime;
			if (counter > 0.7 && counter < 1.5) {
				Hit ();
			}
		} else
			counter = 0;
		if (health <= 0 && dead == false)
			Die ();
	}

	public void Hit(){
		healthScript.Damage(meleeDamage);
		counter = 0;
	}

	public void Damage(float dmg){
		health -= dmg;
	}
	
	private void Die(){
		Debug.Log ("Melee died");
		GameObject.Destroy (gameObject);
		dead = true;
		xpScript.increaseXP (xpGain);
	}
}
