using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Score : MonoBehaviour {

	public static float timer;
	public bool timeStarted = false;
	public static bool scorePoint = false;
	public Text scoreBoard;
	public static int gameScoreTotal;

	private int extraGuy;
	private Lives lives;
	private HighScore highScore;
	private int hScore = 0;
	
	// GetComponent<Text>().text = Time.time.ToString("0.0");

	// Use this for initialization
	void Start () {
		timer = 0f;
		timeStarted = true;
		if(SceneManager.GetActiveScene().name == "Level_01"){
			gameScoreTotal = 0;
		}else{
			gameScoreTotal = PlayerPrefs.GetInt("scorePref");
		}
		scoreBoard.text = gameScoreTotal.ToString("");
		lives = GameObject.FindObjectOfType<Lives>();
		highScore = GameObject.FindObjectOfType<HighScore>();
		hScore = highScore.GetHighScore();
	}

	// Update is called once per frame
	void Update () {
		if (timeStarted == true) {
			timer += Time.time;
		}
		if(scorePoint){
			Scoring();
		}
		if(gameScoreTotal > hScore){
			highScore.SetHighScore(gameScoreTotal);
		}
	}

	void Scoring(){
		gameScoreTotal = gameScoreTotal + (Bricks.score * Ball.scoreMultiplier);
		PlayerPrefs.SetInt("scorePref", gameScoreTotal);
		//Debug.Log("gameScoreTotal + Bricks.score + Ball.scoreMultiplier = " + gameScoreTotal + " " + Bricks.score + Ball.scoreMultiplier);
		scoreBoard.text = gameScoreTotal.ToString("");
		extraGuy = extraGuy + (Bricks.score * Ball.scoreMultiplier);
		if(extraGuy >= 100000){
			lives.livesLeft++;
			GetComponent<AudioSource>().Play();
			extraGuy = extraGuy - 100000;
		}
		scorePoint = false;
	}
}
