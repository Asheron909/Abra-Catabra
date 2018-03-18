using UnityEngine;
using System.Collections;

public class DeathPit : MonoBehaviour {

	GameObject player;
	PlayerHealth playerHealth;
	public LevelManager levelManager;
    private float timeBeforeNextDeath;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		levelManager = FindObjectOfType <LevelManager> ();
        timeBeforeNextDeath = 0;
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Player") {
			if (GameControl.control.lives >= 0 && Time.time > timeBeforeNextDeath) {
				GameControl.control.lives -= 1;
                timeBeforeNextDeath = Time.time + 2f;
				levelManager.RespawnPlayer ();
				GameControl.control.health = playerHealth.maxHealth;
				if (GameControl.control.lives < 0) {
					playerHealth.pitDeath = true;
					playerHealth.lives = 0;
				}
			}
			//if (playerHealth.lives == 0) {
			//	playerHealth.TakeDamage (3);
			//}
		}
	}
}
