using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public static Vector2 paddleSpeed;
	public bool autoPlay = true;
	public float speed = 15;

	private Ball ball;
	
	
	public void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}

	// Update is called once per frame
	void Update () {
		//AutoPlay();
		if(!autoPlay){
			MoveWithKeys();
			//MoveWithMouse();
		}else{
			AutoPlay();
		}
		paddleSpeed = this.gameObject.GetComponent<Rigidbody2D>().velocity;
		//Debug.Log("PS: " + paddleSpeed);
	}

	public void DestroyPaddle(){
		Destroy(gameObject);
	}

	void AutoPlay(){
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, 0.81f, 15.18f);
		this.transform.position = paddlePos;
	}

	void MoveWithKeys(){
		float h = Input.GetAxisRaw("Horizontal");
		GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
		var paddlePos = Camera.main.WorldToViewportPoint(transform.position);
		if(gameObject.name == "LongPaddle(Clone)"){
			paddlePos.x = Mathf.Clamp(paddlePos.x, 0.075f, 0.925f);
		}else{
			paddlePos.x = Mathf.Clamp(paddlePos.x, 0.05f, 0.95f);
		}
 		transform.position = Camera.main.ViewportToWorldPoint(paddlePos);
	}

	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.81f, 15.18f);
		this.transform.position = paddlePos;
	}
}
