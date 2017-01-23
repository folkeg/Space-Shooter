using UnityEngine;
using System.Collections;

public class EnemyWeaponController : MonoBehaviour {

	public Vector2 fireRate;
	public Vector2 delay;
	public Vector2 spawnAmount;
	public GameObject enemyBolt;
	public Transform[] spawnValue;
	private AudioSource weaponSound;

	private int randomLen;
	private float randomDelay;
	private float randomFireRate;
	private float randomSpawnAmount;

	void Start(){
		StartCoroutine ("SpawnFire");
		weaponSound = GetComponent<AudioSource> ();
	}

	IEnumerator SpawnFire(){
		yield return new WaitForSeconds (Random.Range (delay.x, delay.y));
		while (true) {
			randomSpawnAmount = Random.Range (spawnAmount.x, spawnAmount.y);
			randomDelay = Random.Range (delay.x, delay.y);
			for (int i = 0; i < randomSpawnAmount; i++) {
				randomLen = Random.Range (1, spawnValue.Length + 1);
				randomFireRate = Random.Range (fireRate.x, fireRate.y);
				for (int j = 0; j < randomLen; j++) {
					Instantiate (enemyBolt, spawnValue [j].position, spawnValue [j].rotation);
				}
				weaponSound.Play ();
				yield return new WaitForSeconds (randomFireRate);
			}
			yield return new WaitForSeconds (randomDelay);
		}
	}
}
