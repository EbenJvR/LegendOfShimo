using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

	BoxCollider2D waterCollider;
	private Animator water;

	// Use this for initialization
	void Start () {
		waterCollider = GetComponent<BoxCollider2D>();
		water = GetComponent<Animator> ();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Shimo") {
			other.transform.SendMessage ("Damage", 500);
		}
		if (other.gameObject.tag == "Blizzard") {
			waterCollider.isTrigger = false;
			water.SetBool ("Frozen", true);
			StartCoroutine ("Unfreeze");
		}
	}
	IEnumerator Unfreeze(){
		yield return(new WaitForSeconds (5));
		waterCollider.isTrigger = true;
		water.SetBool ("Frozen", false);
	}
}
