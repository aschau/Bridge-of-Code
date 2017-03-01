using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneControl : MonoBehaviour {
    public static bool paused, locked;
    void Awake()
    {
        paused = false;
    }


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    public static void togglePause()
    {
        if (!locked)
            paused = !paused;
        Debug.Log(paused);
    }

    public static void toggleLock()
    {
        locked = !locked;
    }
}
