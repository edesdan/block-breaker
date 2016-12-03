using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour
{


	private LevelManager levelManager;


	// Use this for initialization
	void Start ()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	// Check colllision action matrix here: https://docs.unity3d.com/Manual/CollidersOverview.html
	// messages to intercept for triggers
	void OnTriggerEnter2D (Collider2D collider)
	{
		print ("Trigger");
		levelManager.LoadLevel ("Screen Lose");

	}

	// messages to intercept for collisions
	void OnCollisionEnter2D (Collision2D collision)
	{
		print ("Collision");
	}
}
