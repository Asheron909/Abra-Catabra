using UnityEngine;
using System.Collections;

public class LevelSelectButtons : MonoBehaviour {

	public bool lvl1, lvl2, lvl3, lvl4,lvl5;

	// Use this for initialization
	void Start () {
    if(lvl1 == true)
        {
            if(GameControl.control.levelCompleate1 == true)
            {
                enabled = false;
            }
        }
    if (lvl2 == true)
        {
            if (GameControl.control.levelCompleate2 == true)
            {
                enabled = false;
            }
        }
    if (lvl3 == true)
        {
            if (GameControl.control.levelCompleate3 == true)
            {
                enabled = false;
            }
        }
    if (lvl4 == true)
        {
            if (GameControl.control.levelCompleate4 == true)
            {
                enabled = false;
            }
        }
	if (lvl5 == true)
		{
			if (GameControl.control.levelCompleate5 == true)
			{
				enabled = false;
			}
		}
    }

    // Update is called once per frame
    void Update () {
	
	}
}
