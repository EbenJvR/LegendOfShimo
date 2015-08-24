using UnityEngine;
using System.Collections;

public class Snow : MonoBehaviour {

	public float snowMovement;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Shimo"){
		other.transform.SendMessage("SetMovement", snowMovement);
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Shimo") {
			other.transform.SendMessage("ReturnMovement");
		}
	}
}
