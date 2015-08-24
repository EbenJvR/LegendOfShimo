using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	Stats healthStat;
	public Slider healthSlider;
	private bool dead = false;
	float flashspeed = 1f;
	Color flashColor = new Color (1f, 0f, 0f, 0.1f);
	public Image flashImage;

	// Use this for initialization
	void Start () {
		healthStat = GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update () {
		flashImage.color = Color.Lerp (flashImage.color, Color.clear, flashspeed * Time.deltaTime);
		healthSlider.maxValue = healthStat.getTotalHealth();
		healthSlider.value = healthStat.getCurrentHealth();
		if (healthSlider.value == 0 && dead == false) {
			Die ();
		}
		if (healthStat.getCurrentHealth() > healthStat.getTotalHealth())
			healthStat.setCurrentHealth(healthStat.getTotalHealth());
	}

	public void Damage(int amount){
		healthStat.reduceCurrentHealth (amount);
		flashImage.color = flashColor;
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

	public void RestoreHealth(float amount)
	{

		healthStat.increaseCurrentHealth ((int)amount);
	}
}
