using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public float intervalWait;
	public float spawnWait;
	public float spawnAmount;
	public GameObject[] hazards;
	public GameObject boss;
	public Transform spawnValue;
	public Text scoreText;
	public Text gameOverText;
	public Text restartText;
	public float bossTime;

	private bool gameOver;
	private bool restart;
	private int score;

	// Use this for initialization
	void Start () {
		StartCoroutine ("SpawnWaves");
		AudioSource backgroundMusic = GetComponent<AudioSource> ();
		backgroundMusic.Play ();
		gameOver = false;
		restart = false;
		score = 0;
	}

	void Update(){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				restartGame ();
			}
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (intervalWait);
		while (true) {
			if (gameOver) {
				break;
			}
			if (Time.time > bossTime) {
				SpawnBoss ();
				break;
			}
			for (int i = 0; i < spawnAmount; i++) {
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (
					Random.Range(-spawnValue.position.x, spawnValue.position.x),
					spawnValue.position.y,
					spawnValue.position.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (intervalWait);
		}
	}

	void restartGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void endGame(){
		gameOver = true;
		restart = true;
		gameOverText.text = "Game Over!";
		restartText.text = "Press R to restart";
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScoreText ();
	}

	void UpdateScoreText(){
		scoreText.text = "Score " + score;
	}

	void SpawnBoss(){
		Vector3 spawnPosition = new Vector3 (
			Random.Range(-spawnValue.position.x, spawnValue.position.x),
			spawnValue.position.y,
			spawnValue.position.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (boss, spawnPosition, spawnRotation);
	}
}
