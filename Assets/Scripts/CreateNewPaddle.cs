using UnityEngine;
using System.Collections;

public class CreateNewPaddle : MonoBehaviour {

	private GameObject paddleFinder;
	private Vector3 spawn;
	internal string loadablePrefab = "Paddle";

	void Update () {
		paddleFinder = GameObject.FindGameObjectWithTag("Paddle");
		if(!paddleFinder){
			NewPaddle(loadablePrefab);
		}
	}

	public void NewPaddle (string prefabName) {
		loadablePrefab = prefabName;
		if(loadablePrefab == "Paddle"){
			spawn = new Vector3(this.transform.position.x, this.transform.position.y);
		}else{
			spawn = paddleFinder.transform.position;
		}
		paddleFinder = Instantiate(Resources.Load(loadablePrefab), spawn, Quaternion.identity) as GameObject;
		loadablePrefab = "Paddle";
	}
}
