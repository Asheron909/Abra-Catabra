using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	public int lives;
	public float flashSpeed = 5f;
	public Color flashColor = new Color (1f, 0f, 0f, 0.1f);
    public GameObject heart1, heart2, heart3;
    public Text NumOfLives;
	public bool pitDeath = false;

	private bool isDead;
	private bool damaged;


	// Use this for initialization
	void Start () {
        heart1 = GameObject.Find("Heart 1");
        heart2 = GameObject.Find("Heart 2");
        heart3 = GameObject.Find("Heart 3");
        NumOfLives = GameObject.Find("NumOfLives").GetComponent<Text>();
        NumOfLives.text = lives.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
            

            
		}
		else {

		}
		if(GameControl.control.health == 3)
            {
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
        }
		if(GameControl.control.health == 2)
            {
                heart1.SetActive(false);
                heart2.SetActive(true);
                heart3.SetActive(true);
            }
		if (GameControl.control.health == 1)
            {
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(true);
            }
		NumOfLives.text = GameControl.control.lives.ToString();
		damaged = false;

		if (pitDeath) {
			Death ();
		}
		//Debug.Log (currentHealth);
	}

	public void TakeDamage (int amount) {
		damaged = true;

		GameControl.control.health -= amount;

		if (GameControl.control.health <= 0 && GameControl.control.lives == 0) {
			Death ();
		}

	}

	void Death() {
		isDead = true;
		Debug.Log ("Player is Dead");
        StartCoroutine ("WaitForDeath");
        SceneManager.LoadScene(4);
    }
    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(2);
    }
}
