using UnityEngine;
using System.Collections;

public class RaycastTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 fwd = transform.TransformDirection (Vector3.down);
//		if (Physics.Raycast (transform.position, fwd, 10))
//			Debug.Log ("Standing on ground");

		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down,0.5f);
		
		if(hit != null && hit.collider != null){
			Debug.Log ("Grounded");
		}
		
		Vector3 forward = transform.TransformDirection(Vector3.down) * 0.5f;
		Debug.DrawRay(transform.position, forward, Color.green);
	}
}
