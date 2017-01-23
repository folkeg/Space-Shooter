using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	public float scollSpeed;
	public float backGroundZSize;

	private Vector3 startPosition;

	void Start(){
		startPosition = transform.position;
	}
	void Update(){
		float newZPosition = Mathf.Repeat (Time.time * -scollSpeed, backGroundZSize);
		transform.position = startPosition + Vector3.forward * newZPosition;
	}
}
