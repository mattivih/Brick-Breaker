using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HighScore : MonoBehaviour {

	public Text highScoreBoard;
	public static int highScore;
	//public static int pos;

	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt("highScorePref");
		//highScore = PlayerPrefs.GetInt("score0");
	}
	
	// Update is called once per frame
	void Update () {
		highScoreBoard.text = highScore.ToString("");
		PlayerPrefs.SetInt("highScorePref", highScore);
		//SetHallOfFame();
	}

	public void SetHighScore(int newHighScore){
		highScore = newHighScore;
	}

	public int GetHighScore(){
		return highScore;
	}
}