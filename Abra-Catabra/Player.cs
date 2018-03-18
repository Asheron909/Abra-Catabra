using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10.0f;
	public float jumpPower = 800f;
	public bool grounded;
	public bool walled;
	public bool facingRight;
	[HideInInspector]
	public Vector3 move;

	public static bool stealthing;

	/*public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;*/

	private Transform playerGraphics;
	private Vector2 velocity;
	private bool attacking;
	private bool badAttacking;

    //Animation stuff
    Animator anim;

    float moveHorizontal;
    bool MoveRBD, MoveLBD;

    void Awake () {
		playerGraphics = transform.FindChild ("Graphics");
		if (playerGraphics == null) {
			Debug.LogError ("No 'Graphics' in parent Player");
		}
	}

	// Use this for initialization
	void Start () {
		facingRight = true;
		grounded = true;
        //set animator
        anim = GetComponent<Animator>();
		stealthing = false;
	}
	
	// Update is called once per frame
	void Update () {
		attacking = GetComponent<PlayerAttack> ().attacking;
		badAttacking = GetComponent<PlayerAttack> ().badAttacking;
        //Animator clearing variables
        anim.SetBool("grounded", grounded);

		if (stealthing) {
			gameObject.tag = "Stealthing";
			gameObject.layer = 13;
			gameObject.GetComponentInChildren<Transform> ().gameObject.layer = 13; 
		}
		else {
			gameObject.tag = "Player";
			gameObject.layer = 8;
			gameObject.GetComponentInChildren<Transform> ().gameObject.layer = 8; 
		}

		//calculate vertical movement while player is attacking
        if (attacking) {
			if (!grounded) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, GetComponent<Rigidbody2D> ().velocity.y);
			} 
			else {
				GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			}
		}

		//floating casting effect
		if (badAttacking) {
			if (!grounded) {
				GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			}
			else {
				GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			}
		} 
			
		//if the player is not attacking player can move
		if (!attacking && !badAttacking) {
			//Jumping Movement
			if (Input.GetKey ("up") && grounded) {
				grounded = false;
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jumpPower), ForceMode2D.Force);
			}
			//wall sliding
			if (walled) {
				GetComponent<Rigidbody2D> ().velocity = new Vector3 (GetComponent<Rigidbody2D> ().velocity.x, -3, 0);

				/*if (Input.GetKey ("up") && walled) {
				if (facingRight) {
					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-wallJumpOff.x, wallJumpOff.y) * jumpPower, ForceMode2D.Force);
				}
				if (!facingRight) {
					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (wallJumpOff.x, wallJumpOff.y) * jumpPower, ForceMode2D.Force);
				}
			}
			print ("Wall jump!");*/
				//walled = false;
			}

#if UNITY_STANDALONE
            //This is where input for horizontal movement happens
            moveHorizontal = Input.GetAxis ("Horizontal");
#endif
#if UNITY_ANDROID
            //new button moveHorizontal input
            if(MoveRBD)
            {
                moveHorizontal = 1;
            }
            else if(MoveLBD)
            {
                moveHorizontal = -1;
            }
            else
            {
                moveHorizontal = 0;
            } 
#endif

			//if not Stealthing
			if (!stealthing) {
				//Horizontal Movement
				move = new Vector2 (moveHorizontal * speed, GetComponent<Rigidbody2D> ().velocity.y);
				GetComponent<Rigidbody2D> ().velocity = move;
			} 
			else {
				//Horizontal Movement
				move = new Vector2 (moveHorizontal * speed/5, GetComponent<Rigidbody2D> ().velocity.y);
				GetComponent<Rigidbody2D> ().velocity = move;
			}

			if (moveHorizontal > 0 && !facingRight)
				// ... flip the player.
				Flip ();
				// Otherwise if the input is moving the player left and the player is facing right...
			else if (moveHorizontal < 0 && facingRight)
				// ... flip the player.
				Flip ();
        }

		//Animation movement
		anim.SetFloat("horizontalSpeed", Mathf.Abs(moveHorizontal));
		anim.SetFloat("verticalSpeed", GetComponent<Rigidbody2D> ().velocity.y);
    }

	void FixedUpdate () {
		
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    public void Jump()
    {
		if (grounded) {
			grounded = false;
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jumpPower), ForceMode2D.Force);
		}
		//wall sliding
		if (walled) {
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (GetComponent<Rigidbody2D> ().velocity.x, -3, 0);

			/*if (Input.GetKey ("up") && walled) {
				if (facingRight) {
					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-wallJumpOff.x, wallJumpOff.y) * jumpPower, ForceMode2D.Force);
				}
				if (!facingRight) {
					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (wallJumpOff.x, wallJumpOff.y) * jumpPower, ForceMode2D.Force);
				}
			}
			print ("Wall jump!");*/
			//walled = false;
		}
    }
    public void MoveRightDown()
    {
        MoveRBD = true;
    }
    public void MoveRightUp()
    {
        MoveRBD = false;
    }
    public void MoveLeftDown()
    {
        MoveLBD = true;
    }
    public void MoveLeftUp()
    {
        MoveLBD = false;
    }
}
