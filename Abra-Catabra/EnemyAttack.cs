using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 1;
	public LevelManager levelManager;

	GameObject player;
	PlayerHealth playerHealth;
	//EnemyHealth enemyHealth;
	bool playerInRange;
	float timer;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		levelManager = FindObjectOfType <LevelManager> ();
		//enemyHealth = GetComponent <EnemyHealth> ();
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject == player) {
			playerInRange = true;
			//Debug.Log (playerInRange);
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject == player) {
			playerInRange = false;
		}
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange) { //&&enemyHealth.currentHealth > 0
			Attack();
		}

		if (GameControl.control.health <= 0) {
			if (GameControl.control.lives > 0) {
				GameControl.control.lives -= 1;
				//Debug.Log ("Call Respawn");
				levelManager.RespawnPlayer ();
				GameControl.control.health = playerHealth.maxHealth;
			}
		}
	}

	void Attack(){
		timer = 0f;

		if (GameControl.control.health > 0) {
			playerHealth.TakeDamage (attackDamage);
		}
	}
}