using UnityEngine;
using System.Collections;

public class ChargeEnemy : MonoBehaviour {

	public Transform sightStart;
	public Transform sightEnd;
	public float buildUpTime;
	public float chargeSpeed;

	public LayerMask detection;

	private bool colliding;
	private bool charging;
	private float buildUp;
	private bool buildingUp;
	private float defaultSpeed;

	// Use this for initialization
	void Start () {
		charging = false;
		buildingUp = false;
		defaultSpeed = gameObject.GetComponentInParent<EnemyMovement> ().speed;
	}

	void Update () {
		if (gameObject.GetComponentInParent<EnemyMovement> ().colliding) {
			gameObject.GetComponentInParent<EnemyAttack> ().attackDamage = 1;
			gameObject.GetComponentInParent<EnemyMovement> ().speed = defaultSpeed *= -1;
			charging = false;
			buildingUp = false;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		colliding = Physics2D.Linecast (sightStart.position, sightEnd.position, detection);

		if (colliding) {
			charging = true;
			StartCoroutine (BuildingUp ());
		}
			
		if (charging && buildingUp) {
			if (gameObject.transform.parent.localScale.x > 0) {
				gameObject.GetComponentInParent<EnemyMovement> ().speed = chargeSpeed;
				gameObject.GetComponentInParent<EnemyAttack> ().attackDamage = 3;
			}
			if (gameObject.transform.parent.localScale.x < 0) {
				gameObject.GetComponentInParent<EnemyMovement> ().speed = -chargeSpeed;
				gameObject.GetComponentInParent<EnemyAttack> ().attackDamage = 3;
			}
		}
	}

	public IEnumerator BuildingUp() {
		//Debug.Log ("buildingUp");
		gameObject.GetComponentInParent<EnemyMovement> ().speed = 0;
		yield return new WaitForSeconds (buildUpTime);
		buildingUp = true;
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawLine (sightStart.position, sightEnd.position);
	}
}
