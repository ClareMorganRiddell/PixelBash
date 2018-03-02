using UnityEngine;
using System.Collections;

public class Shrink : MonoBehaviour {

	public AudioClip fail;


	private Paddle paddle;
	private Ball ball;
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionExit2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (fail, transform.position, 0.2f);
		paddle = GameObject.FindObjectOfType<Paddle>();
		if (!paddle.smallPaddle) {
			paddle.PaddleSwitch();
		}
//		Ball.shrinkCollision = true;
		Destroy (gameObject);
	}


}
