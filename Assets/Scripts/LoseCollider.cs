using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public AudioClip loseLife;

	private LevelManager levelManager;
	private Paddle paddle;
	private Lives lives;
	//private GameObject highScore;
	//private GameObject topList;

	//clock.GetComponent<Clock>().timeStarted = false;

	void OnTriggerEnter2D (Collider2D trigger){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		paddle = GameObject.FindObjectOfType<Paddle>();
		lives = GameObject.FindObjectOfType<Lives>();
		//highScore = GameObject.Find("HighScore");
		//topList = GameObject.Find("ScoreList");
		if(trigger.gameObject.tag == "Ball") {
			if(CreateNewBall.extraBallsInPlay == false){
				if(lives.livesLeft == 1){
					//highScore.GetComponent<HighScore>().SetHallOfFame();
					PlayerPrefs.Save();
					levelManager.LoadLevel("Lose");
					//topList.GetComponent<TopList>().OnLevelComplete();
				}else{
					AudioSource.PlayClipAtPoint(loseLife, transform.position, 1f);
					lives.livesLeft = lives.livesLeft - 1;
					paddle.DestroyPaddle();
				}
			}else{
				CreateNewBall.ballCount--;
				if(CreateNewBall.ballCount == 1){
					CreateNewBall.extraBallsInPlay = false;
				}
			}
		}
	}
}
