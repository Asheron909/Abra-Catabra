using UnityEngine;
using System.Collections;

public class FlyingAttack : MonoBehaviour {

	/*public float swoopDis;
	public float swoopSpeed;

	private Vector3 swoopTowards;
	private float startY;
	private float timer;
	private float randomNum;
	private float swoop;
	private float bobSpeed;
	private Vector3 tempY;
	private bool swooping;
	private bool fullSwoop;
	public float speed = 1f;
	public float bobSpeedInt = 1f;
	public float amplitude;

	public Transform sightStart;
	public Transform sightEnd;

	public LayerMask detection;
	public bool flip;

	private float yStart;
	private Vector3 tempPos;
	private bool colliding;
	private Vector2 reverse;
	private Vector2 normal;
	private float collideWait;


	// Use this for initialization
	void Start () {
		bobSpeedInt = bobSpeed;
		startY = gameObject.transform.position.y;
		timer = 5;
		swooping = false;
		reverse = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
		normal = new Vector2 (transform.localScale.x, transform.localScale.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > Time.time) {
			randomNum = Random.Range (1, 10);
			if (randomNum == 9 && fullSwoop) {
				swooping = true;
				fullSwoop = false;
				Debug.Log ("Swoop!");
			}
		}

		if (swooping) {
			
			transform.Translate (Vector2.down * swoopSpeed * Time.deltaTime);
		}

		if (!swooping && !fullSwoop) {
			transform.Translate (Vector2.up * swoopSpeed * Time.deltaTime);
		}

		if (fullSwoop) {
			tempPos.y = yStart + amplitude * Mathf.Sin (bobSpeedInt * Time.time);
			transform.position = new Vector2 (transform.position.x, tempPos.y);		}

		if (transform.position.y <= startY - swoopDis) {
			swooping = false;
		}

		if (transform.position.y >= startY) {
			fullSwoop = true;
		}
	}

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
				speed = speed;
			}
		}
	}*/
}
