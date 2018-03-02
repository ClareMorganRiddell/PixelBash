using UnityEngine;
using System.Collections;

//a class "MusicPlayer is intialized, inheriting from MonoBehaviour.
// an instance of the class called "instance" as a static variable, which persists through the game
// the Awake method checks is the instance exists. If it does, it destroys iteself
// if it doesn't exist, the value "this" is assigned to it and the instance persists
// in this way, only one instance of the music can occur, even if the Awake method is called
// by going back to the start menu.
// This is in the Awake method as this method is called first. if it was in Start method,
// all other Awakes would run first, causes a delay in the detruction of the duplicate instance of
//MusicPlayer.

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	void Awake () {;
		if (instance != null) {
			Destroy (gameObject);
//			Debug.Log ("duplicate music player is detoryed" + GetInstanceID());
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	// Not required for this Class
//	void Start () {
//		Debug.Log ("Music player Start " + GetInstanceID ());}
	
	// Update is called once per frame
	void Update () {
	
	}
}
