using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneControl : MonoBehaviour {
    private timer timerObject;
    public static bool paused;
    void Awake()
    {
        if (GameObject.Find("Timer"))
        {
            timerObject = GameObject.Find("Timer").GetComponent<timer>();
        }
    }


	// Use this for initialization
	void Start () {
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void togglePause()
    {
        paused = !paused;
        if (paused)
        {
            if (this.timerObject)
            {
                timerObject.paused = true;
            }
        }
        else
        {
            if (this.timerObject)
            {
                timerObject.paused = false;
            }
        }
    }
}
