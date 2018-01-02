using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public static float speed = 10f;
	public GameObject particleSystem;
	public static int scoreMultiplier;
	public static bool ballWaiting = false;
	
	private float magnitude, magnitude2;
	private Vector2 ballDirAfterPaddle;
	private Vector3 paddleToBallVector;	
	private Vector3 correction;
	private bool hasStarted = false;
	private bool magnetLaunch = false;
	private bool hitPaddle = false;
	private Paddle paddle;
	private GameObject magnetPaddle;
	private Rigidbody2D rb;
	private float[] horSpdCheck = new float[]{0,1};
	

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = transform.position - paddle.transform.position;
		scoreMultiplier = 0;
	}

	public void OnCollisionEnter2D(Collision2D collision){
		if(hasStarted){
			GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * 1.01f;
			if(collision.gameObject.tag == "Walls" || collision.gameObject.tag == "Paddle"){
				GetComponent<AudioSource>().Play();
			}
		}
		// Hit the Racket?
		if(collision.gameObject.tag == "Paddle") {
			ballDirAfterPaddle = GetComponent<Rigidbody2D>().velocity;
			scoreMultiplier = 0;
			hitPaddle = true;
			if(collision.gameObject.name == "MagnetPaddle(Clone)"){
				if(ballWaiting){
					ballWaiting = false;
					return;
				}else{
					magnetLaunch = true;
				}
			}else{
				// Calculate hit Factor
				float x = hitFactor(transform.position,	collision.transform.position, collision.collider.bounds.size.x);

				// Calculate direction, set length to 1
				Vector2 dir = new Vector2(x, 1).normalized;

				// Set Velocity with dir * speed
				GetComponent<Rigidbody2D>().velocity = dir * speed;
			}
		}else if(collision.gameObject.tag == "Breakable"){
			scoreMultiplier++;
			hitPaddle = false;
		}else{
			hitPaddle = false;
		}
	}

	// Update is called once per frame
	void Update () {
		ActivateParticles();
		Debug.Log("speed" + GetComponent<Rigidbody2D>().velocity);
		if(!hasStarted){
			// Lock the ball relative to the paddle.
			paddle = GameObject.FindObjectOfType<Paddle>();
			transform.position = paddle.transform.position + paddleToBallVector;
			// Wait for a mouse press or space-key to launch
			if(Input.GetMouseButtonDown(0) || (Input.GetKeyDown(KeyCode.Space))){
				hasStarted = true;
				LaunchBall();
				//this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, speed);
			}
		}
		if(gameObject.transform.position.y <= 0){
			Destroy(gameObject);
		}
		if(magnetLaunch){// && Pause.canPause == true){
			ballWaiting = true;
			magnetPaddle = GameObject.FindGameObjectWithTag("Paddle");
			Vector3 correction = new Vector3(0f,0.389f,0f);
			gameObject.transform.position = magnetPaddle.transform.position + correction;// + paddleToBallVector;
			GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
			if(Input.GetKeyDown(KeyCode.Space)){
				LaunchBall();
				magnetLaunch = false;
				ballWaiting = false;
			}
		}
		if(GetComponent<Rigidbody2D>().velocity.x == 0){
			GetComponent<Rigidbody2D>().velocity = new Vector2(1, GetComponent<Rigidbody2D>().velocity.y); 
		}
	}

	public void LaunchBall(){
		this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, speed);
	}

	public void SetHasStarted(bool value){
		hasStarted = value;
	}

	void Curveball(float torque, ForceMode2D mode){
        ForceMode2D _mode = mode;
        float _torgue = torque;
		rb = GetComponent<Rigidbody2D>();
		rb.AddTorque(_torgue, _mode);
	}

	void ActivateParticles(){
		GameObject particleActivate = Instantiate(particleSystem, gameObject.transform.position, Quaternion.identity) as GameObject;
		particleActivate.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	float hitFactor(Vector2 ballPosition, Vector2 paddlePosition, float paddleWidth) {
    	// ascii art:
    	//
    	// 1  -0.5  0  0.5   1  <- x value
    	// ===================  <- racket
    	//
    	return (ballPosition.x - paddlePosition.x) / paddleWidth;
	}
}
