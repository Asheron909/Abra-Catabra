using UnityEngine;
using System.Collections;

public class loadOnClick : MonoBehaviour {


    public void loadScene(int level)
    {
        Application.LoadLevel(level);
    }
}
