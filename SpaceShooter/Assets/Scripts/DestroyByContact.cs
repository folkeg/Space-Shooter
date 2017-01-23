using UnityEngine;
using System.Collections;

public class DestroyByContact: MonoBehaviour {

	public GameObject playerExplosion;
	public GameObject hazardExplosion;
	public GameObject bossExplosion;
	public int scoreValue;

	private GameController gamecontroller;

	void Start(){
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {
			gamecontroller = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("Cannot find GameControllerObject");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary" || other.tag == "Hazard") {
			return;
		}
		if (hazardExplosion != null) {
			if (gameObject.tag == "Hazard") {
				EnemyLife enemyLife = GetComponent<EnemyLife> ();
				enemyLife.OnDamage (1);
				RaycastHit hit;

				if (enemyLife.getStartLife () == 50) {
					Instantiate (bossExplosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
					Destroy (other.gameObject);
				}
				if (enemyLife.life <= 0) {
					Instantiate (hazardExplosion, transform.position, transform.rotation);
					gamecontroller.AddScore(scoreValue);
					Destroy (gameObject);
				}
				Destroy (other.gameObject);
			}
		}
		if (other.tag == "Player") {
			Instantiate (playerExplosion, transform.position, transform.rotation);
			Destroy (gameObject);
			Destroy (other.gameObject);
			gamecontroller.endGame ();
		}
	}
}
