using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	float Rotate;
	public int amount;
	bool moved;
	// Use this for initialization
	void Start () {
		Rotate = transform.rotation.z;
		amount = amount / 5;
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
		if (amount > 0) {
			for (int i = 0; i < amount; i++) {
				yield return(new WaitForSeconds (0.02f));
				Rotate += 5;
				transform.rotation = Quaternion.Euler (0f, 0f, Rotate);
			}
			moved = true;
		}
		if (amount < 0) {
			for (int i = 0; i > amount; i--) {
				yield return(new WaitForSeconds (0.02f));
				Rotate -= 5;
				transform.rotation = Quaternion.Euler (0f, 0f, Rotate);
			}
			moved = true;
		}
	}
}
