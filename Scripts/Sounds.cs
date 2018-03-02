using UnityEngine;
using System.Collections;


//script to handle sounds for level progression
public class Sounds : MonoBehaviour {

	public AudioClip nextLevel;
	public AudioClip wonGameSound;

	//private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		//levelManager = GameObject.FindObjectOfType<LevelManager> ();
		if (LevelManager.wonGame) {
			PlayWonGameSound();
		} else if (LevelManager.wonLevel){
			PlayWinSound();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlayWinSound() {
		AudioSource.PlayClipAtPoint (nextLevel, transform.position);
		LevelManager.wonLevel = false;
	}

	void PlayWonGameSound(){
		AudioSource.PlayClipAtPoint (wonGameSound, transform.position);
		LevelManager.wonGame = false;
	}
}
