using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

	public int levelLoad;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player" || col.tag == "Stealthing") {
			SceneManager.LoadScene (levelLoad);
		}
	}
}
