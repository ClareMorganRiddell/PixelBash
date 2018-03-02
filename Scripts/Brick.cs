using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	//epose public variabel for audio to access the
	//PlayClipAtPoint method - this better utilaizes the
	//states of the brick
	public AudioClip crack;
	//a public Sprite array, to add decay sprites to blocks
	//a public static counter of brick instances with the 
	//"Breakable" tag incremented in Start()
	public Sprite[] hitSprites;
	public GameObject smoke;
	public static int breakableCount = 0;

	//private variable to log collisions of brick instance
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		//finds instance of class LevelManager
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
		smoke.transform.position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionExit2D (Collision2D collision) {	
		if (isBreakable) {
			HandleHits ();
		}
	}

	//method manages hits on brick to a max on the prefab settings 
	//of the brick
	//when max hits is exceeded, LevelManger method is called to 
	//check if teh last brick was hit. If so, the next level is 
	//loaded. Else, the next sprite is loaded.
	void HandleHits() {
		timesHit++;
		AudioSource.PlayClipAtPoint (crack, transform.position);
		int maxHits = hitSprites.Length +1;
		// >= to ensure always breaking
		if (timesHit >= maxHits) {
			DestroyBrick();
		} else {
			LoadSprites(); 
		}
		//		SimulateWin();
	}

	void DestroyBrick() {
		MakeSmoke ();
		Destroy(gameObject);
		breakableCount--;
		levelManager.BrickDestroyed();
	}

	//loads the appropriate sprote according to the brick state
	//in Sprite Renderer window, the attirbute "sprite" is accessed
	// the sprite from the array is allocated
	void LoadSprites() {
		int spriteIndex = timesHit -1;
		if (hitSprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError("Sprite missing");
		}
	}

	//instantiate an instance of the smoke game object and set it's colour
	//"as GameObject" is required as Instantiate only handle objects.
	//the Vector3 can be simply tansform.postion, as Unity assumes this is 
	//inherited from the gameObject.
	void MakeSmoke() {
		GameObject crumbledBrick = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		crumbledBrick.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer> ().color;

	}

	//method handles detroyed bricks
	//decrements brick count towards Win result
//	void DestroyBrick() {
//		Debug.Log ("Brick Destroyed");
//		Destroy(gameObject);
//		breakableCount--;
//		Debug.Log (breakableCount);
//	}


	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
