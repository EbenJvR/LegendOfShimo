using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour {


	Rigidbody2D Rigid;

	void Start(){
		
		Rigid = GetComponent<Rigidbody2D> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			Rigid.gravityScale = 3;
		}
	}
}
