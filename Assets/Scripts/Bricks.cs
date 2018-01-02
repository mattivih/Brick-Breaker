using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	public int maxHits; 
	public int timesHit;
	public static int score;
	public AudioClip crack;
	public AudioClip destroyed;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	public GameObject PowerUp;
	public GameObject PowerUp2;
	public GameObject PowerUp3;

	private LevelManager levelManager;
	private Score currentScore;
	private GameObject usedSmoke;
	private bool isBreakable;


	
	// Use this for initialization
	void Start () {
		score = 0;
		isBreakable = (this.tag == "Breakable");
		// keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnCollisionEnter2D (Collision2D collision){
		AudioSource.PlayClipAtPoint(crack, transform.position, 1f);
		if(isBreakable){
			HandleHits();
		}
	}

	void HandleHits(){
		timesHit++;
		maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			breakableCount--;
			score = maxHits * 500;
			Score.scorePoint = true;
			levelManager.BrickDestroyed();
			PuffSmoke();
			int rPU = Random.Range(1, 11);
			if(rPU == 1){
				SpawnPowerUp();
			}
			AudioSource.PlayClipAtPoint(destroyed, transform.position, 1f);
			Destroy(gameObject);
		}else{
			LoadSprites();
		}
	}
	
	void SpawnPowerUp(){
		string ladyLuck = RandomPowerUp();
		if(ladyLuck == "PU_long"){
			GameObject powerUp = Instantiate(PowerUp, this.transform.position, Quaternion.identity) as GameObject;
		}else if(ladyLuck == "PU_magnet"){
			GameObject powerUp = Instantiate(PowerUp2, this.transform.position, Quaternion.identity) as GameObject;
		}else if(ladyLuck == "PU_xtraBall"){
			GameObject powerUp = Instantiate(PowerUp3, this.transform.position, Quaternion.identity) as GameObject;
		}
	}

	void PuffSmoke(){
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		//smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex] != null){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}else{
			Debug.LogError("Sprite missing.");
		}
	}

	public string RandomPowerUp(){
		string randomPU;
		int rPU = Random.Range(1, 11);
		if(rPU <= 5){
			randomPU = "PU_long";
		}else if(rPU >= 6 && rPU <= 8){ 
			randomPU = "PU_magnet";
		}else{
			randomPU = "PU_xtraBall";
		}
		return randomPU;
	}
}
