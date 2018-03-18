using UnityEngine;
using System.Collections;

public class CatToyHurl : MonoBehaviour {

	public float speed;
	public float force;

	private GameObject player;
	private bool facingRight;
	
	// Update is called once per frame
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		facingRight = player.GetComponent<Player> ().facingRight;
		if (facingRight) {
			GetComponent<Rigidbody2D> ().AddTorque (speed);
			GetComponent<Rigidbody2D> ().AddForce (transform.right * force);
		}
		if (!facingRight) {
			GetComponent<Rigidbody2D> ().AddTorque (-speed);
			GetComponent<Rigidbody2D> ().AddForce (transform.right * -force);
		}
	}
}
