using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{

	public static int breakableBricksCount = 0;

	public AudioClip crack;

	public AudioClip brickDestroyed;

	public Sprite[] hitSprites;

	public GameObject smoke;

	private int timesHint;

	private int maxHits;

	private LevelManager levelManager;

	private bool isBreakable;

	private Vector3 brickPosition;

	private Color brickColor;

	void Start ()
	{
		isBreakable = (this.tag == "Breakable");
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHint = 0;
		maxHits = hitSprites.Length + 1;
		brickPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		brickColor = this.GetComponent<SpriteRenderer> ().color;

		if (this.isBreakable) {
			breakableBricksCount++;
			Debug.Log ("Breakable bricks: " + breakableBricksCount);
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		print ("Collision");

		if (isBreakable) {
			HandleHits ();
		}

	}

	void HandleHits ()
	{
		timesHint++;

		if (timesHint >= maxHits) {
			breakableBricksCount--;
			AudioSource.PlayClipAtPoint (brickDestroyed, brickPosition, 0.8f);
			EmitSmoke ();
			Destroy (gameObject);
			levelManager.BrickDestroyed ();
			Debug.Log ("Breakable bricks: " + breakableBricksCount);
		} else {
			AudioSource.PlayClipAtPoint (crack, brickPosition, 0.8f);
			LoadSprites ();
		}
	}

	void EmitSmoke ()
	{
		GameObject smokeParticles = Instantiate (smoke, brickPosition, Quaternion.identity) as GameObject;
		smokeParticles.GetComponent<ParticleSystem> ().startColor = brickColor;
	}

	void LoadSprites ()
	{
		int spriteIndex = timesHint - 1;
		if (hitSprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("no sprite found!!");
		}

	}
	
	// TODO remove this method when we actually can win!!!!

	void SimulateWin ()
	{
		levelManager.LoadNextLevel ();
	}
}
