﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Chi : MonoBehaviour {

	Stats chiStat;
	public Slider chiSlider;
	public Text chi;

	// Use this for initialization
	void Start () {
		chiStat = GetComponent<Stats>();
		InvokeRepeating("regenChi", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		chiSlider.maxValue = chiStat.getTotalChi();
		chiSlider.value = chiStat.getCurrentChi();
		chi.text = "Chi amount: " + chiSlider.value.ToString();
	}

	public void reduceChi(int amount){
		chiStat.reduceCurrentChi (amount);
	}

	private void regenChi(){
		chiStat.increaseCurrentChi (1);
	}

	public float checkChi(){
		return chiStat.getCurrentChi ();
	}
}
