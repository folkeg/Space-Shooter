using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float destroyDelayTime;

	void Start(){
		StartCoroutine ("DestroyExplosion");
	}

	IEnumerator DestroyExplosion(){
		yield return new WaitForSeconds (destroyDelayTime);
		Destroy (gameObject);	
	}
}
