using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public string message;
	public Slider Board;
	public Text TutorialText;

	void Start(){
		Board.maxValue = 4;
		Board.value = 0;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Shimo")
		{
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
			TutorialText.text = "";
		}
	}
	IEnumerator Up(){
		for (int i = 0; i < 4; i++) {
			yield return(new WaitForSeconds (0.05f));
			Board.value++;
		}
		TutorialText.text = message;
		if (Board.value != Board.maxValue)
			Board.value = Board.maxValue;
	}
	IEnumerator Down(){
		TutorialText.text = "";
		for (int i = 0; i < 4; i++) {
			yield return(new WaitForSeconds (0.05f));
			Board.value--;
		}
		if (Board.value != 0)
			Board.value = 0;
		StartCoroutine ("Clear");
	}
	IEnumerator Clear(){
		yield return(new WaitForSeconds (0.01f));
		if (TutorialText.text != "")
			TutorialText.text = "";
	}
}
