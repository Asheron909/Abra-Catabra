using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float health;
	public SpriteRenderer spriteDamaged;
	public float flashSpeed = 5f;
	public Color flashColor = new Color (1f, 0f, 0f, 0.1f);

	private float damage;
	private bool goodDeath;
	private bool damaged;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Death ();
		}
		if (damaged) {
			//spriteDamaged.color = flashColor;
		} 
		else {
			//spriteDamaged.color = Color.Lerp (spriteDamaged.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		damaged = false;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "PlayerAttack") {
			damage = col.GetComponent<AttackClass> ().attackPower;
			goodDeath = col.GetComponent<AttackClass> ().goodAttack;
			health -= damage;
			if (!goodDeath || col.name == "CatToy(Clone)") {
				Destroy (col.gameObject);
			}
			damaged = true;
		}
	}

	void Death () {
		if (goodDeath) {
			Destroy (gameObject);
		} 
		else {
			Destroy (gameObject);
		}
	}
}
