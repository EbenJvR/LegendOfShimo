using UnityEngine;
using System.Collections;

public class Movement3D : MonoBehaviour {
	
	// Use this for initialization
	Rigidbody datRigidBody;
	private float direction = 90;
	
	
	void Start () {
		datRigidBody = GetComponent<Rigidbody> ();
	}
	
	//Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x,transform.position.y,-5.5f);
		transform.localEulerAngles = new Vector3 (0,direction, 0);
		if (Input.GetKeyDown (KeyCode.D)) {
			direction = 90;
			datRigidBody.AddForce(100,0,0);
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			direction = -90;
			datRigidBody.AddForce(-100,0,0);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			datRigidBody.AddForce(0,500,0);
		}
		
	}
}
