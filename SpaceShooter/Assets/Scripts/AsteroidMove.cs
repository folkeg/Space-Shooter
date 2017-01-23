using UnityEngine;
using System.Collections;

public class AsteroidMove : MonoBehaviour {

	public float angleSpeed;
	public float linearSpeed;

	void Start(){
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * angleSpeed;
		rb.velocity = -transform.forward * linearSpeed;
	}
}
