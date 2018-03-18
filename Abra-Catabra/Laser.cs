using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float speed;
	public float growFactor;

	public float delayTime;

	private float maxScale = 2.0f;
	private float tempScaleX;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = Time.time + delayTime;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (timer + " : " + Time.time);
		if (Time.time > (timer - delayTime/2)) {
			Debug.Log ("Renderer On");
			GetComponent<Renderer> ().enabled = true;
		}

		if (Time.time > timer) {
			Debug.Log ("Fire!");
			GetComponent<Rigidbody2D> ().velocity = -(transform.up * speed);
			if (transform.localScale.y < maxScale) {
				tempScaleX += Time.deltaTime * growFactor;
				transform.localScale = new Vector3 (transform.localScale.x, tempScaleX, transform.localScale.z);
			}
		}
	}
}
