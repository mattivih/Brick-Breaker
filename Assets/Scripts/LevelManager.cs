using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

private Score score;
private Lives lives;

	public void LoadLevel(string name){
		Debug.Log("Level load requested for: " + name);
		Bricks.breakableCount = 0;
		Application.LoadLevel(name);
	}

	public void QuitRequest(){
		Debug.Log("Level quit requested");
		Application.Quit();
	}

	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void BrickDestroyed(){
		if(Bricks.breakableCount <= 0){
			LoadNextLevel();
		}
	}
}
