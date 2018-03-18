using UnityEngine;
using System.Collections;

public class RangedEnemy : MonoBehaviour {

	public GameObject attack;
	public Transform attackSpawn;
	public Transform sightStart;
	public Transform sightEnd;
	public LayerMask detection;
	public bool flips;
	public float projectileSpeed;
	public float attackSpeed;
	public bool boss;

	private GameObject player;
	private bool colliding;
	private float timer;
	private bool flipped;
	private Vector2 reverse;
	private Vector2 normal;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		reverse = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
		normal = new Vector2 (transform.localScale.x, transform.localScale.y);
	}
	
	// Update is called once per frame
	void Update () {
		colliding = Physics2D.Linecast (sightStart.position, sightEnd.position, detection);

		if (flips) {
			if (player.gameObject.transform.position.x > gameObject.transform.position.x) {
				// Multiply the enemy's x local scale by -1.
				transform.localScale = reverse;
			}
			if (player.gameObject.transform.position.x < gameObject.transform.position.x) {
				transform.localScale = normal;
			}
		}

		if (colliding && timer < Time.time) {
			if (!boss) {
				//attackSpawn.position = new Vector3 (attackSpawn.position.x, attackSpawn.position.y - Random.Range (0f, 5f), attackSpawn.position.z);
				if (!flipped) {
					GameObject go = (GameObject)Instantiate (attack, attackSpawn.position, attackSpawn.rotation *= Quaternion.Euler (0, 0, 0));
					go.GetComponent<Rigidbody2D> ().velocity = -(transform.right * projectileSpeed);
					timer = Time.time + attackSpeed;
				}
				if (flipped) {
					GameObject clone;
					clone = Instantiate (attack, attackSpawn.position, attackSpawn.rotation *= Quaternion.Euler (0, 0, 0)) as GameObject;
					Vector3 temp = clone.transform.localScale;
					temp.x = (clone.transform.localScale.x) * -1.0f;
					clone.transform.localScale = temp;
					clone.GetComponent<Rigidbody2D> ().velocity = transform.right * projectileSpeed;
					timer = Time.time + attackSpeed;
				}
			}

			if (boss) {
				if (!flipped) {
					GameObject go = (GameObject)Instantiate (attack, new Vector3 (attackSpawn.position.x, attackSpawn.position.y - Random.Range (-1f, 3f), attackSpawn.position.z), attackSpawn.rotation *= Quaternion.Euler (0, 0, 0));
					go.GetComponent<Rigidbody2D> ().velocity = -(transform.right * projectileSpeed);
					timer = Time.time + attackSpeed;
				}
				if (flipped) {
					GameObject clone;
					clone = Instantiate (attack, attackSpawn.position, attackSpawn.rotation *= Quaternion.Euler (0, 0, 0)) as GameObject;
					Vector3 temp = clone.transform.localScale;
					temp.x = (clone.transform.localScale.x) * -1.0f;
					clone.transform.localScale = temp;
					clone.GetComponent<Rigidbody2D> ().velocity = transform.right * projectileSpeed;
					timer = Time.time + attackSpeed;
				}
			}
		}
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawLine (sightStart.position, sightEnd.position);
	}
}
