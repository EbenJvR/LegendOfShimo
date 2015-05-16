using UnityEngine;
using System.Collections;

public class Archer : MonoBehaviour {

	private Transform player;
	public GameObject Head;
	public GameObject arrow;
	private float movementSpeed = 5f;//Archer movement speed
	private float heightDifference;
	private float idealHeight = 2f;//Are you in bow height?
	private float maxDistance = 15;//Where the archer will stop following you
	private float idealDistance = 9;//Where the archer wil start shooting you
	private float distance;
	private float health = 100;
	private int xpGain = 1;//Player xp gain from killing archer
	private bool dead = false;
	private float counter = 0;//Shoot arrows at certain counter times
	private XP xpScript;


	// Use this for initialization
	void Start () {
		xpScript = (XP)FindObjectOfType(typeof(XP));
	}
	
	// Update is called once per frame
	void Update()
	{
		player = GameObject.FindWithTag("Player").transform;
		RaycastHit2D hit = Physics2D.Raycast (Head.transform.position,(player.position - Head.transform.position));
		if (hit != null && hit.collider.tag == "Player") {
			Debug.Log ("Player Hit");
		}
		Debug.DrawRay(Head.transform.position, (player.position - Head.transform.position), Color.red);

		//Find distance of player and rotate
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

		if (health <= 0 && dead == false)
			Die ();

		//Find height and shoot if in range and height
		if (player.position.y < transform.position.y) {
			heightDifference = transform.position.y - player.position.y;
		} else if (player.position.y > transform.position.y) {
			heightDifference = player.position.y - transform.position.y;
		}
		if (heightDifference < idealHeight && distance <= idealDistance) {
			counter += Time.deltaTime;
			if (counter > 1 && counter < 2) {
				Shoot ();
			}
		} else {
			counter = 0;
		}
	}
	void Shoot(){
		Instantiate (arrow, transform.position, Quaternion.identity);
		counter = 0;
	}

	public void Damage(float dmg){
		health -= dmg;
	}

	private void Die(){
		Debug.Log ("Archer died");
		GameObject.Destroy (gameObject);
		dead = true;
		xpScript.increaseXP (xpGain);
	}
}
