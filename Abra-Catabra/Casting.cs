using UnityEngine;
using System.Collections;

public class Casting : MonoBehaviour {

	public float castTime;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.GetComponent<Collider2D>().gameObject.layer == LayerMask.NameToLayer("Wall")) {
			//Debug.Log ("Hit Wall");
			Destroy (gameObject);
		}
		else
			return;
	}
}
