using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public AudioClip collect;

	private GameObject paddleNew;
	private GameObject paddleInPlay;
	private GameObject spawnExtraBall;
	public static int scorePU;

	void Update(){
		gameObject.transform.Rotate(0,0,180*Time.deltaTime);
		if(gameObject.transform.position.y <= 0.1f){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D trigger){
		paddleInPlay = GameObject.FindGameObjectWithTag("Paddle");
		paddleNew = GameObject.FindGameObjectWithTag("PaddlePosition");
		spawnExtraBall = GameObject.FindGameObjectWithTag("BallPosition");
		//scorePU += 5000;
		if(trigger.gameObject.tag == "Paddle"){

			AudioSource.PlayClipAtPoint(collect, transform.position, 1f);
			if(gameObject.tag == "PU_long"){
				paddleNew.GetComponent<CreateNewPaddle>().NewPaddle("LongPaddle");
				Destroy(paddleInPlay);
			}else if(gameObject.tag == "PU_magnet"){
				paddleNew.GetComponent<CreateNewPaddle>().NewPaddle("MagnetPaddle");
				Destroy(paddleInPlay);
			}else if(gameObject.tag == "PU_xtraBall"){
				CreateNewBall.extraBallsInPlay = true;
				spawnExtraBall.GetComponent<CreateNewBall>().ExtraBall();
			}
		Destroy(gameObject);
		}
	}
}
