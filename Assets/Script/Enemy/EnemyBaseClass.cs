using UnityEngine;
using System.Collections;

public class EnemyBaseClass : MonoBehaviour {

	private Transform player = null;
	private Vector3 position;
	protected float movementSpeed;
	protected float movementRange;
	protected float attackSpeed;
	protected float attackRange;
	protected float health;
	protected int xpGain;
	private bool dead;
	private string turn = "left";
	protected float alertRange;
	private XP xpScript;
	public GameObject alert;
	private bool playerInRange;
	public GameObject rayOrigin;
	public Ray2D rangeRay;
	public RaycastHit2D rayHit;
	bool stop = false;

	protected void PutInStart () {
		xpScript = (XP)FindObjectOfType (typeof(XP));
		alert.SetActive (false);
		position = transform.position;
	}
	protected void PutInUpdate () 
	{
		player = GameObject.FindWithTag("Player").transform;

		Debug.DrawRay (rayOrigin.transform.position, (player.transform.position-rayOrigin.transform.position), Color.red); 
		RaycastHit2D hit = Physics2D.Raycast (rayOrigin.transform.position,(player.position - rayOrigin.transform.position),alertRange);
		if (playerInRange == false) {
			Patrol();
		}
		if (hit.collider.tag == "Player")
		{
			playerInRange = true;
			alert.SetActive(true);
			Move ();
		}
		if (health <= 0 && dead == false)
		{
			Die ();
		}
	}
	private void Move()
	{
		if (player.position.x < transform.position.x) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
			transform.position += Vector3.left * movementSpeed * Time.deltaTime;
		} else if (player.position.x > transform.position.x) {
			transform.rotation = Quaternion.Euler (0, 180, 0);
			transform.position += Vector3.right * movementSpeed * Time.deltaTime;
		}
	}
	private void Patrol()
	{
		if (transform.position.x > position.x - 3 && turn == "left") {
			transform.rotation = Quaternion.Euler (0, 0, 0);
			transform.position += Vector3.left * (movementSpeed - 2) * Time.deltaTime;
		}else if (transform.position.x < position.x + 3 && turn == "right") {
			transform.rotation = Quaternion.Euler (0, 180, 0);
			transform.position += Vector3.right * (movementSpeed - 2) * Time.deltaTime;
		}
		if (transform.position.x <= position.x - 3) {
			stop = true;
			StartCoroutine ("WaitForTurn");
		}
		if (transform.position.x >= position.x + 3) {
			stop = true;
			StartCoroutine ("WaitForTurn");
		}
	}
	private void Die()
	{
		GameObject.Destroy (gameObject);
		dead = true;
		xpScript.increaseXP (xpGain);
	}
	private void Damage(float value)
	{
		health -= value;
	}
	IEnumerator WaitForTurn(){
		if (stop == true && turn == "right") {
			yield return(new WaitForSeconds (2));
			turn = "left";
			stop = false;
		}
		if (stop == true && turn == "left") {
			yield return(new WaitForSeconds (2));
			turn = "right";
			stop = false;
		}
	}
}
