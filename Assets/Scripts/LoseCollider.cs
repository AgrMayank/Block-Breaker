using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private levelManager levelManager;
	void OnTriggerEnter2D (Collider2D trigger)
	{
		// print("Trigger");
		levelManager = GameObject.FindObjectOfType<levelManager>();
		levelManager.LoadLevel("Lose");
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		// print("Collision");
	}
}
