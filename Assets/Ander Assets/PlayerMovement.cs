using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 3.0f;
	public float jumpForce;
	public float doubleJumpForce;
	public bool isGrounded = false; //this can be seen working in the Unity inspector
	int currentJump = 0;
	float rayCastDistance;
	Rigidbody2D datRigidBody;
	public Transform pointA;
	public Transform pointB;
	public LayerMask layerMask;
	public GameObject avalanche;
	public Transform waveSpawn;

	void Awake()
	{
		datRigidBody = GetComponent<Rigidbody2D> ();
	}
	void Update() 
	{
		if (IsGrounded()) 
		{
			isGrounded = true;
			currentJump = 0;
		} else 
		{
			isGrounded = false;
		} 

		var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		transform.position += move * speed * Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.Space))
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


		if (Input.GetKeyDown (KeyCode.Mouse1))
		{
			if(IsGrounded())
			{
				Instantiate(avalanche, waveSpawn.position, waveSpawn.rotation);
			}
		}

	}
	bool IsGrounded()
	{
		return Physics2D.OverlapArea(pointA.position, pointB.position, layerMask);
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
}
