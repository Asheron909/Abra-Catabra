using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public LevelManager levelManager;

	void Start() {
		levelManager = FindObjectOfType <LevelManager> ();
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			levelManager.currentCheckPoint = gameObject;
		}
	}
}
