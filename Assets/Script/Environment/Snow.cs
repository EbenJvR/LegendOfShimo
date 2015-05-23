using UnityEngine;
using System.Collections;

public class Snow : MonoBehaviour {

	float snowMovement;

	void OnTriggerEnter2d(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){
		Debug.Log ("Walked through Snow");
		other.transform.SendMessage("SetMovement", snowMovement);
		}
	}
}
