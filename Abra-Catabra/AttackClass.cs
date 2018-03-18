using UnityEngine;
using System.Collections;

public class AttackClass : MonoBehaviour {

	public float attackSpeed;
	public float swingTimer;
	public float attackPower;
	public float destroyTime;
	public float speed;
	public bool goodAttack;

	private GameObject player;
	private bool facingRight;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		facingRight = player.GetComponent<Player> ().facingRight;
		Destroy (gameObject, destroyTime);
	}

	void Update (){
		if (speed != 0) {
			if (facingRight) {
				GetComponent<Rigidbody2D> ().velocity = transform.right * speed;
			}
			if (!facingRight) {
				GetComponent<Rigidbody2D> ().velocity = -(transform.right * speed);
			}
		}
	}
}
