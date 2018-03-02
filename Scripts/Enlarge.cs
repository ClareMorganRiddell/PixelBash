using UnityEngine;
using System.Collections;

public class Enlarge : MonoBehaviour {

	
	public AudioClip ping;

	private Paddle paddle;


	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionExit2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (ping, transform.position, 0.5f);
		if (paddle.smallPaddle) {
			paddle.PaddleSwitch();
		}
		Destroy (gameObject);
	}
}
