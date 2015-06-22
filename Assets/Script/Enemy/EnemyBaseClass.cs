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
	protected Animator enemy;
	BoxCollider2D enemyCollider;
	Rigidbody2D datRigidBody;
	float CollideX;
	float CollideY;
	float distance;
	protected float counter;
	bool stop = false;

	protected void PutInStart () {
		xpScript = (XP)FindObjectOfType (typeof(XP));
		enemyCollider = GetComponent<BoxCollider2D>();
		datRigidBody = GetComponent<Rigidbody2D> ();
		enemy = GetComponent<Animator> ();
		alert.SetActive (false);
		position = transform.position;
		CollideX = enemyCollider.size.x;
		CollideY = enemyCollider.size.y;
	}
	protected void PutInUpdate () 
	{
		player = GameObject.FindWithTag("Player").transform;
		distance = transform.position.x - player.position.x;
		if (distance < 0)
			distance *= -1;

		Debug.DrawRay (rayOrigin.transform.position, (player.transform.position-rayOrigin.transform.position), Color.red); 
		RaycastHit2D hit = Physics2D.Raycast (rayOrigin.transform.position,(player.position - rayOrigin.transform.position),alertRange);
		if (playerInRange == false && dead == false) {
			Patrol();
		}
		if (hit.collider.tag == "Player" && dead == false)
		{
			playerInRange = true;
			alert.SetActive(true);
			Move ();
		}
		if (distance <= 0.5f && dead == false) {
			counter += Time.deltaTime;
			if (counter > 1 && counter < 2) {
				Attack ();
			}
		} else {
			counter = 0;
		}
		if (health <= 0 && dead == false)
		{
			Die ();
		}
	}
	private void Move()
	{
		if (player.position.x < transform.position.x && distance > 0.5f) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
			transform.position += Vector3.left * movementSpeed * Time.deltaTime;
			enemy.SetBool ("AlertLeft", true);
			enemy.SetBool ("AlertRight", false);
		} else if (player.position.x > transform.position.x && distance > 0.5f) {
			transform.rotation = Quaternion.Euler (0, 180, 0);
			transform.position += Vector3.right * movementSpeed * Time.deltaTime;
			enemy.SetBool ("AlertLeft", true);
			enemy.SetBool ("AlertRight", false);
		} else {
			enemy.SetBool ("AlertLeft", false);
			enemy.SetBool ("AlertRight", false);
		}
	}
	private void Patrol()
	{
		if (transform.position.x > position.x - 3 && turn == "left") {
			transform.rotation = Quaternion.Euler (0, 0, 0);
			transform.position += Vector3.left * (movementSpeed - 2) * Time.deltaTime;
			enemy.SetBool ("CalmLeft", true);
			enemy.SetBool ("CalmRight", false);
		} else if (transform.position.x < position.x + 3 && turn == "right") {
			transform.rotation = Quaternion.Euler (0, 180, 0);
			transform.position += Vector3.right * (movementSpeed - 2) * Time.deltaTime;
			enemy.SetBool ("CalmRight", true);
			enemy.SetBool ("CalmLeft", false);
		} else {
			enemy.SetBool ("CalmRight", false);
			enemy.SetBool ("CalmLeft", false);
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
		enemy.Play ("Die");
		dead = true;
		xpScript.increaseXP (xpGain);
	}
	private void Damage(float value)
	{
		health -= value;
	}
	protected virtual void Attack (){
		Debug.Log ("Empty Attack Method");
	}
	private void Dead(){
		alert.SetActive (false);
		enemy.Play ("Dead");
		enemyCollider.size = new Vector2 (CollideX * 2, CollideY * 0.25f);
		datRigidBody.fixedAngle = false;
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
