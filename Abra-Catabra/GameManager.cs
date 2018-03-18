using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;

	private GameObject respawn;

	void Awake() {
		respawn = GameObject.FindGameObjectWithTag ("Respawn");
		GameObject go = Instantiate (player, respawn.transform.position, Quaternion.identity) as GameObject;
	}

}