using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public static bool shrinkCollision = false;

	private Paddle paddle;
	private bool hasGameStarted = false;
	private Vector3 paddleToBallVector;

//	private int framesWaited = 0;
//	private int secondsCrazyBall = 3;
	private float launchDirection = 2f;
	private float normalSpeed = 10f;


	// Use this for initialization
	void Start () {
		//finds the object type Paddle, for ball Prefab
		paddle = GameObject.FindObjectOfType<Paddle>();
		//paddle to ball vector is the balls position - paddle's position
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasGameStarted) {
			//lock the ball to the paddle:
			//update the position of the ball to be exactly the paddle position
			//plus the offset to be on top of it
			//NB: set the execution order of the scripts so that the paddle script
			//executes first, otherwise the ball mayfly off
			this.transform.position = paddle.transform.position + paddleToBallVector;

			//on a mouse release, the game has started
			// the ball no longer needs to be locked to the paddle, and gets a 
			//push 
			if (Input.GetMouseButtonUp (0)) {
				hasGameStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (launchDirection, normalSpeed);
			}
		}
		//		if (shrinkCollision) {CrazyBall()};

	}

	//play audio on 	collision #with brick
	//adjust velocity slightly with a random float that is generated
	//and applied with each impact
	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 tweakVelocity = new Vector2 (Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f));
		if (hasGameStarted) {
			GetComponent<AudioSource>().Play ();
			if (shrinkCollision) {
//				CrazyBall();
			}
			GetComponent<Rigidbody2D>().velocity += tweakVelocity;
		}
	}

//	void CrazyBall (){
//		if (framesWaited < secondsCrazyBall) {
//			Vector2 trajectory = this.rigidbody2D.velocity;
//			Vector2 crazyTrajectory = this.rigidbody2D.velocity;
//			crazyTrajectory.x =+ Random.Range (-50f, 50f);
//			crazyTrajectory.y =+ Random.Range(10000f, 20000f);
//			this.rigidbody2D.velocity = crazyTrajectory;
//			Debug.Log ("crazy direction" + crazyTrajectory.x);
//			framesWaited++;
//			shrinkCollision = false;
//			this.rigidbody2D.velocity = trajectory;
//		} else {framesWaited = 0;}
//	}




}
