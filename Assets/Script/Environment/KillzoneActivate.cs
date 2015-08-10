using UnityEngine;
using System.Collections;

public class KillzoneActivate : MonoBehaviour {

	public Collider2D LeftWall;
	public Collider2D RightWall;
	public Animator animation;
	public GameObject Melee;
	public Transform LeftSpawn;
	bool entered = false;
	bool finished = false;
	CameraLocation cam;
	Stats stat;
	public int killCounter;
	int Kills;

	
	void Start () {
		cam = (CameraLocation)FindObjectOfType(typeof(CameraLocation));
		stat = (Stats)FindObjectOfType(typeof(Stats));
	}

	void Update() {
		if (stat.kills >= Kills && finished == false && entered == true) {
			finished = true;
			LeftWall.isTrigger = true;
			RightWall.isTrigger = true;
			cam.ReturnFocus();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Shimo" && entered == false)
		{
			entered = true;
			LeftWall.isTrigger = false;
			RightWall.isTrigger = false;
			cam.ChangeFocus("KillZone",transform.position.x,transform.position.y);
			animation.Play ("Play");
			Kills = stat.kills + killCounter;
			for(int i = 0; i < killCounter; i++){
				Instantiate(Melee, LeftSpawn.position, Quaternion.identity);
			}
		}
	}
}
