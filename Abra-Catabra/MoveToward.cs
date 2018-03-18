using UnityEngine;
using System.Collections;

public class MoveToward : MonoBehaviour {

	public float smoothTime = 0.4f;

	private GameObject player;
	private Transform target;
	private Vector3 velocity = Vector3.zero;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		target = player.transform.FindChild("OrbitTarget");
		transform.position = Vector3.SmoothDamp (transform.position, target.position, ref velocity, smoothTime);
		//transform.position = Vector3.MoveTowards (transform.position, target.position, 12 * Time.deltaTime);
	}
}
