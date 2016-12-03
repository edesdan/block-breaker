using UnityEngine;
using System.Collections;

// it can be attached to an object to control the movements with the accelerometer
public class AccelerometerInput : MonoBehaviour
{
	void Update ()
	{
		Debug.Log("Acceleration:" + Input.acceleration.x);
		this.transform.Translate (Input.acceleration.x, 0, 0);
		Debug.Log("Transform x:" + this.transform.position.x);
	}


}
