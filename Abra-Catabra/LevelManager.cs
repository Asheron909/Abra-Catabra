using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckPoint;

	private Player player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType <Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (player);
	
	}

	public void RespawnPlayer () {
		//Debug.Log ("Player Respawn");
		player.transform.position = currentCheckPoint.transform.position;
	}
}
