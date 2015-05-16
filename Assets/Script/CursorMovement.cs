using UnityEngine;
using System.Collections;

public class CursorMovement : MonoBehaviour {

	Vector3 mousePosition;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = mousePosition;
		transform.position = new Vector3 (transform.position.x, transform.position.y, -1);
		//transform.position += Vector3.right * 6 * Time.deltaTime;
	}
}
