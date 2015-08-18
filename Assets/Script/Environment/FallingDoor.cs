using UnityEngine;
using System.Collections;

public class FallingDoor : MonoBehaviour {

	float Rotate;
	bool moved;
	
	// Use this for initialization
	void Start () {
		Rotate = transform.rotation.z;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Shard" && moved == false) {
			StartCoroutine ("Rotation");
			
		}
	}
	IEnumerator Rotation(){
		for (int i = 0; i > -18; i--) {
			yield return(new WaitForSeconds (0.02f));
			Rotate -= 5;
			transform.rotation = Quaternion.Euler(0f, 0f,Rotate);
		}
		moved = true;
	}
}
