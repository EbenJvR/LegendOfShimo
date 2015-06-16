using UnityEngine;
using System.Collections;

public class ActivateFallingObject : MonoBehaviour {

	Rigidbody2D Rigid;
	
	void Start(){
		
		Rigid = gameObject.GetComponentInParent <Rigidbody2D>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Shard")
		{
			Rigid.gravityScale = 3;
		}
	}
}
