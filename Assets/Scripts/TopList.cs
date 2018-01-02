/*using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TopList : MonoBehaviour {

    public bool gameComplete;
	public int score;
	public static string[] allTimeBest = new string[10] {"RIP", "CAR", "RIE", "FIS", "HER", "PRI", "NCE", "SSL", "EIA", "RIP"};
	public static int[] top10 = new int[10] {500000, 450000, 400000, 350000, 300000, 250000, 200000, 150000, 100000, 50000};
	public HighScore highScore;
     
    void Start () {
		//PlayerPrefs.DeleteAll();
		gameComplete = true;
    	score = 0;
		for(int i = 0; i < 10; i++){
			if(top10[i] % ((i+1) * 50000) == 0){
			}else{
				allTimeBest[i] = PlayerPrefs.GetString("name" + i);
				top10[i] = PlayerPrefs.GetInt("score" + i);
			}
		}
		//highScore = GameObject.Find("HighScore");
		OnGameComplete();
		
		for(int i = 0; i < 10; i++){
			if(top10[i] % ((i+1) * 100000) == 0){
				name = allTimeBest[i];
				score = top10[i];
			}else{
				name = PlayerPrefs.GetString("name" + i);
				score = PlayerPrefs.GetInt("score" +i );
			}
			PlayerPrefs.SetString("name" + i, name);
			PlayerPrefs.SetInt("score" + i, score);
		}
	}

	void Update(){
		if(SceneManager.GetActiveScene().name == "Lose" && gameComplete == true){
			Debug.Log("OnGameComplete");
			OnGameComplete();
			SetHallOfFame();
			gameComplete = false;
		}
	} 

    public void OnGameComplete () {
    	for(int i = 0; i < 10; i++){
			name = allTimeBest[i];
			score = top10[i];
			PlayerPrefs.SetString("name" + (i+1), name);
			PlayerPrefs.SetInt("score" + (i+1), score);
		}
	}

	public void SetHallOfFame(){
		Debug.Log("SetHallOfFame");
		int pos = 0;
		int highScr = highScore.GetHighScore();
		for(int i = 0; i < 10; i++){
			if(highScr > TopList.top10[i]){
				pos = i;
				break;
			}
		}
		for(int i = 8; i >= pos; i--){
			TopList.top10[i+1] = TopList.top10[i];
		}
		TopList.top10[pos] = highScr;
	}
     
    void OnGUI() {
		GUIStyle myStyle = new GUIStyle();
    	Font myFont = (Font)Resources.Load("Fonts/ARCADECLASSIC", typeof(Font));
		myStyle.font = myFont;
		myStyle.fontSize = 40;
		Color myColor = new Color(1F, 0.35F, 0.9F, 1F);
		myStyle.normal.textColor = myColor;
		GUIStyle myStyleH = new GUIStyle();
		myStyleH.font = myFont;
		myStyleH.fontSize = 40;
		Color myColorH = new Color(0.05F, 1F, 0F, 1F);
		myStyleH.normal.textColor = myColorH;
		GUI.Box(new Rect(200, 120, 400, 30), "RANK\tNAME\tSCORE", myStyleH);
        for(int i = 0; i < 10; i++){
			if(i == 0){
				GUI.Box(new Rect(200,150,400,30),"      "+(i+1)+"\t\t"+PlayerPrefs.GetString("name"+i)+"\t\t"+PlayerPrefs.GetInt("score"+i),myStyle);
			}else{
				   GUI.Box(new Rect(200,150+30*i,400,30),"      "+(i+1)+"\t\t"+PlayerPrefs.GetString("name"+i)+"\t\t"+PlayerPrefs.GetInt("score"+i),myStyle);
           	}
		}
	}
}
*/