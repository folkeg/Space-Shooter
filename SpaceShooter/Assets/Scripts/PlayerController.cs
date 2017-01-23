using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float leftMin;
	public float rightMax;
	public float bottomMin;
	public float upperMax;
}

public class PlayerController : MonoBehaviour {

	public Boundary boundary;
	public float speed;
	public float fireRate;
	public float tilt;
	public Transform[] spawnPoint;
	public GameObject bolt;
	private AudioSource weaponSound;

	private Rigidbody rb;
	private float nextFire;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		nextFire = 0.0f;
		weaponSound = GetComponent<AudioSource> ();
	}

	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			weaponSound.Play ();
			nextFire = Time.time + fireRate;
			Quaternion boltRotation = Quaternion.identity;
			Instantiate (bolt, spawnPoint[0].position, spawnPoint[0].rotation);
			Instantiate (bolt, spawnPoint[1].position, spawnPoint[1].rotation);
			Instantiate (bolt, spawnPoint[2].position, spawnPoint[2].rotation);
		}
	}

	void FixedUpdate(){
		float horizontalMove = Input.GetAxis ("Horizontal");
		float verticalMove = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (horizontalMove * speed, 0.0f, verticalMove * speed);
		rb.MovePosition (rb.position + movement	);
		//rb.velocity = new Vector3 (horizontalMove * speed, 0.0f, verticalMove * speed);
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.leftMin, boundary.rightMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.bottomMin, boundary.upperMax));
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);	
	}
}
