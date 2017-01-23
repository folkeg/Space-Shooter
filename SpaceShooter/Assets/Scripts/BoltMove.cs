using UnityEngine;
using System.Collections;

public class BoltMove : MonoBehaviour {

	public float speed;

	void Start(){
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}
}
