using UnityEngine;
using System.Collections;

public class StationaryEnemyMovement : MonoBehaviour {

	public float speed = 1f;
	public float amplitude;

	private float yStart;
	private Vector3 tempPos;

	// Use this for initialization
	void Start () {
		yStart = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		tempPos.y = yStart + amplitude * Mathf.Sin (speed * Time.time);
		transform.position = new Vector2 (transform.position.x, tempPos.y);
	}
}
