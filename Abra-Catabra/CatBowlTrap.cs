using UnityEngine;
using System.Collections;

public class CatBowlTrap : MonoBehaviour {

	public Transform explosionSpawn;
	public GameObject explosion;
	public float explodesIn;
	private float setTime;
	private bool exploded;

	// Use this for initialization
	void Start () {
		setTime = Time.time + explodesIn;
		exploded = false;
	}
	
	// Update is called once per frame
	void Update () {
		ExplosiveCycle ();
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Enemy") {
			//Instantiate(explosion, explosionSpawn.position, explosionSpawn.rotation) as GameObject;
			Instantiate(explosion, explosionSpawn.position, explosionSpawn.rotation *= Quaternion.Euler(0, 0, 0));
			Destroy (gameObject);
		}
	}

	void ExplosiveCycle() {
		//Debug.Log (setTime + " > " + Time.time);
		if (!exploded) {
			if (setTime <= Time.time) {
				Instantiate (explosion, explosionSpawn.position, explosionSpawn.rotation *= Quaternion.Euler (0, 0, 0));
				exploded = true;
			}
		}
	}
}
