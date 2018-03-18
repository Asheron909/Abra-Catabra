using UnityEngine;
using System.Collections;

public class HealthUp : MonoBehaviour {

	public float speed;
	public float speedY = 1f;
	public float amplitude;

	private float yStart;
	private Vector3 tempPos;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			if (GameControl.control.health < 3) {
				GameControl.control.health = 3;
				Destroy (gameObject);
			}

			/*if (col.GetComponent <PlayerHealth> ().currentHealth < col.GetComponent <PlayerHealth> ().maxHealth) {
				col.GetComponent <PlayerHealth> ().currentHealth = col.GetComponent <PlayerHealth> ().maxHealth;
				Destroy (gameObject);
			}*/
		}
	}

	void Start () {
		yStart = transform.position.y;
	}

	void Update () {
		transform.Rotate (Vector3.down, speed * Time.deltaTime);
		tempPos.y = yStart + amplitude * Mathf.Sin (speedY * Time.time);
		transform.position = new Vector2 (transform.position.x, tempPos.y);
	}

}
