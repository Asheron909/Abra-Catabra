using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

    private GameObject player;
    private GameObject candelabra;
    private Transform weaponSpawn;
    public bool badAttack;
    public bool goodAttack;
    public int attackType;
    [HideInInspector]
    public bool attacking;
    [HideInInspector]
    public bool badAttacking;

    private float attackSpeed;
    private float swingTimer;
    public float attackPower;
    private float nextAttack;
    private float thisAttack;
    private bool attackUnlocked;
    private float castTime;
    private GameObject attackPrefab;
    private GameObject createAttack;
	private bool[] attackArray;

    //animator variable
    Animator anim;
    Animator candelabraAnim;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        candelabra = GameObject.FindGameObjectWithTag("Candelabra");
        weaponSpawn = GameObject.FindGameObjectWithTag("PlayerWeaponSpawn").transform;
        goodAttack = true;
        badAttack = false;
        attacking = false;
        badAttacking = false;
        attackType = 0;
        //Set animator
        anim = GetComponent<Animator>();
        candelabraAnim = candelabra.GetComponent<Animator>();
        candelabraAnim.SetBool("Good", goodAttack);
        candelabraAnim.SetInteger("GoodNum", attackType);
        attackArray = new bool[5];
		attackArray [0] = true;
		attackArray [1] = player.GetComponent<AttackTypes> ().attackType1;
		attackArray [2] = player.GetComponent<AttackTypes> ().attackType2;
		attackArray [3] = player.GetComponent<AttackTypes> ().attackType3;
		attackArray [4] = player.GetComponent<AttackTypes> ().attackType4;
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_STANDALONE

		//check input for attacking
		if (Input.GetButtonDown ("Jump") && Time.time > nextAttack) {
			//if good attack is selected
			if (goodAttack) {
				for (int i = attackType; i < 5; i++) {
					//Debug.Log (attackType + " = " + i + " & " + attackArray[i]);
					if (attackType == i && attackArray[i]) {
						break;
					}
					attackType = i + 1;
					if (attackType >= 5) {
						attackType = 0;
					}
				}
				AttackingCycle();
			}

            //if bad attack is selected
            else if (badAttack) {
				//attackSpeed = GetComponent<AttackTypes> ().attackPrefabBad.GetComponent<Casting> ().castTime;
				//print ("Bad Attack");
				StartCoroutine (Casting ());
			}
			//calculate when next attack can happen
			nextAttack = Time.time + attackSpeed;
		}
		//while attacking cannot attack again
		if (thisAttack <= Time.time) {
			attacking = false;
		}

		if (!Player.stealthing) {
	        //cycle between good and bad attack
	        if (Input.GetKeyDown (KeyCode.Z)) {
	        	if (goodAttack) {
	        		goodAttack = false;
	        		badAttack = true;
                    candelabraAnim.SetBool("Good", goodAttack);
                }
                else if (badAttack) {
	        		badAttack = false;
	        		goodAttack = true;
                    candelabraAnim.SetBool("Good", goodAttack);
                }
            }

	        //cycles between unlocked good attacks
	        if (Input.GetKeyDown (KeyCode.X)) {
	        	AttackCycle ();
                candelabraAnim.SetInteger("GoodNum", attackType);
            }
        }
