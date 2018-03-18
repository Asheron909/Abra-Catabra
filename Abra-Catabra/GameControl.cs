using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

    public static GameControl control;

	public bool levelCompleate0, levelCompleate1, levelCompleate2, levelCompleate3, levelCompleate4, levelCompleate5;
	public bool powerUnlocked1, powerUnlocked2, powerUnlocked3,powerUnlocked4,powerUnlocked5;
	public int health, lives;

    // Use this for initialization
    void Awake () {
		health = 3;
		lives = 3;
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
