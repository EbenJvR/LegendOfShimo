using UnityEngine;
using System.Collections;

public class NewestDamage : MonoBehaviour {

//	int[] damage = new int[10];
	int num;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddDamage(float value){
//		if (damage [0] == null)
//			damage[0] = (int)value;
//		else {
//			CheckMove();
//		}
		num = (int)value;
	}

//	void CheckMove(){
//		int end = 0;
//		for(int i = 1; i < 9;i++){
//			if(damage[i] == null){
//				end = i;
//			}
//		}
//		if (end == 0)
//			end = 8;
//		for (int a = end; a >= 0; a--) {
//			damage[a+1] = damage[a];
//		}
//	}

	public int GetDamage(){
//		int value;
//		value = damage [0];
		return num;
	}
}
