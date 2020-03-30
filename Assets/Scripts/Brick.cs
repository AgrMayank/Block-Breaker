using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	private levelManager levelManager;
	private int timesHit;
	private bool isBreakable;

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//Keep track of Breakable Bricks
		if (isBreakable)
		{
			breakableCount++;
		}

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<levelManager>();
	}

	// Update is called once per frame
	void Update () { }

	private void OnCollisionEnter2D (Collision2D collision)
	{
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if (isBreakable)
		{
			HandleHits();
		}
	}

	void HandleHits ()
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits)
		{
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		}
		else
		{
			LoadSprites();
		}
	}

	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;

		if (hitSprites[spriteIndex] != null)
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
		{
			Debug.LogError("Brick Sprite Missing!");
		}
	}
}
