using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	private Vector3 vector;
	private Vector3 distance;
	private Paddle paddlePos;

	// Use this for initialization
	void Start () {
		Movement();
	}
	
	// Update is called once per frame
	void Update () {
		paddlePos = GameObject.FindObjectOfType<Paddle>();
		distance = gameObject.transform.position - paddlePos.transform.position;
		Debug.Log("Dist " + distance);
	}

	void Movement(){
		//float rDirX = Random.Range(10, 31);
		//float rDirY = Random.Range(1, 21);
		//this.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 3f);
	}

	/*
	void OnCollisionEnter2D (Collision2D collision){
		if(collision.gameObject.tag == "Walls"){
			float rDirX = Random.Range(10, 31);
			float rDirY = Random.Range(1, 21);
			vector = Quaternion.Euler(0,0,-45) * vector;
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(vector, 3f);
			Debug.Log("collision");
		}
	}*/
}