#endif
    }

    //cycles through good attacks
    public void AttackCycle()
    {
        if (attackType <= 4)
        {
            attackType = attackType + 1;
        }
        if (attackType == 5)
        {
            attackType = 0;
        }
    }

    public void AttackingCycle()
    {
        //Instantiate Basic Good Attack	
        if (attackType == 0)
        {
            attackPrefab = player.GetComponent<AttackTypes>().attackPrefab0;
            swingTimer = attackPrefab.GetComponent<AttackClass>().swingTimer;
            attackSpeed = attackPrefab.GetComponent<AttackClass>().attackSpeed;
            nextAttack = Time.time + attackSpeed;

            //Check the player direction
            if (player.GetComponent<Player>().facingRight)
            {
                (Instantiate(attackPrefab, weaponSpawn.position, weaponSpawn.rotation *= Quaternion.Euler(0, 0, 0)) as GameObject).transform.parent = player.transform;
                attacking = true;
                thisAttack = Time.time + swingTimer;
                anim.SetTrigger("swipeAttack");
            }
            if (!player.GetComponent<Player>().facingRight)
            {
                GameObject clone;
                clone = Instantiate(attackPrefab, weaponSpawn.position, weaponSpawn.rotation *= Quaternion.Euler(0, 0, 0)) as GameObject;
                clone.transform.parent = player.transform;
                Vector3 temp = clone.transform.localScale;
                temp.x = (clone.transform.localScale.x) * -1.0f;
                clone.transform.localScale = temp;
                attacking = true;
                thisAttack = Time.time + swingTimer;
                anim.SetTrigger("swipeAttack");
            }
        }

		//Instantiate Cat Bowl Trap	
		if (attackType == 1)
		{
			attackPrefab = player.GetComponent<AttackTypes>().attackPrefab1;
			swingTimer = attackPrefab.GetComponent<AttackClass>().swingTimer;
			attackSpeed = attackPrefab.GetComponent<AttackClass>().attackSpeed;
			nextAttack = Time.time + attackSpeed;

			//Check the player direction
			if (player.GetComponent<Player>().facingRight)
			{
				Instantiate(attackPrefab, weaponSpawn.position, weaponSpawn.rotation *= Quaternion.Euler(0, 0, 0));
				attacking = true;
				thisAttack = Time.time + swingTimer;
				anim.SetTrigger("swipeAttack");
			}
			if (!player.GetComponent<Player>().facingRight)
			{
				GameObject clone;
				clone = Instantiate(attackPrefab, weaponSpawn.position, weaponSpawn.rotation *= Quaternion.Euler(0, 0, 0)) as GameObject;
				Vector3 temp = clone.transform.localScale;
				temp.x = (clone.transform.localScale.x) * -1.0f;
				clone.transform.localScale = temp;
				attacking = true;
				thisAttack = Time.time + swingTimer;
				anim.SetTrigger("swipeAttack");
			}
		}

		//Instantiate Cat Toy Hurl	
		if (attackType == 2)
		{
			attackPrefab = player.GetComponent<AttackTypes>().attackPrefab2;
			swingTimer = attackPrefab.GetComponent<AttackClass>().swingTimer;
			attackSpeed = attackPrefab.GetComponent<AttackClass>().attackSpeed;
			nextAttack = Time.time + attackSpeed;

			//Check the player direction
			if (player.GetComponent<Player>().facingRight)
			{
				Instantiate(attackPrefab, weaponSpawn.position, Quaternion.Euler(0, 0, 45));
				attacking = true;
				thisAttack = Time.time + swingTimer;
				anim.SetTrigger("swipeAttack");
			}
			if (!player.GetComponent<Player>().facingRight)
			{
				GameObject clone;
				clone = Instantiate(attackPrefab, weaponSpawn.position, Quaternion.Euler(0, 0, -45)) as GameObject;
				Vector3 temp = clone.transform.localScale;
				temp.x = (clone.transform.localScale.x) * -1.0f;
				clone.transform.localScale = temp;
				attacking = true;
				thisAttack = Time.time + swingTimer;
				anim.SetTrigger("swipeAttack");
			}
		}

		//Instantiate Stealth	
		if (attackType == 3) {
			if (!Player.stealthing) {
				Player.stealthing = true;
			} 
			else {
				Player.stealthing = false;
				attackPrefab = player.GetComponent<AttackTypes> ().attackPrefab3;
				swingTimer = attackPrefab.GetComponent<AttackClass> ().swingTimer;
				attackSpeed = attackPrefab.GetComponent<AttackClass> ().attackSpeed;
				nextAttack = Time.time + attackSpeed;

				//Check the player direction
				if (player.GetComponent<Player>().facingRight)
				{
					(Instantiate(attackPrefab, weaponSpawn.position, weaponSpawn.rotation *= Quaternion.Euler(0, 0, 0)) as GameObject).transform.parent = player.transform;
					attacking = true;
					thisAttack = Time.time + swingTimer;
					anim.SetTrigger("swipeAttack");
				}
				if (!player.GetComponent<Player>().facingRight)
				{
					GameObject clone;
					clone = Instantiate(attackPrefab, weaponSpawn.position, weaponSpawn.rotation *= Quaternion.Euler(0, 0, 0)) as GameObject;
					clone.transform.parent = player.transform;
					Vector3 temp = clone.transform.localScale;
					temp.x = (clone.transform.localScale.x) * -1.0f;
					clone.transform.localScale = temp;
					attacking = true;
					thisAttack = Time.time + swingTimer;
					anim.SetTrigger("swipeAttack");
				}
			}
		}

		if (attackType == 4)
		{
			attackPrefab = player.GetComponent<AttackTypes>().attackPrefab4;
			swingTimer = attackPrefab.GetComponent<AttackClass>().swingTimer;
			attackSpeed = attackPrefab.GetComponent<AttackClass>().attackSpeed;
			nextAttack = Time.time + attackSpeed;

			//Check the player direction
			if (player.GetComponent<Player>().facingRight)
			{
				Instantiate(attackPrefab, weaponSpawn.position, weaponSpawn.rotation *= Quaternion.Euler(0, 0, 0));
				attacking = true;
				thisAttack = Time.time + swingTimer;
				anim.SetTrigger("swipeAttack");
			}
			if (!player.GetComponent<Player>().facingRight)
			{
				GameObject clone;
				clone = Instantiate(attackPrefab, weaponSpawn.position, weaponSpawn.rotation *= Quaternion.Euler(0, 0, 0)) as GameObject;
				Vector3 temp = clone.transform.localScale;
				temp.x = (clone.transform.localScale.x) * -1.0f;
				clone.transform.localScale = temp;
				attacking = true;
				thisAttack = Time.time + swingTimer;
				anim.SetTrigger("swipeAttack");
			}
		}
    }

    //Instantiate for Bad Attack
    public IEnumerator Casting()
    {
        attackPrefab = player.GetComponent<AttackTypes>().attackPrefabBad;
        swingTimer = attackPrefab.GetComponent<AttackClass>().swingTimer;
        attackSpeed = attackPrefab.GetComponent<AttackClass>().attackSpeed;
        castTime = attackPrefab.GetComponent<Casting>().castTime;
        nextAttack = Time.time + castTime;
        badAttacking = true;
        anim.SetTrigger("BadAttack");

        yield return new WaitForSeconds(castTime);
        //Debug.Log (castTime);

        if (player.GetComponent<Player>().facingRight)
        {
            createAttack = Instantiate(attackPrefab, weaponSpawn.position, weaponSpawn.rotation *= Quaternion.Euler(0, 0, 0)) as GameObject;
            thisAttack = Time.time + castTime;
        }
        if (!player.GetComponent<Player>().facingRight)
        {
            GameObject clone;
            clone = Instantiate(attackPrefab, weaponSpawn.position, weaponSpawn.rotation *= Quaternion.Euler(0, 0, 0)) as GameObject;
            Vector3 temp = clone.transform.localScale;
            temp.x = (clone.transform.localScale.x) * -1.0f;
            clone.transform.localScale = temp;
            thisAttack = Time.time + castTime;
        }

        badAttacking = false;
    }

	public void GoodSwitch() {
		if (!Player.stealthing) {
			AttackCycle ();
            candelabraAnim.SetInteger("GoodNum", attackType);
        }
    }
    public void GoodBadSwitch()
    {
		if (!Player.stealthing) {
			if (goodAttack) {
				goodAttack = false;
				badAttack = true;
                candelabraAnim.SetBool("Good", goodAttack);
            }
            else if (badAttack) {
				badAttack = false;
				goodAttack = true;
                candelabraAnim.SetBool("Good", goodAttack);
            }
        }
    }
  #if UNITY_ANDROID
    public void Attack()
    {
        if (Time.time > nextAttack)
        {
            //if good attack is selected
			if (goodAttack) {
				for (int i = attackType; i < 5; i++) {
					//Debug.Log (attackType + " = " + i + " & " + attackArray[i]);
					if (attackType == i && attackArray[i]) {
						break;
					}
					attackType = i + 1;
					if (attackType >= 5) {
					attackType = 0;
					}
				}
				AttackingCycle();
            }
            //if bad attack is selected
            else if (badAttack)
            {
                //attackSpeed = GetComponent<AttackTypes> ().attackPrefabBad.GetComponent<Casting> ().castTime;
                //print ("Bad Attack");
                StartCoroutine(Casting());
            }
            //calculate when next attack can happen
            nextAttack = Time.time + attackSpeed;
        }
        //while attacking cannot attack again
        if (thisAttack <= Time.time)
        {
            attacking = false;
        }
    }
#endif
}
