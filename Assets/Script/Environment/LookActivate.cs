using UnityEngine;
using System.Collections;

public class LookActivate : MonoBehaviour {

	CameraLocation cam;

	// Use this for initialization
	void Start () {
		cam = (CameraLocation)FindObjectOfType(typeof(CameraLocation));
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Shimo")
		{
			cam.ChangeFocus("Look",transform.position.x,transform.position.y);
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Shimo")
		{
			cam.ReturnFocus();
		}
	}
}
