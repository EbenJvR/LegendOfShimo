using UnityEngine;
using System.Collections;

public class MovementMk2 : MonoBehaviour {
	
	// Use this for initialization
	private Animator running;
	BoxCollider2D playerCollider;
	public float speed = 10f;
	Rigidbody2D datRigidBody;
	public bool isGrounded = false;
	int currentJump = 0;
	public float jumpForce = 10000f;
	public float doubleJumpForce = 10000f;
	public GameObject feet;
	public bool attack = false;
	float fallVelocity = 0;
	bool checkFall = false;
	SwordDamage sDmg;
	Health health;
	private Menus menu;
	bool playing;
	
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
	
	//Update is called once per frame
	
	void Update () {
		playing = menu.GetPlaying ();
		//		RaycastHit2D hit = Physics2D.Raycast(feet.transform.position, Vector3.down,1f);
		//		if (hit != null && hit.collider.tag == "Ground") {
		//			Debug.Log ("Grounded");
		//			isGrounded = true;
		//			currentJump = 0;
		//		} else if (hit != null && hit.collider.tag != "Ground") {
		//			Debug.Log ("NotGrounded");
		//			isGrounded = false;
		//		}
		
		Vector3 down = transform.TransformDirection(Vector3.down) * 0.2f;
		Debug.DrawRay(feet.transform.position, down, Color.blue);
		
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
		
		if (Input.GetKey (KeyCode.A) && playing == true) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			running.SetBool ("RunLeft", true);
			transform.rotation = Quaternion.Euler(0f, 180f,0f);
		} else
			running.SetBool ("RunLeft", false);
		
		if (Input.GetKey(KeyCode.D) && playing == true)
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
			running.SetBool ("RunRight", true);
			transform.rotation = Quaternion.Euler(0f, 0f,0f);
		} else
			running.SetBool ("RunRight", false);
		
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
		
		if (Input.GetKey (KeyCode.S) && playing == true) {
			playerCollider.size = new Vector2 (playerCollider.size.x, 2.35f);
		} else {
			playerCollider.size = new Vector2 (playerCollider.size.x, 4.7f);
		}
		
		if (Input.GetMouseButtonDown (0) && playing == true) {
			running.Play ("Attack2.0");
			sDmg.CanDamage(true);

		}
	}
	bool IsGrounded()
	{
		return Physics2D.Raycast (feet.transform.position, -Vector2.up, 0.2f, LayerMask.GetMask("Ground"));
	}
	void Jump()
	{
		datRigidBody.AddForce (Vector2.up * jumpForce);
	}
	void AirJump()
	{
		Vector2 v2 = datRigidBody.velocity;
		v2.y = 0;
		datRigidBody.velocity = v2;
		datRigidBody.AddForce (Vector2.up * doubleJumpForce);
	}
	void FallDamage(float fall)
	{
		fall = Mathf.Round(fall);
		if(fall < -26)
		{
			health.Damage((int)(fall+26)*-1);
		}
		checkFall = false;
	}
	void SetMovement(float other)
	{
		speed = other;
	}

}




