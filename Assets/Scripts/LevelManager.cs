using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	private static float waitSecondsForNextLevel = 0.5f;

	public void LoadLevel (string name)
	{
		Debug.Log ("Level load requested for: " + name);
		Brick.breakableBricksCount = 0;
		SceneManager.LoadScene (name);
	}

	public void QuitGame ()
	{
		Debug.Log ("Quit game requested. ");
		Application.Quit ();
	}

	public void LoadNextLevel ()
	{
		Scene scene = SceneManager.GetActiveScene ();
		Brick.breakableBricksCount = 0;
		SceneManager.LoadScene (scene.buildIndex + 1);
	}

	public void BrickDestroyed ()
	{
		if (Brick.breakableBricksCount <= 0) {
			// LoadNextLevel ();
			Invoke ("LoadNextLevel", waitSecondsForNextLevel); // load new level after specified daley

			// TODO Should we freeze also the ball before loading new Level??
		}
	}
}
