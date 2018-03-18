using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

	public Transform targetOrbit;
	public float orbitSpeed;
	//public float orbitDistance;

	//private Vector3 tempPos;

	// Update is called once per frame
	void Update () {
		OrbitAround ();
	}

	void OrbitAround (){
		//tempPos = targetOrbit.position + (transform.position - targetOrbit.position).normalized * orbitDistance;
		//transform.position = tempPos;
		transform.RotateAround (targetOrbit.position, Vector3.down, orbitSpeed * Time.deltaTime);
	}
}
