using UnityEngine;
using System.Collections;

public class CreateNewBall : MonoBehaviour {

	public GameObject ball;
	//public GameObject extraBall;
	//public GameObject extraBall2;
	public static int ballCount;
	public static bool extraBallsInPlay;

	private GameObject ballInPlay;
	private Vector3 spawn;
	private Vector3 correction;
	private Paddle paddle;
	
	void Start(){
		ballCount = 1;
		extraBallsInPlay = false;
		Vector3 correction = new Vector3(0f,1f,0f);
	}

	void Update () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		ballInPlay = GameObject.FindGameObjectWithTag("Ball");
		if(!ballInPlay){
			ExtraBall();
		}
		//spawn = correction + paddle.transform.position;
	}

	public void ExtraBall(){
		if(!extraBallsInPlay){
			ballInPlay = Instantiate(ball, this.transform.position, Quaternion.identity) as GameObject;
		}else{
			if(ballCount < 3){
				GameObject newBall = Instantiate(ball, ballInPlay.transform.position, Quaternion.identity) as GameObject;
				newBall.GetComponent<Ball>().LaunchBall();
				newBall.GetComponent<Ball>().SetHasStarted(true);
				ballCount++;
			/*}else if(ballCount == 2){
				ballInPlay = Instantiate(ball, ballInPlay.transform.position, Quaternion.identity) as GameObject;
				ballInPlay.LaunchBall();
				ballCount++;
			*/}
		}
	}
}
