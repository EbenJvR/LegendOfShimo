using UnityEngine;
using System.Collections;

public class IsRollingObjectSpawn : MonoBehaviour 
{
	
	public bool spawnObject;
	
	public Object rollingObject;
	
	public Transform spawningPoint;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Shimo" && spawnObject == false) 
		{
			Debug.Log("Player has passed");
			//spawningPoint.transform.position in Instantiate will get the position of where it needs to spawn.

			Instantiate(rollingObject, spawningPoint.transform.position, Quaternion.identity);


			spawnObject = true;
		}
	}


	//Old code with raycast used.

	//bool spawn;
	//public LayerMask playerMask ;
	//int layermask = 1 << 8;
	// This would cast rays only against colliders in layer 8.


	//RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.up, 6000, layermask);
	
	//if (hit.collider != null) 
	//{
	//Debug.Log("Player has passed");
	//spawn = false;
	//}

}
