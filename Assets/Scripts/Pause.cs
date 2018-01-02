using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	//public static bool canPause;
	private bool pauseEnabled;

	// Use this for initialization
	void Start () {
		pauseEnabled = false;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("p")){
			if(pauseEnabled == true){
				pauseEnabled = false;
				Time.timeScale = 1;
			}
			else if(pauseEnabled == false){
				pauseEnabled = true;
            	Time.timeScale = 0;
			}
		}
	}
}
