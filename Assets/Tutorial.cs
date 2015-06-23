using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public string message;
	public GameObject Board;
	public Text TutorialText;
	Transform start;

	void Start(){
		start.position = Board.transform.position;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Shimo")
		{
			TutorialText.text = message;
			StartCoroutine ("Up");
//			Board.transform.position += Vector3.up * 12000 * Time.deltaTime;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Shimo")
		{
//			Board.transform.position += Vector3.down * 12000 * Time.deltaTime;
			StartCoroutine ("Down");
		}
	}
	IEnumerator Up(){
		for (int i = 0; i < 4; i++) {
			yield return(new WaitForSeconds (0.05f));
			Board.transform.position += Vector3.up * 3000 * Time.deltaTime;
		}
	}
	IEnumerator Down(){
		for (int i = 0; i < 4; i++) {
			yield return(new WaitForSeconds (0.05f));
			Board.transform.position += Vector3.down * 3000 * Time.deltaTime;
		}
		TutorialText.text = "";
		CheckPosition ();
	}
	void CheckPosition(){
		if (Board.transform.position != start.transform.position) {
			Board.transform.position = start.position;
			Debug.Log ("Changed");
		}
	}
}
