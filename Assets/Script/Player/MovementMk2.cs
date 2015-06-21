﻿using UnityEngine;
using System.Collections;

public class MovementMk2 : MonoBehaviour {

	public GameObject feet; //isGrounded Array Start
	private Animator running; //Running and Attacking Animation
	BoxCollider2D playerCollider; //Used for Duck
	Rigidbody2D datRigidBody; //Used For Double Jump
	int currentJump = 0; //Check If Current Jump Is A Double Jump
	float fallVelocity = 0; //Check Fall damage
	public float speed = 10f; //Movement Speed
	public float jumpForce = 10000f; //First Jump Height
	public float doubleJumpForce = 10000f; //Double Jump Height
	public bool isGrounded = false; //Check If The Player Is Grounded
	bool checkFall = false; //Make Sure Fall Damage Is Apllied At Right Time
	bool playing; //Pause Movement When Game Is Paused
	SwordDamage sDmg; //Sword Only Damages When Attack is Pressed
	Health health; //Add Fall Damage
	private Menus menu; //Check If Game Is Paused
	
	void Start () {
		menu = (Menus)FindObjectOfType (typeof(Menus));
		health = (Health)FindObjectOfType (typeof(Health));
		sDmg = (SwordDamage)FindObjectOfType(typeof(SwordDamage));
		running = GetComponent<Animator> ();
		playerCollider = GetComponent<BoxCollider2D>();
		datRigidBody = GetComponent<Rigidbody2D> ();
		datRigidBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		datRigidBody.interpolation = RigidbodyInterpolation2D.Extrapolate;
	}

	
	void Update () {
		playing = menu.GetPlaying ();

		//Draw Check Ground Ray
		Vector3 down = transform.TransformDirection(Vector3.down) * 0.2f;
		Debug.DrawRay(feet.transform.position, down, Color.blue);

		//Add Fall Damage
		if (IsGrounded()) 
		{
			isGrounded = true;
			currentJump = 0;
			if(checkFall)
			{
				if(gameObject.tag == "Player")
				FallDamage(fallVelocity);
			}
		} else 
		{
			isGrounded = false;
			fallVelocity = datRigidBody.velocity.y;
			checkFall = true;
		} 

		//Run Left And Play Animation
		if (Input.GetKey (KeyCode.A) && playing == true) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			running.SetBool ("RunLeft", true);
			transform.rotation = Quaternion.Euler(0f, 180f,0f);
		} else
			running.SetBool ("RunLeft", false);
		
		//Run Right And Play Animation
		if (Input.GetKey(KeyCode.D) && playing == true)
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
			running.SetBool ("RunRight", true);
			transform.rotation = Quaternion.Euler(0f, 0f,0f);
		} else
			running.SetBool ("RunRight", false);

		//Jump And Double Jump
		if (Input.GetKeyDown (KeyCode.Space) && playing == true)
		{
			if(isGrounded && currentJump == 0)
			{
				Jump ();
				currentJump++;
			}
			
			if(!isGrounded && currentJump == 1)
			{
				AirJump ();
				currentJump -= 1;
			}
		}

		//Duck
		if (Input.GetKey (KeyCode.S) && playing == true) {
			playerCollider.size = new Vector2 (playerCollider.size.x, 2.35f);
		} else {
			playerCollider.size = new Vector2 (playerCollider.size.x, 4.7f);
		}

		//Attack And Play Animation
		if (Input.GetMouseButtonDown (0) && playing == true) {
			running.Play ("Attack2.0");
			sDmg.CanDamage(true);

		}
	}
	//Check If Player Is Grounded
	bool IsGrounded()
	{
		return Physics2D.Raycast (feet.transform.position, -Vector2.up, 0.2f, LayerMask.GetMask("Ground"));
	}
	//Jump once
	void Jump()
	{
		datRigidBody.AddForce (Vector2.up * jumpForce);
	}
	//Double Jump
	void AirJump()
	{
		Vector2 v2 = datRigidBody.velocity;
		v2.y = 0;
		datRigidBody.velocity = v2;
		datRigidBody.AddForce (Vector2.up * doubleJumpForce);
	}
	//Fall Damage
	void FallDamage(float fall)
	{
		fall = Mathf.Round(fall);
		if(fall < -26)
		{
			health.Damage((int)(fall+26)*-1);
		}
		checkFall = false;
	}

}




