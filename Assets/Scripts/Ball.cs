﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

	private Paddle paddle;

	private bool hasStarted = false;

	private Vector3 paddleToBallVector;

	private Rigidbody2D body2D;

	private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		paddle = GameObject.FindObjectOfType<Paddle> ();
		body2D = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted) {
			// Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for a mouse press to launch.
			if (Input.GetMouseButtonDown (0)) {
				print ("Mouse clicked, launch ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	
	}

	void OnCollisionEnter2D (Collision2D collision2D)
	{
		if (hasStarted) {
			audioSource.Play ();
		}

		// add random velociy to avoid booring loop
		Vector2 tweak = new Vector2 (Random.Range (-0.2f, 0.2f), Random.Range (0f, 0.2f));
		body2D.velocity += tweak; 

	}

}