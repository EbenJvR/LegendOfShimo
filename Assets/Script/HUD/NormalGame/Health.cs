using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	Stats healthStat;
	public Slider healthSlider;
	private bool dead = false;
	public Text healthText;
	private float damage;

	// Use this for initialization
	void Start () {
		healthStat = GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.maxValue = healthStat.getTotalHealth();
		healthSlider.value = healthStat.getCurrentHealth();
		if (healthSlider.value == 0 && dead == false) {
			Die ();
		}
		healthText.text = "Health amount: " + healthSlider.value.ToString();
	}

	public void Damage(float amount){
		damage = healthStat.getCurrentHealth () - amount;
		healthStat.setCurrentHealth (damage);
	}

	private void Die(){
		dead = true;
		//Time.timeScale = 0F;
	}

	public float checkHealth(){
		return healthStat.getCurrentHealth();
	}

	public void increaseHealth(){
		healthStat.setCurrentHealth (healthStat.getTotalHealth());
	}
}
