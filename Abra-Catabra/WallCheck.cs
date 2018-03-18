using UnityEngine;
using System.Collections;

public class WallCheck : MonoBehaviour {

	private Player player;

	void Start () {
		player = gameObject.GetComponentInParent<Player> ();
	}

	/*void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Wall") {
			player.walled = true;
			//Debug.Log (col.tag);
		}
		else
			return;
	}*/

	void OnTriggerStay2D(Collider2D col) {
		if (col.tag == "Wall") {
			player.walled = true;
			//Debug.Log (col.tag);
		}
		else
			return;
	}

	void OnTriggerExit2D(Collider2D col) {
		player.walled = false;
	}
}
