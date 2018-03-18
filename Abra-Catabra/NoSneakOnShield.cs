using UnityEngine;
using System.Collections;

public class NoSneakOnShield : MonoBehaviour {

	public float xDis;
	public float yDis;
	public GameObject parentGhost;
	public Transform sightStart;
	public Transform sightEnd;
	public LayerMask detection;

	private bool colliding;
	private bool ghostFlipped;
	private Vector2 reverse;
	private Vector2 normal;

	// Use this for initialization
	void Start () {
		reverse = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
		normal = new Vector2 (transform.localScale.x, transform.localScale.y);
	}
	
	// Update is called once per frame
	void Update () {
		colliding = Physics2D.Linecast (sightStart.position, sightEnd.position, detection);
		parentGhost.GetComponent<EnemyMovement> ().flip = colliding;

		//Debug.Log (ghostFlipped);

		if (parentGhost.transform.localScale.x > 0) {
			ghostFlipped = true;
		} 
		if (parentGhost.transform.localScale.x < 0) {
			ghostFlipped = false;
		}

		if (ghostFlipped) {
			gameObject.transform.position = new Vector3 (parentGhost.transform.position.x - xDis, parentGhost.transform.position.y + yDis, parentGhost.transform.position.z);
			transform.localScale = normal;
		}
		if (!ghostFlipped) {
			gameObject.transform.position = new Vector3 (parentGhost.transform.position.x + xDis, parentGhost.transform.position.y + yDis, parentGhost.transform.position.z);
			transform.localScale = reverse;
		}

		if (parentGhost.GetComponent<EnemyHealth>().health <= 0) {
			Destroy (gameObject);
		}

	}

	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawLine (sightStart.position, sightEnd.position);
	}
}
