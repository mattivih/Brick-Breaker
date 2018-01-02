using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour {

	public int livesLeft;
	private string nimi;

	// Use this for initialization
	void Start () {
		if(SceneManager.GetActiveScene().name == "Level_01"){
			livesLeft = 3;
		}else{
			livesLeft = PlayerPrefs.GetInt("livesPref");
		}
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetInt("livesPref", livesLeft);
		GetComponent<Text>().text = livesLeft.ToString();
	}
}
