using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XP : MonoBehaviour {

	Stats xpStat;
	public Slider xpSlider;
	private int points;
	private int level;
	private int[] xp = new int[3];
	
	// Use this for initialization
	void Start () {
		xpStat = GetComponent<Stats>();
		xp[0] = 1;
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
	}
	
	public void increaseXP(int amount){
		xpStat.increaseCurrentXp(amount);
	}

	private void Level(){
		points = xpStat.getPoints() + 1;
		xpStat.setPoints (points);
		level = xpStat.getLevel () + 1;
		xpStat.setLevel (level);
		xpStat.increasePoints (1);
		xpStat.setCurrentXp(0);
		xpSlider.maxValue = xp [xpStat.getLevel()];
		Debug.Log ("Leveld");
	}

	private void FindObjects(){

	}
	public int ReturnMaxXP(){
		int x = xp [xpStat.getLevel ()];
		if (x != null)
			return x;
		else
			return -1;
	}
}
