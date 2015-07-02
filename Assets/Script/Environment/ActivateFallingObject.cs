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
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Shimo")
		{
			StartCoroutine ("Break");
		}
	}
	IEnumerator Break(){
		yield return(new WaitForSeconds (2));
		Rigid.isKinematic = false;
		yield return(new WaitForSeconds (1));
		GameObject.Destroy (gameObject);
	}
}
