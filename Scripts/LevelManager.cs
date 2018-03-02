using UnityEngine;
using System.Collections;	


public class LevelManager : MonoBehaviour {



	//attempting to save progress to load at start screen
	public static int playerProgress = 0;

	public static bool wonLevel = false;
	public static bool wonGame = false;

	public int winSceneIndex = 7;

	public void Start() {
	}



	public void LoadLevel(string name){
		ResetBrickCount ();
		Application.LoadLevel (name);
	}

	public void LoadNextLevel(){
		ResetBrickCount ();
		int nextLevel = Application.loadedLevel +1;
		if (nextLevel == winSceneIndex) {
			wonGame = true;
		} else {
			playerProgress = nextLevel;
			wonLevel = true;
		}
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void QuitRequest(){
		Debug.Log ("Quit the Game");
		Application.Quit ();
	}

	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}

	public void LoadLastSave(int lastLevel) {
		if (playerProgress > 0 && playerProgress < winSceneIndex) {
			ResetBrickCount ();
			Application.LoadLevel (Application.loadedLevel + playerProgress);
		}
	}

	public void ResetGame() {
		playerProgress = 1;
		LoadLevel ("Level_01");
	}

	private void ResetBrickCount() {
		Brick.breakableCount = 0;
	}

}
