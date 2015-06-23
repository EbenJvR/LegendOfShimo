using UnityEngine;
using System.Collections;

public class Dummy : MonoBehaviour {

	Animator enemy;
	float health = 1;
	bool dead = false;
	BoxCollider2D enemyCollider;
	Rigidbody2D datRigidBody;
	float CollideX;
	float CollideY;

	// Use this for initialization
	void Start () {
		enemyCollider = GetComponent<BoxCollider2D>();
		datRigidBody = GetComponent<Rigidbody2D> ();
		enemy = GetComponent<Animator> ();
		CollideX = enemyCollider.size.x;
		CollideY = enemyCollider.size.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0 && dead == false)
		{
			Die ();
		}
	}
	private void Die()
	{
		enemy.Play ("Die");
		dead = true;
	}
	private void Damage(float value)
	{
		health -= value;
	}
	private void Dead(){
		enemy.Play ("Dead");
		enemyCollider.size = new Vector2 (CollideX * 3, CollideY * 0.07f);
		datRigidBody.fixedAngle = false;
	}
}
