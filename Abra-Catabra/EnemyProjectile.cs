using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

	public float rotateSpeed;
	public LevelManager levelManager;
	public int attackDamage;
	public float destroyTime;

	GameObject player;
	PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		levelManager = FindObjectOfType <LevelManager> ();
		Destroy (gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, rotateSpeed);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.GetComponent<Collider2D>().gameObject.layer == LayerMask.NameToLayer("Wall") || 
			col.GetComponent<Collider2D>().gameObject.layer == LayerMask.NameToLayer("Ground")) {
			//Debug.Log ("Hit Wall");
			Destroy (gameObject);
		}
		if (col.tag == "Player") {
			if (playerHealth.currentHealth <= 0) {
				if (playerHealth.lives > 0) {
					playerHealth.lives -= 1;
					//Debug.Log ("Call Respawn");
					levelManager.RespawnPlayer ();
					playerHealth.currentHealth = playerHealth.maxHealth;
				}
			}
			Attack ();
			Destroy (gameObject);
		}

		else
			return;
	}

	void Attack(){
		if (playerHealth.currentHealth > 0 && !Player.stealthing) {
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
