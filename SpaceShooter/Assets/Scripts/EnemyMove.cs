using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public float speedMin;
	public float speedMax;

	void Start(){
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.velocity = -Vector3.forward * Random.Range (speedMin, speedMax);
	}
}
