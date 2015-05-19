using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XP : MonoBehaviour {

	Stats xpStat;
	public Slider xpSlider;
	private int points;
	private int level;
	private int[] xp = new int[3];
	public Text Experience;
	
	// Use this for initialization
	void Start () {
		xpStat = GetComponent<Stats>();
		xp[0] = 10;
		xp[1] = 10;
		xp[2] = 10;
		xpSlider.maxValue = xp [xpStat.getLevel()];
	}
	
	// Update is called once per frame
	void Update () {
		xpSlider.value = xpStat.getCurrentXp();
			if (xpSlider.value == xp [xpStat.getLevel()]) {
			Level ();
		}
		Experience.text = "XP amount: " + xpSlider.value.ToString();
	}
	
	public void increaseXP(int amount){
		xpStat.increaseCurrentXp(amount);
	}

	private void Level(){
		points = xpStat.getPoints() + 1;
		xpStat.setPoints (points);
		level = xpStat.getLevel () + 1;
		xpStat.setLevel (level);
		xpStat.setCurrentXp(0);
		xpSlider.maxValue = xp [xpStat.getLevel()];
		Debug.Log ("Leveld");
	}

	private void FindObjects(){

	}
}
