using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	//intiate autoplay functionality for playtesting
	public bool autoPlay = false;
	public float minX, maxX;
	public GameObject paddle;
	public GameObject bigPaddle;

	public bool smallPaddle;

	private Ball ball;
	private Vector3 paddlePos;


	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		if (gameObject.GetComponent<SpriteRenderer> ().sprite == paddle.GetComponent<SpriteRenderer> ().sprite) {
			smallPaddle = true;	
		} else {
			smallPaddle = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}

	void MoveWithMouse () {
		//Vector3 is a variable type that is composed of 3 float positions
		//it represents 3D vecotrs and points (x, y, z)
		//the y is set to the build mode settings
		paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		
		//this variable is the representation of the mouse position on the
		//x axis
		//it is devided by the screen width (in pixels) evaluates to a number 
		//between 0 and 1, regardless of screen size (relaive screen position)
		// screen width * world units (16) shows the game units (or 'blocks')
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		
		//set the x vector of the paddlePos to the mouse input by calling the 
		//attribute x of paddlePos and assigning it to the variable 
		//mousePosInBlocks
        if (smallPaddle) {
            paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
        } else {
            paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX +0.5f , maxX-0.5f);
        }

		//this = instance of current script = instance of Paddle script
		//transform the postion of the object assigned to the instanc eof the 
		//script (the paddle) to the vectors x = mouse input in blocks,
		// y = the game build original position, and z = 0
		this.transform.position = paddlePos;

		if (Input.GetKeyDown(KeyCode.Space)) {
			PaddleSwitch();
		}
	}

	//switches paddle size on spacebar
	public void PaddleSwitch() {
		//Debug.Log (this.GetComponent<SpriteRenderer>().name);
		GameObject switchPaddle;
		if (smallPaddle) {
			switchPaddle = bigPaddle;
		} else {
			switchPaddle = paddle;
		}
		Instantiate (switchPaddle, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	void AutoPlay() {
		paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
}
