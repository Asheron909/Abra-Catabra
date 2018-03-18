using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	GameObject player;
	public Vector2 focusAreaSize;
	public float verticalOffset;
	public float lookAheadX;
	public float lookSmoothTimeX;
	public float verticalSmoothTime;

	FocusArea focusArea;

	private float currentLookAheadX;
	private float targetLookAheadX;
	private float lookAheadDirX;
	private float smoothLookVelocityX;
	private float smoothVelocityY;
	private bool lookAheadStopped;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		focusArea = new FocusArea (player.GetComponent<BoxCollider2D>().bounds, focusAreaSize);
		//Debug.Log (player.GetComponent<BoxCollider2D> ().bounds);
	}

	void FixedUpdate () {
		focusArea.Update (player.GetComponent<BoxCollider2D>().bounds);
		//Debug.Log (player.GetComponent<BoxCollider2D> ().bounds);
		//Debug.Log ("Focus Center = " + focusArea.center);
		//Debug.Log ("Focus size = " + focusAreaSize);

		//sets the vertical offset of the camera relative to player
		Vector2 focusPosition = focusArea.center + Vector2.up * verticalOffset;


		//Checks the look ahead depending on focus velocity
		//if the focusArea is moving in x, continue looking ahead
		if (focusArea.velocity.x != 0) {
			lookAheadDirX = Mathf.Sign (focusArea.velocity.x);
			if ((Mathf.Sign (player.GetComponent<Player>().move.x) == Mathf.Sign (focusArea.velocity.x)) && player.GetComponent<Player>().move.x != 0) {
				lookAheadStopped = false;
				targetLookAheadX = lookAheadDirX * lookAheadX;
			} 
		}
		//if the focusArea is not moving in x, ease into movement
		else {
			if (!lookAheadStopped) {
				lookAheadStopped = true;
				targetLookAheadX = currentLookAheadX + (lookAheadDirX * lookAheadX - currentLookAheadX) / 4;
			}
		}

		//sets the look ahead depending on direction moving and distance set
		currentLookAheadX = Mathf.SmoothDamp (currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookSmoothTimeX);

		focusPosition.y = Mathf.SmoothDamp (transform.position.y, focusPosition.y, ref smoothVelocityY, verticalSmoothTime);
		focusPosition += Vector2.right * currentLookAheadX; //Executes LookAhead
		transform.position = (Vector3)focusPosition + Vector3.forward * -10; //Transforms Camera position
	}

	/*void OnDrawGizmos() {
		Gizmos.color = new Color (1, 0, 0, .5f);
		Gizmos.DrawCube (focusArea.center, focusAreaSize);
	}*/

	struct FocusArea {
		public Vector2 center;
		public Vector2 velocity;
		public float left, right;
		public float top, bottom;

		public FocusArea(Bounds targetBounds, Vector2 size) {
			left = targetBounds.center.x - size.x/2;
			right = targetBounds.center.x + size.x/2;
			bottom = targetBounds.min.y;
			top = targetBounds.min.y + size.y;

			velocity = Vector2.zero;
			center = new Vector2((left+right)/2, (top +bottom)/2);
		}

		public void Update(Bounds targetBounds) {
			float shiftX = 0;
			if (targetBounds.min.x < left) {
				shiftX = targetBounds.min.x - left;
			}
			else if (targetBounds.max.x > right) {
				shiftX = targetBounds.max.x - right;
			}
			left += shiftX;
			right += shiftX;

			float shiftY = 0;
			if (targetBounds.min.y < bottom) {
				shiftY = targetBounds.min.y - bottom;
			}
			else if (targetBounds.max.y > top) {
				shiftY = targetBounds.max.y - top;
			}
			top += shiftY;
			bottom += shiftY;

			center = new Vector2 ((left + right) / 2, (top + bottom) / 2);
			velocity = new Vector2 (shiftX, shiftY);
		}
	}
}