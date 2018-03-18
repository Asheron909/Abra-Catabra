using UnityEngine;
using System.Collections;

public class ScreenTest : MonoBehaviour {

	public Vector2 size;
	public Vector2 center;

	// Use this for initialization
	void Start () {
		size = new Vector2 (5f, Screen.height);
		center = new Vector2 (Screen.width / 6, Screen.height / 2);
		Debug.Log (Screen.width + ", " + Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmos() {
		Gizmos.color = new Color (1, 0, 0, .5f);
		Gizmos.DrawCube (center, size);
	}
}
