using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed = 1f;
	public float bobSpeed = 1f;
	public float amplitude;

	public Transform sightStart;
	public Transform sightEnd;

	public LayerMask detection;
	public bool flip;

	private float initialSpeed;
	private float yStart;
	private Vector3 tempPos;
	[HideInInspector]
	public bool colliding;
	private Vector2 reverse;
	private Vector2 normal;
	private float collideWait;

	// Use this for initialization
	void Start () {
		yStart = transform.position.y;
		reverse = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
		normal = new Vector2 (transform.localScale.x, transform.localScale.y);
		initialSpeed = speed;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);

		colliding = Physics2D.Linecast (sightStart.position, sightEnd.position, detection);
		//Debug.Log (collideWait + " vs " + (Time.time + 3));
		if (colliding) {
			transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
			speed *= -1;
			collideWait = Time.time + 1;
		}

		if (Time.time > collideWait) {
			if (transform.localScale.x > 0 && flip) {
				transform.localScale = reverse;
				speed = -speed;
			}
			if (transform.localScale.x < 0 && flip) {
				transform.localScale = normal;
				speed = initialSpeed;
			}
		}


		tempPos.y = yStart + amplitude * Mathf.Sin (bobSpeed * Time.time);
		transform.position = new Vector2 (transform.position.x, tempPos.y);
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawLine (sightStart.position, sightEnd.position);
	}
}
