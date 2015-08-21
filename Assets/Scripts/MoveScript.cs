﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller adn behavior
/// </summary>
public class MoveScript : MonoBehaviour {
	// 1 - designer variables

	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2 (10, 10);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2 (-1, 0);

	private Vector2 movement;
	
	void Update () {
		// 2 - Movement
		movement = new Vector2 (
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}