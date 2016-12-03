using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{

	static MusicPlayer instance = null;

	// It is like an init method, do the init here (expecially for singletons)
	// check also unity pattern && gameprogramming pattern
	void Awake ()
	{
		Debug.Log ("Music player Awake " + GetInstanceID ());

		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Music player Start " + GetInstanceID ());
	
	}

}
