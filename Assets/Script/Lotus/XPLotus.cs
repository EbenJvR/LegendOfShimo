using UnityEngine;
using System.Collections;

public class XPLotus : MonoBehaviour {

	private XP xpScript;
	public int xpGain;
	
	void Start()
	{
		xpScript = (XP)FindObjectOfType (typeof(XP));
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Shimo") 
		{
			xpScript.increaseXP(xpGain);
			this.gameObject.SetActive(false);
		}
		
	}
}
