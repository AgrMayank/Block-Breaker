using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;
	// Use this for initialization

	private void Awake ()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			// print("Duplicate Music Player self Destructing!");
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
