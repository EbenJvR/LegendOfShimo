using UnityEngine;
using System.Collections;

public class DamageAmount : MonoBehaviour {
	Rigidbody2D rigid;
	TextMesh text;
	NewestDamage DamAmount;
	// Use this for initialization
	void Start () {
		DamAmount = (NewestDamage)FindObjectOfType (typeof(NewestDamage));
		text = GetComponent<TextMesh> ();
		rigid = GetComponent<Rigidbody2D> ();
		rigid.AddForce (Vector2.up * 200);
		text.text = DamAmount.GetDamage ().ToString();
	}

	void Update(){
		GameObject.Destroy (gameObject, 2);
	}
}
