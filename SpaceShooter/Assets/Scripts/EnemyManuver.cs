using UnityEngine;
using System.Collections;

public class EnemyManuver : MonoBehaviour {

	public Vector2 startTime;
	public Vector2 manuverTime;
	public Vector2 manuverWait;
	public float maxDodgeSpeed;
	public float tilt;
	public float smoothing;
	public Boundary boundary;

	private Rigidbody rb;
	private float currentSpeed;
	private float targetSpeed;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		currentSpeed = rb.velocity.z;
		StartCoroutine ("Evade");
	}

	IEnumerator Evade(){
		yield return new WaitForSeconds (Random.Range(startTime.x, startTime.y));
		while (true) {
			targetSpeed = Random.Range (1, maxDodgeSpeed) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (manuverTime.x, manuverTime.y));
			targetSpeed = 0f;
			yield return new WaitForSeconds (Random.Range (manuverWait.x, manuverWait.y));
		}
	}

	void FixedUpdate(){
		float newSpeed = Mathf.MoveTowards (rb.velocity.x, targetSpeed, Time.deltaTime * smoothing);
		rb.velocity = new Vector3 (newSpeed, 0.0f, currentSpeed);
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.leftMin, boundary.rightMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.bottomMin, boundary.upperMax));
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}

}
